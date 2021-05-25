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

    public class Project
    {
        public Project()
        {
            TimeSheet = new HashSet<TimeSheet>();
        }

        [Key]
        public int ProjectId { get; set; }
        public string ProjectDescription { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public bool Archived { get; set; }
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client Customer { get; set; }
        public int TeamMemberId { get; set; }
        [ForeignKey("TeamMemberId")]
        public virtual TeamMember Lead { get; set; }
        public virtual ICollection<TimeSheet> TimeSheet { get; set; }
    }
}
