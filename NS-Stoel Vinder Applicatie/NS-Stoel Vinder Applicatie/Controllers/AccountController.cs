using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NS_Stoel_Vinder_Applicatie.Converter;
using Microsoft.AspNetCore.Http;
using StoelVinder.lib.BLL;
using StoelVinder.lib.DAL.Contexts;
using StoelVinder.lib.DAL.Models;
using NS_Stoel_Vinder_Applicatie.ViewModels;
using NS_Stoel_Vinder_Applicatie.Converters;

namespace NS_Stoel_Vinder_Applicatie.Controllers
{
    public class AccountController : Controller
    {
        readonly AccountRepo accountRepo = new AccountRepo(new AccountSQL());

        public IActionResult Index()
        {

            string email = Request.Cookies["nsstoelvinder"];

            ViewData["Emailadres"] = email;

            return View();
        }

        [HttpPost]
        public IActionResult Index(InlogViewModel inlog)
        {
            if (ModelState.IsValid)
            {


            }
            return View();
        }

        private void ReadCookie(string name)
        {
            var cookie = Request.Cookies[name].ToString();
            ViewBag.cookievalue = int.Parse(cookie);

        }

        private void WriteCookie(string cookiename, string cookievalues, bool remember)
        {
            CookieOptions cookies = new CookieOptions();
            cookies.Expires = DateTime.Now.AddDays(1);
            if (remember)
            {
                Response.Cookies.Append(cookiename, cookievalues, cookies);
            }
            else
            {
                Response.Cookies.Append(cookiename, cookievalues);
            }

        }

        private void DeleteCookie(string name)
        {
            if (Request.Cookies[name] != null)
            {
                Response.Cookies.Delete(name);
            }

        }

        //Register GET
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        //Register POST
        [HttpPost]
        public IActionResult Registration(RegistrationViewModel registration)
        {
            AccountViewModelConverter avc = new AccountViewModelConverter();
            RegistrationViewModelConverter rp = new RegistrationViewModelConverter();
            if (ModelState.IsValid)
            {
                Account reg = avc.viewModeltoAccount(registration);
                if (accountRepo.CheckIfEmailExist(reg.Email) == true)
                {
                    ModelState.AddModelError("Email", "Dit e-mailadres bestaat al");
                    return View("Registration");
                }

                else
                {
                    accountRepo.Registration(rp.viewModeltoAccount(registration));
                    CookieOptions option = new CookieOptions();
                    option.Expires = DateTime.Now.AddMinutes(30);
                    Response.Cookies.Append("nsstoelvinder", reg.Email, option);
                    return RedirectToAction("Travelplan", "Travelplan");
                }

            }
            return View(registration);
        }


        //Login GET
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //Login POST
        [HttpPost]
        public IActionResult Login(InlogViewModel login)
        {
            
            AccountViewModelConverter avc = new AccountViewModelConverter();
            InlogViewModelConverter inl = new InlogViewModelConverter();
            if (ModelState.IsValid)
            {
                Account reg = avc.accountToViewmodel(login);
                if (accountRepo.CheckEmailAndPassword(reg.Email, reg.Password) == true)
                {
                    CookieOptions option = new CookieOptions();
                    option.Expires = DateTime.Now.AddMinutes(30);
                    Response.Cookies.Append("nsstoelvinder", reg.Email, option);
                    HttpContext.Session.SetString("Emailadres", login.Email);
                    return RedirectToAction("Travelplan", "Travelplan");
                }

                else
                {
                    ModelState.AddModelError("Email", "Foute e-mailadres of wachtwoord");
                    accountRepo.LogintoTravelplan(inl.viewModeltoAccount(login));
                    return View("Login");
                }

            }
            return View(login);
        }

        //Logout GET
        [HttpGet]
        public IActionResult Logout()
        {
            DeleteCookie("nsstoelvinder");
            return RedirectToAction("Login", "Account");
        }

        public void ValidationMessage(string key, string alert, string value)
        {
            try
            {
                TempData.Remove(key);
                TempData.Add(key, value);
                TempData.Add("alertType", alert);
            }
            catch
            {
                Debug.WriteLine("TempDataMessage Error");
            }

        }

        
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(DeleteViewModel del)
        {
            AccountViewModelConverter avc = new AccountViewModelConverter();
            DeleteViewModelConverter dvt = new DeleteViewModelConverter();

            if (ModelState.IsValid)
            {
                Account reg = avc.accountToDeleteViewmodel(del);
                if (accountRepo.CheckIfEmailExist(reg.Email) == true)
                {
                    accountRepo.DeleteAccount(dvt.viewModeltoAccount(del));                    
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("Email", "Dit e-mailadres bestaat niet");
                    return View("Delete");
                }

            }

            return View(del);

        }
       
        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }

       
        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel reset)
        {

            AccountViewModelConverter avc = new AccountViewModelConverter();
            ResetPasswordViewModelConverter cvt = new ResetPasswordViewModelConverter();

            if (ModelState.IsValid)
            {
                Account reg = avc.accountToResetViewmodel(reset);
                if (accountRepo.CheckIfEmailExist(reg.Email) == true)
                {
                    accountRepo.ResetPassword(cvt.viewModeltoAccount(reset));
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("Email", "Dit e-mailadres bestaat niet");
                    return View("ResetPassword");
                }

            }

            return View(reset);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
