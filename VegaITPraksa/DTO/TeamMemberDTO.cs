using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using VegaITPraksa.Models;

namespace VegaITPraksa.DTO
{
    public class TeamMemberDTO
    {
        public int TeamMemberId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double HoursPerWeek { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public TeamMemberStatus TeamMemberStatus { get; set; }
        [Required]
        public int RoleId { get; set; }

        public TeamMemberDTO()
        {
        }

        public TeamMemberDTO(int teamMemberId, string name, double hoursPerWeek, string username, string email, string password, TeamMemberStatus teamMemberStatus)
        {
            TeamMemberId = teamMemberId;
            Name = name;
            HoursPerWeek = hoursPerWeek;
            Username = username;
            Email = email;
            Password = password;
            TeamMemberStatus = teamMemberStatus;
        }

        public TeamMemberDTO(TeamMember teamMember)
        {
            TeamMemberId = teamMember.TeamMemberId;
            Name = teamMember.Name;
            HoursPerWeek = teamMember.HoursPerWeek;
            Username = teamMember.Username;
            Email = teamMember.Email;
            Password = teamMember.Password;
            TeamMemberStatus = teamMember.TeamMemberStatus;
        }

    }
}
