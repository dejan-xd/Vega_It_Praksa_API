using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VegaITPraksa.Models
{
    [Table("team_member/project")]
    public class TeamMemberProject
    {

        [Key]
        public int TeamMemberId { get; set; }
        public TeamMember TeamMember { get; set; }

        [Key]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public TeamMemberProject() { }
    }
}
