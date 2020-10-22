using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VeriParkDemo.Models
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string CurrencyCode { get; set; }
        public Country(string _countryName,string _currencyCode)
        {
            this.CountryName = _countryName;
            this.CurrencyCode = _currencyCode;
        }
        public Country()
        {

        }
    }
}
