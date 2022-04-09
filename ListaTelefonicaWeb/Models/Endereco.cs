using System;
using System.ComponentModel.DataAnnotations;

namespace ListaTelefonico.Models
{
    public class Endereco : Base
    {
        public Guid IdContato { get; set; }
        [Required(ErrorMessage = "Informe o seu logradouro")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "Informe o seu número")]
        public int Numero { get; set; }
        [Required(ErrorMessage = "Informe o seu bairro")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Informe o seu cidade")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Informe o seu UF")]
        public string UF { get; set; }

        [Required(ErrorMessage = "Informe o seu CEP")]
        [DisplayFormat(DataFormatString = "#####-###")]
        public string CEP { get; set; }
    }
}
