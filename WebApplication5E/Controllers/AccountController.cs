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
            SetSignUpViewModelLabels(model);
            return View(model);
        }

        private void SetSignUpViewModelLabels(SignUpViewModel model)
        {
            ViewBag.Title = model.LabelTitolo = "Registrazione";
            model.LabelConfermaPassword = "Conferma password";
            model.LabelEmail = "Indirizzo mail";
            model.LabelNome = "Nickname";
            model.LabelPassword = "Password";
            model.BtnRegistrazione = "Registrati";
        }

        [HttpPost]
        public ActionResult SignUp(SignUpViewModel model)
        {

            SetSignUpViewModelLabels(model);
            return View(model);
        }
    }
}