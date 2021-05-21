using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegaITPraksa.Models
{
    public class Role
    {
        public Role()
        {
            Users = new HashSet<TeamMember>();
        }

        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<TeamMember> Users { get; set; }

    }
}
