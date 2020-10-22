using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeriParkDemo.Models;

namespace VeriParkDemo.DemoRepository
{
    public interface IDemoCalculation
    {
        CountryBasedHoliday getHolidaysByCountry(Country country);
       
        int getBussinessDay(DateTime checkedOutDate, DateTime returnDate, int CountryId);
        Country GetCountryById(int Id);
        List<Country> GetCountries();
        public string GetCountryCurrency(int CountryId);
        double CalculatePenalty(int bussinesDayCount);
        public Penalty SavePenalty(DateTime CheckedOutDate, DateTime RetunDate, int CountryId, int BussinesDay, double PenaltyAmount);
        public List<Penalty> GetAllPenalty();
    }
}
