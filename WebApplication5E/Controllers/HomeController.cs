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
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            List<Prodotto> prodotti = new List<Prodotto>();// DatabaseHelper.GetAllProdotti();
            //foreach (var p in prodotti)
            //{
            //    p.Immagine = PathHelper.GetProdottoImagePath(p);
            //}
            var model = new IndexViewModel()
            {
                Prodotti = prodotti
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var prodotto = DatabaseHelper.GetProdottoById(id);
            //prodotto.Immagine = PathHelper.GetProdottoImagePath(prodotto);
            var model = new DetailViewModel()
            {
                Prodotto = prodotto
            };
            if (prodotto == null)
            {
                model.MessaggioErrore = "Prodotto non esistente";
                ViewBag.Title = "Errore";
            }
            else
            {
                ViewBag.Title = prodotto.Nome;
            }


            return View(model);
        }

    }
}