using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5E.Models.View;

namespace WebApplication5E.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult SignUp()
        {
            var model = new SignUpViewModel();
            ViewBag.Title = model.Titolo = "Registrazione";
            return View(model);
        }

        [HttpPost]
        public ActionResult SignUp(SignUpViewModel model)
        {


            return View(model);
        }
    }
}