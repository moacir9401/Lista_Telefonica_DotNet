using ListaTelefonicaWeb.Models.Context;
using ListaTelefonico.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ListaTelefonicaWeb.Controllers
{
    public class ContatoController : Controller
    {
        private readonly Context _context;

        public ContatoController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> ContatoIndex()
        {
            if (!_context.Contatos.Any())
            {

                _context.Contatos.Add(new Contato()
                {
                    Nome = "moacir ",
                    Sobrenome = "afonso",
                    Cargo = "c#",
                    Empresa = "agil",
                    Apelido = "moacir aa"
                });

                _context.Contatos.Add(new Contato()
                {
                    Nome = "gustavo",
                    Sobrenome = "henrique",
                    Cargo = "angula",
                    Empresa = "d&t"
                });

                await _context.SaveChangesAsync();
            }

            var contatos = await _context.Contatos.ToListAsync();

            return View(contatos);
        }

        [HttpGet("ContatoVisualizar")]
        public async Task<IActionResult> ContatoVisualizar(Guid id)
        {
            var contato = _context.Contatos.FindAsync(id);
            return View(contato);
        }

        [HttpGet("ContatoCriar")]
        public IActionResult ContatoCriar()
        {
            return View();
        }

        [HttpPost("ContatoCriar")]
        public async Task<IActionResult> ContatoCriar(Contato contato)
        {
            await _context.Contatos.AddAsync(contato);
            _context.SaveChanges();

            return RedirectToAction(nameof(ContatoIndex));
        }

        [HttpGet("ContatoEditar")]
        public async Task<IActionResult> ContatoEditar(Guid id)
        {
            var contato = await _context.Contatos.FirstAsync(c => c.Id == id);
            _context.SaveChanges();

            return View(contato);
        }

        [HttpPost("ContatoEditar")]
        public async Task<IActionResult> ContatoEditar(Contato contato)
        {
            _context.Contatos.Update(contato);
            _context.SaveChanges();

            return RedirectToAction(nameof(ContatoIndex));
        }

        [HttpGet("ContatoExcluir")]
        public async Task<IActionResult> ContatoExcluir(Guid id)
        {
            var contato = _context.Contatos.FirstAsync(c => c.Id == id);

            return View(contato);
        }

        [HttpPost("ContatoExcluir")]
        public async Task<IActionResult> ContatoExcluir(Contato contato)
        {
            _context.Contatos.Remove(contato);
            _context.SaveChanges();

            return RedirectToAction(nameof(ContatoIndex));
        }
    }
}
