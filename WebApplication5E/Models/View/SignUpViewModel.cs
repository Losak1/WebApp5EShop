using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5E.Models.View
{
    public class SignUpViewModel
    {
        public string Titolo { get; set; }


        public string Email { get; set; }
        public string Password { get; set; }

        public string ConfermaPassword { get; set; }

        public string Nome { get; set; }
    }
}