using ListaTelefonico.Models;
using ListaTelefonico.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ListaTelefonicaWeb.Controllers
{
    public class TelefoneController : Controller
    {
        private ITelefoneServices _telefoneServices;
        private static Guid idContato { get; set; }

        public TelefoneController(ITelefoneServices telefoneServices)
        {
            _telefoneServices = telefoneServices;
        }

        public IActionResult TelefoneIndex(Guid? id)
        {
            if (id != null)
            {
                idContato = (Guid)id;
            }

            @ViewData["idContato"] = idContato;

            var telefones = _telefoneServices.GetAllTelefones();

            return View(telefones);
        }

        [HttpGet("TelefoneVisualizar")]
        public IActionResult TelefoneVisualizar(Guid id)
        {
            var telefone = _telefoneServices.GetTelefone(id);

            return View(telefone);
        }

        [HttpGet("TelefoneCriar")]
        public IActionResult TelefoneCriar(Guid idContato)
        {
            var telefone = new Telefone()
            {
                IdContato = idContato
            };

            return View(telefone);
        }

        [HttpPost("TelefoneCriar")]
        public IActionResult TelefoneCriar(Telefone telefone)
        {
            _telefoneServices.CreateTelefone(telefone);

            return RedirectToAction(nameof(TelefoneIndex));
        }

        [HttpGet("TelefoneEditar")]
        public IActionResult TelefoneEditar(Guid id)
        {
            var telefone = _telefoneServices.GetTelefone(id);

            return View(telefone);
        }

        [HttpPost("TelefoneEditar")]
        public IActionResult TelefoneEditar(Telefone telefone)
        {
            _telefoneServices.UpdateTelefone(telefone);

            return RedirectToAction(nameof(TelefoneIndex));
        }

        [HttpGet("TelefoneExcluir")]
        public IActionResult TelefoneExcluir(Guid id)
        {
            var telefone = _telefoneServices.GetTelefone(id);

            return View(telefone);
        }

        [HttpPost("TelefoneExcluir")]
        public IActionResult TelefoneExcluir(Telefone telefone)
        {
            _telefoneServices.DeleteTelefone(telefone.Id);

            return RedirectToAction(nameof(TelefoneIndex));
        }
    }
}
