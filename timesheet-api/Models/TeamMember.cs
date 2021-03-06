using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VegaITPraksa.Models
{
    public enum TeamMemberStatus
    {
        ACTIVE,
        INACTIVE
    }

    [Table("team_member")]
    public class TeamMember
    {
        public TeamMember()
        {
            TimeSheets = new HashSet<TimeSheet>();
            TeamMemberProjects = new HashSet<TeamMemberProject>();
        }

        [Key]
        public int TeamMemberId { get; set; }
        public string Name { get; set; }
        public double HoursPerWeek { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public TeamMemberStatus TeamMemberStatus { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role TeamMemberRole { get; set; }
        public virtual ICollection<TimeSheet> TimeSheets { get; set; }
        public virtual ICollection<TeamMemberProject> TeamMemberProjects { get; set; }

    }
}
