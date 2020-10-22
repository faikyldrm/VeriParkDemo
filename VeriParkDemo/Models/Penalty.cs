using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VeriParkDemo.Models
{
    public class Penalty
    {
        [Key]
        public int Id { get; set; }
        public DateTime CheckedOutDate { get; set; }
        public DateTime RetunDate { get; set; }
        public Country Country { get; set; }
        public int BussinesDay { get; set; }
        public double PenaltyAmount { get; set; }
        public Penalty()
        {

        }
        public Penalty(DateTime _CheckedOutDate, DateTime _RetunDate, Country _Country, int _BussinesDay, double _PenaltyAmount)
        {
            CheckedOutDate = _CheckedOutDate;
            RetunDate = _RetunDate;
            Country = _Country;
            BussinesDay = _BussinesDay;
            PenaltyAmount = _PenaltyAmount;
        }
    }
}
