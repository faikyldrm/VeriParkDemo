using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using VeriParkDemo.Context;
using VeriParkDemo.Models;

namespace VeriParkDemo.DemoRepository
{

    public class DemoCalculation : IDemoCalculation
    {
        private readonly DemoContext _context;
        public DemoCalculation(DemoContext context)
        {
            _context = context;
        }
        public Country GetCountryById(int Id)
        {
            return _context.Country.Where(x => x.Id == Id).FirstOrDefault();
        }

        public CountryBasedHoliday getHolidaysByCountry(Country country)
        {
            return _context.CountryBasedHoliday.Where(x => x.Country.Id == country.Id).FirstOrDefault();
        }

        int getBussinessDay(DateTime checkedOutDate, DateTime returnDate, Country country)
        {

            var dayDiff = (int)(returnDate - checkedOutDate).TotalDays;
            var totalaweek = (int)(dayDiff / 7);
            var handsonDay = dayDiff % 7;

            var HolidaysDay = _context.CountryBasedHoliday.Where(x => x.Country.Id == country.Id && ((x.HolidayDate.Date >= checkedOutDate.Date) && (x.HolidayDate.Date <= returnDate.Date))).Select(x => x.HolidayDate).ToList();
            var weekends = _context.CountryBasedWeekend.Where(x => x.Country.Id == country.Id).ToList();
            var holidayCount = HolidaysDay.Count;
            var weekendCount = weekends.Count();
            var totalweekendCount = totalaweek * weekendCount;
            #region  Religional and National holidays cross with Weekend
            foreach (var holidayDay in HolidaysDay)
            {
                foreach (var weekend in weekends)
                {
                    //dini veya resmi bayramların haftasonuna gelme ihtimali
                    if (holidayDay.DayOfWeek == weekend.WeekendDay)
                    {

                        holidayCount--;
                    }
                }
            }
            #endregion
            if (totalaweek == 0)
            {
                while (checkedOutDate.Date != returnDate.Date)
                {
                    foreach (var item in weekends)
                    {
                        if (checkedOutDate.DayOfWeek == item.WeekendDay)
                        {
                            totalweekendCount++;
                        }
                    }
                    checkedOutDate = checkedOutDate.AddDays(1);

                }
            }
            else
            {
                if (handsonDay > 0)
                {
                    checkedOutDate = checkedOutDate.AddDays(totalaweek * 7);
                    while (checkedOutDate.Date != returnDate.Date)
                    {
                        //If remain days is weekend day then its not valid
                        foreach (var item in weekends)
                        {
                            if (checkedOutDate.DayOfWeek == item.WeekendDay)
                            {
                                totalweekendCount++;
                            }
                        }
                        checkedOutDate = checkedOutDate.AddDays(1);
                    }
                }
            }


            var result = dayDiff - (totalweekendCount + holidayCount);

            return result;
        }
        public int getBussinessDay(DateTime checkedOutDate, DateTime returnDate, int CountryId)
        {
            var Country = GetCountryById(CountryId);

            return getBussinessDay(checkedOutDate, returnDate, Country);
        }

        public decimal CalculatePenalty(int bussinesDayCount)
        {
            if (bussinesDayCount < 10)
            {
                return 0;
            }
            else
            {
                return (bussinesDayCount - 10) * 5;
            }
        }
        public string GetCountryCurrency(int CountryId)
        {
            var Country = GetCountryById(CountryId);
            return Country.CurrencyCode;
        }

        public List<Country> GetCountries()
        {
            return _context.Country.ToList();
        }

        bool SavePenalty(Penalty penalty)
        {
            _context.Penalty.Add(penalty);
            var result = _context.SaveChanges();
            if (result > 0)
                return true;
            else
                return false;

        }
        public Penalty SavePenalty(DateTime CheckedOutDate, DateTime RetunDate, int CountryId, int BussinesDay, decimal PenaltyAmount)
        {
            var Country = GetCountryById(CountryId);
            Penalty penalty = new Penalty(CheckedOutDate, RetunDate, Country, BussinesDay, PenaltyAmount);
            var result = SavePenalty(penalty);
            if (result == false)
                return null;

            return penalty;
        }

        public List<Penalty> GetAllPenalty()
        {
            var ListOfPenalty = _context.Penalty.Include(x=> x.Country).OrderByDescending(x=>x.Id).ToList();
            return ListOfPenalty;
        }
    }
}
