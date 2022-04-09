using ListaTelefonico.Models;
using ListaTelefonico.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ListaTelefonicaWeb.Controllers
{
    public class EnderecoController : Controller
    {
        private IEnderecoServices _enderecoServices;
        private static Guid idContato { get; set; }

        public EnderecoController(IEnderecoServices enderecoServices)
        {
            _enderecoServices = enderecoServices;
        }

        public IActionResult EnderecoIndex(Guid? id)
        {
            if (id != null)
            {
                idContato = (Guid)id;
            }

            @ViewData["idContato"] = idContato;

            var enderecos = _enderecoServices.GetAllEnderecos();

            return View(enderecos);
        }

        [HttpGet("EnderecoVisualizar")]
        public IActionResult EnderecoVisualizar(Guid id)
        {
            var endereco = _enderecoServices.GetEndereco(id);

            return View(endereco);
        }

        [HttpGet("EnderecoCriar")]
        public IActionResult EnderecoCriar(Guid idContato)
        {
            var endereco = new Endereco()
            {
                IdContato = idContato
            };

            return View(endereco);
        }

        [HttpPost("EnderecoCriar")]
        public IActionResult EnderecoCriar(Endereco endereco)
        {
            _enderecoServices.CreateEndereco(endereco);

            return RedirectToAction(nameof(EnderecoIndex));
        }

        [HttpGet("EnderecoEditar")]
        public IActionResult EnderecoEditar(Guid id)
        {
            var endereco = _enderecoServices.GetEndereco(id);

            return View(endereco);
        }

        [HttpPost("EnderecoEditar")]
        public IActionResult EnderecoEditar(Endereco endereco)
        {
            _enderecoServices.UpdateEndereco(endereco);

            return RedirectToAction(nameof(EnderecoIndex));
        }

        [HttpGet("EnderecoExcluir")]
        public IActionResult EnderecoExcluir(Guid id)
        {
            var endereco = _enderecoServices.GetEndereco(id);

            return View(endereco);
        }

        [HttpPost("EnderecoExcluir")]
        public IActionResult EnderecoExcluir(Endereco endereco)
        {
            _enderecoServices.DeleteEndereco(endereco.Id);

            return RedirectToAction(nameof(EnderecoIndex));
        }
    }
}
