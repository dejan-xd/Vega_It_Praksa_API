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
        //[Required]
        //public string Password { get; set; }
        [Required]
        public TeamMemberStatus TeamMemberStatus { get; set; }
        [Required]
        public int RoleId { get; set; }
        public virtual Role TeamMemberRole { get; set; }


        public TeamMemberDTO()
        {
        }

        //public TeamMemberDTO(int teamMemberId, string name, double hoursPerWeek, string username, string email, string password, TeamMemberStatus teamMemberStatus)
        //{
        //    TeamMemberId = teamMemberId;
        //    Name = name;
        //    HoursPerWeek = hoursPerWeek;
        //    Username = username;
        //    Email = email;
        //    Password = password;
        //    TeamMemberStatus = teamMemberStatus;
        //}


        //private string username;

        //[JsonProperty("username")]
        //public string Username
        //{
        //    get
        //    {
        //        return username;
        //    }
        //    set
        //    {
        //        if (!string.IsNullOrWhiteSpace(value))
        //            username = value;
        //    }
        //}
    }
}
