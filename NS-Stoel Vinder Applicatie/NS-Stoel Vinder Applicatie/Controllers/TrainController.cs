using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NS_Stoel_Vinder_Applicatie.ViewModels;

namespace NS_Stoel_Vinder_Applicatie.Controllers
{
    public class TrainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Train()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}