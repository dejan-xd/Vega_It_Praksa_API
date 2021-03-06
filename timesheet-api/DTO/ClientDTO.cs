using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VegaITPraksa.Models;

namespace VegaITPraksa.DTO
{
    public class ClientDTO
    {
        public int ClientId { get; set; }
        [Required]
        public string ClientName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int ZipCode { get; set; }
        [Required]
        public int CountryId { get; set; }
        public virtual Country ClientCountry { get; set; }
        //public virtual ICollection<ProjectDTO> Projects { get; set; }


        public ClientDTO()
        {
        }
    }



}
