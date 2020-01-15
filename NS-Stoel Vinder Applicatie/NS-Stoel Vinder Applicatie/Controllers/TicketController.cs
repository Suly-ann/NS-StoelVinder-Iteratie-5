using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NS_Stoel_Vinder_Applicatie.ViewModels;
using Microsoft.AspNetCore.Http;
using StoelVinder.lib.BLL;
using StoelVinder.lib.DAL.Contexts;
using StoelVinder.lib.DAL.Models;
using NS_Stoel_Vinder_Applicatie.Converters;
using System;

namespace NS_Stoel_Vinder_Applicatie.Controllers
{
    public class TicketController : Controller
    {
        readonly TicketRepo ticketRepo = new TicketRepo(new TicketSQL());

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Ticket()
        {
            if (HttpContext.Session.GetString("Emailadres") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                string email = HttpContext.Session.GetString("Emailadres");
                string startstation = HttpContext.Session.GetString("Beginstation");
                string endstation = HttpContext.Session.GetString("Eindstation");
                //datetime time = (DateTime)HttpContext.Session.G("Tijd");
                int trainclass = (int)HttpContext.Session.GetInt32("Klasse");
                int wagon = (int)HttpContext.Session.GetInt32("Wagon");
                int stoel = (int)HttpContext.Session.GetInt32("StoelID");
                string row = HttpContext.Session.GetString("Rij");
                //List<Ticket> seats = ticketRepo.DisplayTicket(email, startstation, endstation, trainclass, wagon, stoel, row);

                //TicketViewModel ticketView = new TicketViewModel()
                //{
                //   // ID = ticketinfos
                //};

                ViewBag.Name = HttpContext.Session.GetString(email);
                ViewBag.Name = HttpContext.Session.GetString(startstation);
                ViewBag.Name = HttpContext.Session.GetString(endstation);
                ////ViewBag.Name = HttpContext.Session.GetInt32(time);
                //ViewBag.Name = (int)HttpContext.Session.GetInt32(trainclass);
                //ViewBag.Name = (int)HttpContext.Session.GetInt32(wagon);
                //ViewBag.Name = (int)HttpContext.Session.GetInt32(stoel);
                ViewBag.Name = HttpContext.Session.GetString(row);

                return View();

            }

        }

        [HttpPost]
        public IActionResult Ticket(TicketViewModel ticket)
        {

            return RedirectToAction("Travelplan", "Travelplan");
        }


        public IActionResult DownloadFile()
        {

            //    string path = AppDomain.CurrentDomain.BaseDirectory + "FolderName/";
            //    byte[] fileBytes = System.IO.File.ReadAllBytes(path + "filename.extension");
            //    string fileName = "filename.extension";
            //  return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);


            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}