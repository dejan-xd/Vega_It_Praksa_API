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
        NONE = 0,
        ACTIVE = 1,
        INACTIVE = 2,
        ARCHIVED = 3
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
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
        public int TeamLeadId { get; set; }
        [ForeignKey("TeamLeadId")]
        public virtual TeamMember TeamLead { get; set; }
        public virtual ICollection<TeamMemberProject> TeamMemberProjects { get; set; }
        public virtual ICollection<TimeSheet> TimeSheet { get; set; }
    }
}
