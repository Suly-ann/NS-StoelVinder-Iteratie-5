using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NS_Stoel_Vinder_Applicatie.Controllers
{
    public class ReclameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Video()
        {
            return View();
        }
    }
}