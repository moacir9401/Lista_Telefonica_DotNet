using System;
using System.ComponentModel.DataAnnotations;

namespace ListaTelefonico.Models
{
    public class Telefone : Base
    {
        public Guid IdContato { get; set; }

        [Required(ErrorMessage = "Informe o seu Número")]
        [Display(Name = "Número")]
        [DisplayFormat(DataFormatString = "\\(##\\) #####\\-####")]
        [StringLength(maximumLength: 14, MinimumLength = 14, ErrorMessage = "Telefone invalido !")]
        public string Numero { get; set; }
    }
}
