using ListaTelefonico.Models;
using ListaTelefonico.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ListaTelefonicaWeb.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoServices _contatoServices;

        public ContatoController(IContatoServices contatoServices)
        {
            _contatoServices = contatoServices;
        }
         
        public IActionResult ContatoIndex()
        {
            if (!_contatoServices.GetAllContatos().Any())
            {

                _contatoServices.CreateContato(new Contato()
                {
                    Nome = "moacir ",
                    Sobrenome = "afonso",
                    Cargo = "c#",
                    Empresa = "agil",
                    Apelido = "moacir aa"
                });

                _contatoServices.CreateContato(new Contato()
                {
                    Nome = "gustavo",
                    Sobrenome = "henrique",
                    Cargo = "angula",
                    Empresa = "d&t"
                }); 
            }

            var contatos = _contatoServices.GetAllContatos();

            return View(contatos);
        }

        [HttpGet("ContatoVisualizar")]
        public IActionResult ContatoVisualizar(Guid id)
        {
            var contato = _contatoServices.GetContato(id); 
            return View(contato);
        }

        [HttpGet("ContatoCriar")]
        public IActionResult ContatoCriar()
        {
            return View();
        }

        [HttpPost("ContatoCriar")]
        public IActionResult ContatoCriar(Contato contato)
        {
            _contatoServices.CreateContato(contato);

            return RedirectToAction(nameof(ContatoIndex));
        }

        [HttpGet("ContatoEditar")]
        public IActionResult ContatoEditar(Guid id)
        {
            var contato = _contatoServices.GetContato(id);

            return View(contato);
        }

        [HttpPost("ContatoEditar")]
        public IActionResult ContatoEditar(Contato contato)
        {
            _contatoServices.UpdateContato(contato);

            return RedirectToAction(nameof(ContatoIndex));
        }

        [HttpGet("ContatoExcluir")]
        public IActionResult ContatoExcluir(Guid id)
        {
            var contato = _contatoServices.GetContato(id);

            return View(contato);
        }

        [HttpPost("ContatoExcluir")]
        public IActionResult ContatoExcluir(Contato contato)
        {
            _contatoServices.DeleteContato(contato.Id);

            return RedirectToAction(nameof(ContatoIndex));
        }
    }
}
