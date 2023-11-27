using Microsoft.EntityFrameworkCore;
using TechJobs6Persistent.Models;

namespace TechJobs6Persistent.Data
{
    public class JobDbContext : DbContext
    {
        public DbSet<Job>? Jobs { get; set; }
        public DbSet<Employer>? Employers { get; set; }
        public DbSet<Skill>? Skills { get; set; }

        public JobDbContext(DbContextOptions<JobDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //set up your connection for one to many (employer to jobs)
            modelBuilder.Entity<Job>()
                .HasOne(p => p.Employer)
                .WithMany(b => b.Jobs);

            //set up your connection for many to many (skills to jobs)
            modelBuilder.Entity<Job>()
                .HasMany(e => e.Skills)
                .WithMany(e => e.Jobs)
                .UsingEntity(j => j.ToTable("JobSkills"));
        }
    }
}
