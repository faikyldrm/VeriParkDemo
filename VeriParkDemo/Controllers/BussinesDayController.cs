using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VeriParkDemo.DemoRepository;
using VeriParkDemo.Models;

namespace VeriParkDemo.Controllers
{
    public class BussinesDayController : Controller
    {
        IDemoCalculation _context;

        public BussinesDayController(IDemoCalculation context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var Countries = _context.GetCountries();

            ViewBag.Countries = new SelectList(Countries, "Id", "CountryName");

            return View("View");
        }
        [HttpPost]
        public IActionResult CalculateBussinesDay(DateTime CheckedOutDate, DateTime RetunDate, int Countries)
        {
            if (CheckedOutDate >= RetunDate)
                return NotFound("Return date must be greater then checkout date");
            if (Countries == 0)
                return NotFound("Country must be Selected");

            var calculetedBussinesDay = _context.getBussinessDay(CheckedOutDate, RetunDate, Countries);
            var penaltyAmount = _context.CalculatePenalty(calculetedBussinesDay);
            
            var saveResult = _context.SavePenalty(CheckedOutDate, RetunDate, Countries, calculetedBussinesDay, penaltyAmount);
            if (saveResult == null)
                return NotFound("Some error happend while saving the record. Please check the Db");
            
            return View(saveResult);
        }
        public IActionResult GetAllCalcs()
        {
            var allCalcs = _context.GetAllPenalty();
            if (allCalcs.Count == 0)
                return NotFound("There is no Record the show");
            return View(allCalcs);
        }
    }

}
