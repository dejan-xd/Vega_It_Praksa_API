using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VegaITPraksa.Models
{
    public enum ProjectStatus
    {
        ACTIVE,
        INACTIVE
    }

    [Table("project")]
    public class Project
    {
        public Project()
        {
            TimeSheet = new HashSet<TimeSheet>();
            TeamMemberProjects = new HashSet<TeamMemberProject>();
        }

        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public bool Archived { get; set; }
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
        public int TeamLeadId { get; set; }
        [ForeignKey("TeamMemberId")]
        public virtual TeamMember TeamLead { get; set; }
        public virtual ICollection<TeamMemberProject> TeamMemberProjects { get; set; }
        public virtual ICollection<TimeSheet> TimeSheet { get; set; }
    }
}
