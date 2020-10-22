using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeriParkDemo.Models
{
    public class CountryBasedHoliday
    {
        public int Id { get; set; }
        public Country Country { get; set; }
        public DateTime HolidayDate { get; set; }
        public string  HolidayType { get; set; }//National /Or Religinioal

        public CountryBasedHoliday()
        {

        }
        public CountryBasedHoliday(Country _country,DateTime _holidayDate,string _holidayType)
        {
            this.Country = _country;
            this.HolidayDate = _holidayDate;
            this.HolidayType = _holidayType;
        }
      

    }
}
