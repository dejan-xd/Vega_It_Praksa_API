using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VegaITPraksa.Models;

namespace VegaITPraksa.DTO
{
    public class CategoryDTO
    {

        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }

        public CategoryDTO()
        {
        }
    }
}
