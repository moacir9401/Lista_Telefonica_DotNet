using ListaTelefonicaWeb.Models.Context;
using ListaTelefonico.Models; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ListaTelefonicaWeb.Controllers
{
    public class EmailController : Controller
    {
        private Context _context;

        private static Guid idContato { get; set; }

        public EmailController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> EmailIndex(Guid? id)
        {
            if (id != null)
            {
                idContato = (Guid)id;
            }

            @ViewData["idContato"] = idContato;

            var emails = await _context.Emails.ToListAsync();

            return View(emails);
        }

        [HttpGet("EmailVisualizar")]
        public async Task<IActionResult> EmailVisualizar(Guid id)
        {
            var email = await _context.Emails.FirstAsync(e => e.Id == id);

            return View(email);
        }

        [HttpGet("EmailCriar")]
        public IActionResult EmailCriar(Guid idContato)
        {
            var email = new Email()
            {
                IdContato = idContato
            };

            return View(email);
        }

        [HttpPost("EmailCriar")]
        public async Task<IActionResult> EmailCriar(Email email)
        {
            await _context.Emails.AddAsync(email);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(EmailIndex));
        }

        [HttpGet("EmailEditar")]
        public async Task<IActionResult> EmailEditar(Guid id)
        {
            var email = await _context.Emails.FirstAsync(e => e.Id == id);

            return View(email);
        }

        [HttpPost("EmailEditar")]
        public async Task<IActionResult> EmailEditar(Email email)
        {
            _context.Emails.Update(email);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(EmailIndex));
        }

        [HttpGet("EmailExcluir")]
        public async Task<IActionResult> EmailExcluir(Guid id)
        {
            var email = _context.Emails.FirstAsync(e => e.Id == id);

            return View(email);
        }

        [HttpPost("EmailExcluir")]
        public async Task<IActionResult> EmailExcluir(Email email)
        {
            _context.Emails.Remove(email);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(EmailIndex));
        }
    }
}
