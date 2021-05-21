using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegaITPraksa.Models
{
    public class TimeSheet
    {
        public TimeSheet() { }

        public Guid TimeSheetId { get; set; }
        public string TimeSheetDescription { get; set; }
        public double Time { get; set; }
        public double Overtime { get; set; }
        public DateTime TimeSheetDate { get; set; }
        public virtual Client Client { get; set; }
        public virtual Project Project { get; set; }
        public virtual Category Category { get; set; }

    }
}
