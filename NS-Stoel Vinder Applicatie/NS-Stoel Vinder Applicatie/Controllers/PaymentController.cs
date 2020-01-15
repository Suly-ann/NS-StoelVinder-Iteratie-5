using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NS_Stoel_Vinder_Applicatie.Controllers
{
    public class PaymentController : Controller
    {

        //readonly WagonRepo wagonRepo = new WagonRepo(new WagonSQL());
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Paymethode()
        {
            if (HttpContext.Session.GetString("Emailadres") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View();
            }
        }
    }
}