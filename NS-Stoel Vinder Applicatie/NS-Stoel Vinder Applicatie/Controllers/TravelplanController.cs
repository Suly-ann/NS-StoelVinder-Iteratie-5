using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using StoelVinder.lib.BLL;
using StoelVinder.lib.DAL.Contexts;
using NS_Stoel_Vinder_Applicatie.ViewModels;
using StoelVinder.lib.DAL.Models;

namespace NS_Stoel_Vinder_Applicatie.Controllers
{
    public class TravelplanController : Controller
    {
        readonly TravelplanRepo travelplanRepo = new TravelplanRepo(new TravelplanSQL());

        public IActionResult Index()
        {
            return View();
        }

        private void ReadCookie(string name)
        {
            ViewBag.cookievalue = Request.Cookies[name].ToString();
        }

        [HttpGet]
        public IActionResult Travelplan()
        {

            if (HttpContext.Session.GetString("Emailadres") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ReadCookie("nsstoelvinder");
                List<Station> stations = travelplanRepo.GetStationsOnly();

                TravelplanViewModel travelplanView = new TravelplanViewModel()
                {
                    Stations = stations
                };
                return View(travelplanView);
            }
        }

        [HttpPost]
        public IActionResult Travelplan(TravelplanViewModel t)
        {
            HttpContext.Session.SetString("Beginstation", t.Beginstation);
            HttpContext.Session.SetString("Eindstation", t.Eindstation);
            return RedirectToAction("Times", "Travelplan");
        }

        [HttpGet]
        public IActionResult Times()
        {
            if (HttpContext.Session.GetString("Emailadres") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                Travelplan travelplan = new Travelplan(HttpContext.Session.GetString("Beginstation"), HttpContext.Session.GetString("Eindstation"));
                List<Travelplan> tvt = travelplanRepo.GetTravelplans(travelplan);
                TimesViewModel timesViewModel = new TimesViewModel
                {
                    Trt = tvt
                };
                return View(timesViewModel);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
    }
}