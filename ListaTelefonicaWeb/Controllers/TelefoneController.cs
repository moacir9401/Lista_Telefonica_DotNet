using ListaTelefonicaWeb.Models.Context;
using ListaTelefonico.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ListaTelefonicaWeb.Controllers
{
    public class TelefoneController : Controller
    {
        private Context _context;
        private static Guid idContato { get; set; }

        public TelefoneController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> TelefoneIndex(Guid? id)
        {
            if (id != null)
            {
                idContato = (Guid)id;
            }

            @ViewData["idContato"] = idContato;

            var telefones = await _context.Telefones.ToListAsync();

            return View(telefones);
        }

        [HttpGet("TelefoneVisualizar")]
        public async Task<IActionResult> TelefoneVisualizar(Guid id)
        {
            var telefone = await _context.Telefones.FirstAsync(t => t.Id == id);

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
        public async Task<IActionResult> TelefoneCriar(Telefone telefone)
        {
            await _context.Telefones.AddAsync(telefone);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(TelefoneIndex));
        }

        [HttpGet("TelefoneEditar")]
        public async Task<IActionResult> TelefoneEditar(Guid id)
        {
            var telefone = await _context.Telefones.FirstAsync(t => t.Id == id);

            return View(telefone);
        }

        [HttpPost("TelefoneEditar")]
        public async Task<IActionResult> TelefoneEditar(Telefone telefone)
        {
            _context.Telefones.Update(telefone);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(TelefoneIndex));
        }

        [HttpGet("TelefoneExcluir")]
        public IActionResult TelefoneExcluir(Guid id)
        {
            var telefone = _context.Telefones.FirstAsync(t => t.Id == id);

            return View(telefone);
        }

        [HttpPost("TelefoneExcluir")]
        public async Task<IActionResult> TelefoneExcluir(Telefone telefone)
        {
            _context.Telefones.Remove(telefone);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(TelefoneIndex));
        }
    }
}
