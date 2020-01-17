using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS_Stoel_Vinder_Applicatie.ViewModels;
using StoelVinder.lib.BLL;
using StoelVinder.lib.DAL.Contexts;
using StoelVinder.lib.DAL.Models;

namespace NS_Stoel_Vinder_Applicatie.Controllers
{
    public class WagonController : Controller
    {
        readonly WagonRepo wagonRepo = new WagonRepo(new WagonSQL());
        readonly SeatRepo seatRepo = new SeatRepo(new SeatSQL());
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ClassView(int trainrail)
        {
            if (HttpContext.Session.GetString("Emailadres") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                HttpContext.Session.SetInt32("Spoor", trainrail);
            }

            return View();
        }

        public IActionResult FirstClass()
        {
            if (HttpContext.Session.GetString("Emailadres") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                Travelplan travel = new Travelplan(HttpContext.Session.GetString("Beginstation"), HttpContext.Session.GetString("Eindstation"), (int)HttpContext.Session.GetInt32("Spoor"));
                List<int> wagonnummers = wagonRepo.GetWagonNumber1steKlasse(travel);
                List<Seat> seats = seatRepo.GetAllSeat1steKlasse(travel);

                TrainViewModel wagonView = new TrainViewModel()
                {
                    Wagonnumber = wagonnummers,
                    Seats = seats
                    
                };

                return View(wagonView);
            }
        }

        public IActionResult SecondClass()
        {
            if (HttpContext.Session.GetString("Emailadres") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                Travelplan travel = new Travelplan(HttpContext.Session.GetString("Beginstation"), HttpContext.Session.GetString("Eindstation"), (int)HttpContext.Session.GetInt32("Spoor"));
                List<int> wagonnummers = wagonRepo.GetWagonNumber2deKlasse(travel);
                List<Seat> seats = seatRepo.GetAllSeat2deKlasse(travel);

                TrainViewModel wagonView = new TrainViewModel()
                {
                    Wagonnumber = wagonnummers,
                    Seats = seats

                };

                return View(wagonView);
            }

        }
               
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}