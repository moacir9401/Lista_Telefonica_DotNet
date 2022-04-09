using ListaTelefonico.Models;
using ListaTelefonico.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ListaTelefonicaWeb.Controllers
{
    public class EmailController : Controller
    {
        private IEmailServices _emailServices;

        private static Guid idContato { get; set; }

        public EmailController(IEmailServices emailServices)
        {
            _emailServices = emailServices;
        }

        public IActionResult EmailIndex(Guid? id)
        {
            if (id != null)
            {
                idContato = (Guid)id;
            }

            @ViewData["idContato"] = idContato;

            var emails = _emailServices.GetAllEmails();

            return View(emails);
        }

        [HttpGet("EmailVisualizar")]
        public IActionResult EmailVisualizar(Guid id)
        {
            var email = _emailServices.GetEmail(id);

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
        public IActionResult EmailCriar(Email email)
        {
            _emailServices.CreateEmail(email);

            return RedirectToAction(nameof(EmailIndex));
        }

        [HttpGet("EmailEditar")]
        public IActionResult EmailEditar(Guid id)
        {
            var email = _emailServices.GetEmail(id);

            return View(email);
        }

        [HttpPost("EmailEditar")]
        public IActionResult EmailEditar(Email email)
        {
            _emailServices.UpdateEmail(email);

            return RedirectToAction(nameof(EmailIndex));
        }

        [HttpGet("EmailExcluir")]
        public IActionResult EmailExcluir(Guid id)
        {
            var email = _emailServices.GetEmail(id);

            return View(email);
        }

        [HttpPost("EmailExcluir")]
        public IActionResult EmailExcluir(Email email)
        {
            _emailServices.DeleteEmail(email.Id);

            return RedirectToAction(nameof(EmailIndex));
        }
    }
}
