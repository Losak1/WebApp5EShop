using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5E.Models.Entity
{
    public class Prodotto : BaseEntity
    {
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public string Immagine { get; set; }
        public double Prezzo { get; set; }
        public int Quantita { get; set; }
    }
}