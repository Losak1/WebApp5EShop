using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5E.Helpers;
using WebApplication5E.Models.Entity;
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
            ModelState.Remove("Utente.password"); //permette di rimuovere la validazione di una proprietà            
            SetSignUpViewModelLabels(model);
            if (ModelState.IsValid)
            {
                //lo commento perchè ho messo la dataannotation nella proprietà del modello
                //if (!model.Utente.IsPrivacy)
                //{
                //    model.Messaggio = "E' necessario accettare la privacy";
                //    model.IsOk = false;
                //    return View(model);
                //}

                //controllare su db che non esista una riga con questa mail
                if (DatabaseHelper.ExistsUtenteByEmail(model.Utente.Email))
                {
                    model.Messaggio = "Questa email è già presente nel database. Recupera password o cambia email";
                    model.IsOk = false;
                    return View(model);
                }
                // salvare su db e altri controlli su proprietà che non hanno data annotation
                model.Utente.Password = string.Empty;
                var id = DatabaseHelper.InsertUtente(model.Utente);
                if (id > 0)
                {
                    model.Utente.Password = CryptoHelper.HashSHA256(id + model.Password); // cifro la password
                    // update password cifrata
                    bool result = DatabaseHelper.UpdatePassword(id, model.Utente.Password);
                    if (result)
                    {
                        //TODO inviare mail all'account
                    }
                }
            }
            else
            {
                model.Messaggio = "Completa correttamente tutti i campi<br>";
                //aggiungo errori specifici prendendoli da ModelState
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        model.Messaggio += $"{error.ErrorMessage} <br>";
                    }
                }
                model.IsOk = false;
            }


            return View(model);
        }

        [HttpGet]
        public ActionResult Login()
        {
            var model = new LoginViewModel();
            SetLoginViewModelLabels(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            SetLoginViewModelLabels(model);
            if (!ModelState.IsValid)
                return View(model);
            //TODO
            //1)recuperare l'utente da database tramite email
            //exit su 1)quando non troviamo utente con quella email restituiamo errore email e password non coincidono
            var utente = DatabaseHelper.GetUtenteByEmail(model.Email);
            //2)cifrare la password invia con il loginviewmodel
            //3)confrontare la password cifrata con quella dell'utente recuperato da db
            if (utente==null || CryptoHelper.HashSHA256(utente.Id + model.Password)!=utente.Password)
            {
                model.MessaggioErrore = "Email e password non coincidono";
                return View(model);
            }
            //var passwordCifrata = CryptoHelper.HashSHA256(utente.Id + model.Password);
            //if (passwordCifrata != utente.Password)
            //{
            //    model.MessaggioErrore = "Email e password non coincidono";
            //    return View(model);
            //}

            //4) vado all'area riservata, ma prima devo mettere in sessione l'utente
            Session["UtenteLoggato"] = utente;
            //Session["prodotto"] = new Prodotto(); in sessione posso mettere anche oggetti e varibili di tipo diverso
            //Session["numeroEstratto"] = 7;
            //Session["nome"] = "Salvo";
            return RedirectToAction("Index","AreaRiservata"/*, new { idutente = utente.Id , pag = 10}*/);
        }


        private void SetLoginViewModelLabels(LoginViewModel model)
        {
            ViewBag.Title = model.LabelTitoloLogin = "Login";
            model.LabelEmail = "Indirizzo mail";
            model.LabelPassword = "Password";
            model.LabelButtonInvia = "Entra";
        }

    }
}