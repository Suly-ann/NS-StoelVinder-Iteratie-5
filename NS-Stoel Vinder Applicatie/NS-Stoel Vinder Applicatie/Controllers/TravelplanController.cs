using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NS_Stoel_Vinder_Applicatie;
using Microsoft.AspNetCore.Http;
using StoelVinder.lib.BLL;
using StoelVinder.lib.DAL.Contexts;
using StoelVinder.lib.DAL;
using NS_Stoel_Vinder_Applicatie.ViewModels;
using StoelVinder.lib.DAL.Models;
using Microsoft.AspNetCore.Authorization;

namespace NS_Stoel_Vinder_Applicatie.Controllers
{
    public class TravelplanController : Controller
    {
        readonly TravelplanRepo travelplanRepo = new TravelplanRepo(new TravelplanSQL());
        readonly HistoryRepo historynRepo = new HistoryRepo(new HistorySQL());

        public IActionResult Index()
        {
            return View();
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
            //TempData["beginStation"] = t.Beginstation;
            //TempData["eindStation"] = t.Eindstation;

            return RedirectToAction("Times", "Travelplan");

        }

        [HttpGet]
        public IActionResult Times(TimesViewModel times)
        {
            if (HttpContext.Session.GetString("Emailadres") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                List<Travelplan> tvt = travelplanRepo.GetTravelplans(HttpContext.Session.GetString("Beginstation"), HttpContext.Session.GetString("Eindstation"));
                TimesViewModel timesViewModel = new TimesViewModel()
                {
                    Trt = tvt
                };
                return View(timesViewModel);
            }
        }

        public IActionResult History(HistoryViewModel history)
        {
            if (HttpContext.Session.GetString("Emailadres") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View(history);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void ReadCookie(string name)
        {
            ViewBag.cookievalue = Request.Cookies[name].ToString();
        }
    }
}