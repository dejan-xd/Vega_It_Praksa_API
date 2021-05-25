using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VegaITPraksa.Models
{
    [Table("time_sheet")]
    public class TimeSheet
    {
        public TimeSheet() { }

        [Key]
        public int TimeSheetId { get; set; }
        public string TimeSheetDescription { get; set; }
        public double Time { get; set; }
        public double Overtime { get; set; }
        public DateTime TimeSheetDate { get; set; }
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

    }
}
