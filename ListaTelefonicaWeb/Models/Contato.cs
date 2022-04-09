using System;
using System.ComponentModel.DataAnnotations;

namespace ListaTelefonico.Models
{
    public class Contato : Base
    {
        [Required(ErrorMessage = "Informe o seu apelido")]
        public string Apelido { get; set; }
        [Required(ErrorMessage = "Informe o seu nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o seu sobrenome")]
        public string Sobrenome { get; set; }

        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        [Required(ErrorMessage = "Informe o seu data de nascimento")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "Informe o nome da sua empresa")]
        public string Empresa { get; set; }
        [Required(ErrorMessage = "Informe o seu cargo")]
        public string Cargo { get; set; }

        [Display(Name = "Observações")] 
        public string Observacoes { get; set; }
    }
}
