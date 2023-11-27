using System;
using TechJobs6Persistent.Models;

namespace TechJobs6Persistent.ViewModels
{
    public class JobDetailViewModel

    {
        public int JobId { get; set; }
        public string Name { get; set; }
        public string EmployerName { get; set; }
        public int EmloyerId { get; set; }
        public string SkillText { get; set; }

        public JobDetailViewModel(Job theJob)
        {
            JobId = theJob.Id;
            Name = theJob.Name;
            EmployerName = theJob.Employer.Name;
            EmloyerId = theJob.Employer.Id;
            SkillText = "";
            List<Skill> skills = theJob.Skills.ToList();

            for (int i = 0; i < skills.Count; i++)
            {
                SkillText += (skills[i].SkillName);
                if (i < skills.Count - 1)
                {
                    SkillText += ", ";
                }
            }
        }
    }
}

