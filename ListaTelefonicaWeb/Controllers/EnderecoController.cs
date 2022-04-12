using ListaTelefonicaWeb.Models.Context;
using ListaTelefonico.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ListaTelefonicaWeb.Controllers
{
    public class EnderecoController : Controller
    {
        private Context _context;
        private static Guid idContato { get; set; }

        public EnderecoController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> EnderecoIndex(Guid? id)
        {
            if (id != null)
            {
                idContato = (Guid)id;
            }

            @ViewData["idContato"] = idContato;

            var enderecos = await _context.Enderecos.ToListAsync();

            return View(enderecos);
        }

        [HttpGet("EnderecoVisualizar")]
        public async Task<IActionResult> EnderecoVisualizar(Guid id)
        {
            var endereco = _context.Enderecos.FirstAsync(e => e.Id == id);

            return View(endereco);
        }

        [HttpGet("EnderecoCriar")]
        public async Task<IActionResult> EnderecoCriar(Guid idContato)
        {
            var endereco = new Endereco()
            {
                IdContato = idContato
            };

            return View(endereco);
        }

        [HttpPost("EnderecoCriar")]
        public async Task<IActionResult> EnderecoCriar(Endereco endereco)
        {
            await _context.Enderecos.AddAsync(endereco);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(EnderecoIndex));
        }

        [HttpGet("EnderecoEditar")]
        public async Task<IActionResult> EnderecoEditar(Guid id)
        {
            var endereco = _context.Enderecos.FirstAsync(e => e.Id == id);

            return View(endereco);
        }

        [HttpPost("EnderecoEditar")]
        public async Task<IActionResult> EnderecoEditar(Endereco endereco)
        {
            _context.Enderecos.Update(endereco);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(EnderecoIndex));
        }

        [HttpGet("EnderecoExcluir")]
        public async Task<IActionResult> EnderecoExcluir(Guid id)
        {
            var endereco = await _context.Enderecos.FirstAsync(e => e.Id == id);
            await _context.SaveChangesAsync();

            return View(endereco);
        }

        [HttpPost("EnderecoExcluir")]
        public async Task<IActionResult> EnderecoExcluir(Endereco endereco)
        {
            _context.Enderecos.Remove(endereco);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(EnderecoIndex));
        }
    }
}
