using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VegaITPraksa.DTO
{
    public class TimeSheetDTO
    {

        public int TimeSheetId { get; set; }
        [Required]
        public string TimeSheetDescription { get; set; }
        [Required]
        public double Time { get; set; }
        [Required]
        public double Overtime { get; set; }
        [Required]
        public DateTime TimeSheetDate { get; set; }
        [Required]
        public int ClientId { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public int CategoryId { get; set; }

        public TimeSheetDTO()
        {
        }
    }
}
