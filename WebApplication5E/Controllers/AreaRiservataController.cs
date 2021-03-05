using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5E.Filters;
using WebApplication5E.Models.Entity;
using WebApplication5E.Models.View;

namespace WebApplication5E.Controllers
{
    public class AreaRiservataController : Controller
    {
        // GET: AreaRiservata
        //[CustomActionFilter]
        [HttpGet]
        public ActionResult Index()
        {
            var utente = (Utente) Session["UtenteLoggato"];
            if (utente == null)
                return RedirectToAction("Login", "Account");
            var model = new ProfiloViewModel();
            SetProfiloViewModelLabels(model);
            model.Utente = utente;
            return View(model);
        }

        private void SetProfiloViewModelLabels(ProfiloViewModel model)
        {
            ViewBag.Title = model.LabelTitolo = "Profilo";
            model.LabelConfermaPassword = "Conferma password";
            model.LabelEmail = "Indirizzo mail";
            model.LabelNome = "Nickname";
            model.LabelPassword = "Password";
            model.BtnAggiorna= "Aggiorna";
        }

        //public new RedirectToRouteResult RedirectToAction(string action, string controller)
        //{
        //    return base.RedirectToAction(action, controller);
        //}
    }
}