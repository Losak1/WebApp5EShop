using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5E.Models.View
{
    public class LoginViewModel
    {
        public string LabelTitoloLogin { get; set; }

        public string LabelEmail { get; set; }

        public string LabelPassword { get; set; }

        public string LabelButtonInvia { get; set; }

        public string MessaggioErrore { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}