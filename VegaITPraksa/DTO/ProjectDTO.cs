using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VegaITPraksa.Models;

namespace VegaITPraksa.DTO
{
    public class ProjectDTO
    {

        public int ProjectId { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public string ProjectDescription { get; set; }
        [Required]
        public ProjectStatus ProjectStatus { get; set; }
        [Required]
        public bool Archived { get; set; }
        [Required]
        public int ClientId { get; set; }

        [Required]
        public int TeamLeadId { get; set; }
        //public virtual ICollection<TeamMemberProject> TeamMemberProjects { get; set; }

        //[Required]
        //public int TeamMemberId { get; set; }

        // add users on each project
        //public virtual ICollection<TeamMemberDTO> TeamMembers { get; set; }

        public ProjectDTO()
        {
        }

    }
}
