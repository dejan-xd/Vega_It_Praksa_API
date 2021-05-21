using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VegaITPraksa.Models
{
    public enum UserStatus
    {
        ACTIVE,
        INACTIVE
    }

    public class TeamMember
    {
        public TeamMember()
        {
            TimeSheets = new HashSet<TimeSheet>();
            Projects = new HashSet<Project>();
        }

        public Guid TeamMemberId { get; set; }
        public string Name { get; set; }
        public double HoursPerWeek { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserStatus UserStatus { get; set; }
        public virtual Role UserRole { get; set; }
        public virtual ICollection<TimeSheet> TimeSheets { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    
    }
}
