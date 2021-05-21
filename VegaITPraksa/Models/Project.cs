using System;
using System.Collections.Generic;
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

        public Guid ProjectId { get; set; }
        public string ProjectDescription { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public bool Archived { get; set; }
        public virtual Client Customer { get; set; }
        public virtual TeamMember Lead { get; set; }
        public virtual ICollection<TimeSheet> TimeSheet { get; set; }
    }
}
