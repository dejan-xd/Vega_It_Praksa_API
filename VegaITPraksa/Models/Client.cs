using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VegaITPraksa.Models
{
    [Table("client")]
    public class Client
    {
        public Client()
        {
            TimeSheet = new HashSet<TimeSheet>();
            Projects = new HashSet<Project>();
        }

        [Key]
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public string Country { get; set; }
        public virtual ICollection<TimeSheet> TimeSheet { get; set; }
        public virtual ICollection<Project> Projects { get; set; }

    }
}
