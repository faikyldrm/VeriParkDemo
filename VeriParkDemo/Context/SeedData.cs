using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeriParkDemo.Context
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<DemoContext>();
            context.Database.EnsureCreated();
            #region Country
            if (!context.Country.Any())
            {
                context.Country.Add(entity: new Models.Country { CountryName = "Turkiye", CurrencyCode = "TRY"  });
                context.Country.Add(entity: new Models.Country { CountryName = "Amerika", CurrencyCode = "USD" });
                context.SaveChanges();
            }
            #endregion

            #region Formal Holidays
            if (!context.CountryBasedHoliday.Any())
            {
                context.CountryBasedHoliday.Add(entity: new Models.CountryBasedHoliday
                {
                    
                    Country = context.Country.FirstOrDefault(),
                    HolidayDate = DateTime.Parse("01/01/2020"),
                    HolidayType = "Formal"

                });
                context.CountryBasedHoliday.Add(entity: new Models.CountryBasedHoliday
                {
 
                    Country = context.Country.FirstOrDefault(),
                    HolidayDate = DateTime.Parse("29/10/2020"),
                    HolidayType = "Formal"

                });
                context.CountryBasedHoliday.Add(entity: new Models.CountryBasedHoliday
                {
                    
                    Country = context.Country.FirstOrDefault(),
                    HolidayDate = DateTime.Parse("10/11/2020"),
                    HolidayType = "Formal"

                });
                context.CountryBasedHoliday.Add(entity: new Models.CountryBasedHoliday
                {
                    
                    Country = context.Country.Skip(1).Take(1).FirstOrDefault(),
                    HolidayDate = DateTime.Parse("01/01/2020"),
                    HolidayType = "Formal"

                });
                context.CountryBasedHoliday.Add(entity: new Models.CountryBasedHoliday
                {
                    
                    Country = context.Country.Skip(1).Take(1).FirstOrDefault(),
                    HolidayDate = DateTime.Parse("22/11/2020"),
                    HolidayType = "Formal"

                });
                context.CountryBasedHoliday.Add(entity: new Models.CountryBasedHoliday
                {
                    
                    Country = context.Country.Skip(1).Take(1).FirstOrDefault(),
                    HolidayDate = DateTime.Parse("31/10/2020"),
                    HolidayType = "Formal"

                });
                context.SaveChanges();
            }
            #endregion

            #region Weekends
            if (!context.CountryBasedWeekend.Any())
            {
                context.CountryBasedWeekend.Add(entity: new Models.CountryBasedWeekend
                {
                  
                    Country = context.Country.FirstOrDefault(),
                    WeekendDay = DayOfWeek.Saturday
                });
                context.CountryBasedWeekend.Add(entity: new Models.CountryBasedWeekend
                {
                    
                    Country = context.Country.FirstOrDefault(),
                    WeekendDay = DayOfWeek.Sunday
                });
                context.CountryBasedWeekend.Add(entity: new Models.CountryBasedWeekend
                {
                    
                    Country = context.Country.Skip(1).Take(1).FirstOrDefault(),
                    WeekendDay = DayOfWeek.Monday
                });
                context.CountryBasedWeekend.Add(entity: new Models.CountryBasedWeekend
                {
                    
                    Country = context.Country.Skip(1).Take(1).FirstOrDefault(),
                    WeekendDay = DayOfWeek.Tuesday
                });
                context.SaveChanges();
            }
            #endregion

        }
    }
}

