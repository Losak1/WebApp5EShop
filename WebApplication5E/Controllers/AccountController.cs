﻿using System;
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
            model.LabelPrivacy = "Accetta la <a href=\"\"> privacy</a>";
        }

        [HttpPost]
        public ActionResult SignUp(SignUpViewModel model)
        {
            model.Utente.Password = model.Password;
            SetSignUpViewModelLabels(model);
            if (ModelState.IsValid)
            {
                if (!model.Utente.IsPrivacy)
                {
                    model.Messaggio = "E' necessario accettare la privacy";
                    model.IsOk = false;
                    return View(model);
                }
                //TODO controllare su db che non esista una riga con questa mail
                //TODO salvare su db e altri controlli su proprietà che non hanno data annotation
            }
            else
            {
                model.Messaggio = "Completa correttamente tutti i campi";
                model.IsOk = false;
            }

     
            return View(model);
        }
    }
}