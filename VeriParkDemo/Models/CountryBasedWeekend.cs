using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VeriParkDemo.Models
{
    public class CountryBasedWeekend
    {
        [Key]
        public int Id { get; set; }
        public Country Country { get; set; }
        public DayOfWeek WeekendDay { get; set; }
    }
}
