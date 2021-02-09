using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication5E.Models.Entity;

namespace WebApplication5E.Models.View
{
    public class SignUpViewModel
    {
        public string LabelTitolo { get; set; }
        public string LabelEmail { get; set; }
        public string LabelPassword { get; set; }
        public string LabelConfermaPassword { get; set; }
        public string LabelNome { get; set; }
        public string LabelPrivacy { get; set; }

        public string Messaggio { get; set; }
        public bool IsOk { get; set; }

        public string BtnRegistrazione { get; set; }


        public Utente Utente { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "Le password non coincidono")]
        public string ConfermaPassword { get; set; }

    }
}