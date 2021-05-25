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
        public RoleDTO()
        {
        }

        public RoleDTO(int roleId, string roleName)
        {
            RoleId = roleId;
            RoleName = roleName;
        }


        public int RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
    }

}
