using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5E.Models.Entity
{
    public class Utente : BaseEntity
    {

        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress] //usiamo la mail anche come username
        public string Email { get; set; }
        public bool IsPrivacy { get; set; }
    }
}