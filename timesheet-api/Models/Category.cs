using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VegaITPraksa.Models
{
    [Table("category")]
    public class Category
    {
        public Category()
        {
            TimeSheet = new HashSet<TimeSheet>();
        }

        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<TimeSheet> TimeSheet { get; set; }
    }

}

