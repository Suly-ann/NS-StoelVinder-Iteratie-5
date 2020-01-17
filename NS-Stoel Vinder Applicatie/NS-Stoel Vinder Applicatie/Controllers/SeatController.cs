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
    public class SeatController : Controller
    {
        readonly SeatRepo seatRepo = new SeatRepo(new SeatSQL());
        public IActionResult Index()
        {
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
                Travelplan travelplan = new Travelplan(HttpContext.Session.GetString("Beginstation"), HttpContext.Session.GetString("Eindstation"), (int)HttpContext.Session.GetInt32("Spoor"));
               
                //int wagonnumber = (int)HttpContext.Session.GetInt32("Wagonnummer");
                List<Seat> seats = seatRepo.GetAllSeat1steKlasse(travelplan /*, wagonnumber*/);

                TrainViewModel seatView = new TrainViewModel()
                {
                    Seats = seats
                };

                return View(seatView);
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
                Travelplan travelplan = new Travelplan(HttpContext.Session.GetString("Beginstation"), HttpContext.Session.GetString("Eindstation"), (int)HttpContext.Session.GetInt32("Spoor"));

                //int wagonnumber = (int)HttpContext.Session.GetInt32("Wagonnummer");
                List<Seat> seats = seatRepo.GetAllSeat2deKlasse(travelplan /*, wagonnumber*/);

                TrainViewModel seatView = new TrainViewModel()
                {
                    Seats = seats
                };

                return View(seatView);
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}