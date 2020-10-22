using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeriParkDemo.Models;

namespace VeriParkDemo.Context
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options) : base(options)
        {

        }
        public DbSet<Penalty> Penalty { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<CountryBasedHoliday> CountryBasedHoliday { get; set; }
        public DbSet<CountryBasedWeekend> CountryBasedWeekend { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           
        }
       

    }
}
