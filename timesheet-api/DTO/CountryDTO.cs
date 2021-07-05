using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VegaITPraksa.DTO
{
    public class CountryDTO
    {
        public int CountryId { get; set; }
        [Required]
        public string CountryName { get; set; }

        public CountryDTO()
        {
        }
    }
}
