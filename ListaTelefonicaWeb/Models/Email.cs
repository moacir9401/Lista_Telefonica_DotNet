using System;
using System.ComponentModel.DataAnnotations;

namespace ListaTelefonico.Models
{
    public class Email:Base
    { 
        public Guid IdContato { get; set; }

        [Display(Name ="E-mail")]
        [Required(ErrorMessage = "Informe o seu email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Descricao { get; set; }
    }
}
