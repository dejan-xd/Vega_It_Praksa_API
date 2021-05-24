using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VegaITPraksa.Models
{
    public class Role
    {
        public Role()
        {
            TeamMembers = new HashSet<TeamMember>();
        }

        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<TeamMember> TeamMembers { get; set; }

    }
}
