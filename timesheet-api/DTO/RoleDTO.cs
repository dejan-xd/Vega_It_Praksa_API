using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VegaITPraksa.Models;

namespace VegaITPraksa.DTO
{
    public class RoleDTO
    {
        public int RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }

        //public virtual ICollection<TeamMemberDTO> TeamMembers { get; set; }

        public RoleDTO()
        {
        }

    }

}
