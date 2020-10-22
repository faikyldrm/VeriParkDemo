using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VeriParkDemo.Models
{
    public class CountryBasedWeekend
    {
        // Ülke bazında ayrıca tablo tutmamın nedeni 3 gün hafta sonu yapan ülkeler var.
        [Key]
        public int Id { get; set; }
        public Country Country { get; set; }
        public DayOfWeek WeekendDay { get; set; }
    }
}
