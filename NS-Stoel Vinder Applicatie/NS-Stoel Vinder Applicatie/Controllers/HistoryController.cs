using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS_Stoel_Vinder_Applicatie.ViewModels;

namespace NS_Stoel_Vinder_Applicatie.Controllers
{
    public class HistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }
    }
}
