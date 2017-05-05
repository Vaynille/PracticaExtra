using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppCS1.ViewModels
{
    public class ContactViewModel
    {
    
        [Required]
        [DisplayName("Nombre")]
        public string name { get; set; }
        [Required]
        [DisplayName("Telefono")]
        public string phone { get; set; }
        [Required]
        [DisplayName("Correo")]
        public string email { get; set; }
    }
}