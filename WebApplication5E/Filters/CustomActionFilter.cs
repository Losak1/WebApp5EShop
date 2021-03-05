using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5E.Controllers;
using WebApplication5E.Models.Entity;

namespace WebApplication5E.Filters
{
    public class CustomActionFilter : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
        //    var utente = (Utente)filterContext.HttpContext.Session["UtenteLoggato"];
        //    if (utente == null)
        //        filterContext.Result = ((AreaRiservataController)filterContext.Controller).RedirectToAction("Login", "Account");
        }
    }
}