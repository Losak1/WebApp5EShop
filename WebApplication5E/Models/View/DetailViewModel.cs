using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication5E.Models.Entity;

namespace WebApplication5E.Models.View
{
    public class DetailViewModel
    {
        public Prodotto Prodotto { get; set; }
        public string  MessaggioErrore { get; set; }

    }
}