using ListaTelefonico.Models;
using ListaTelefonico.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ListaTelefonico.Services
{
    public class EmailServices : IEmailServices
    {
        private static List<Email> ListEmails = new List<Email>();
        public List<Email> GetAllEmails()
        {
            return ListEmails;
        }
        public List<Email> GetAllEmailsContato(Guid id)
        {
            return ListEmails.Where(e => e.IdContato == id).ToList();
        }
        public Email GetEmail(Guid id)
        {
            return ListEmails.FirstOrDefault(c => c.Id == id);
        }
        public void CreateEmail(Email Email)
        { 
            Email.Id = Guid.NewGuid();
            ListEmails.Add(Email);
        }
        public void UpdateEmail(Email Email)
        {
            var newEmail = ListEmails.First(c => c.Id == Email.Id);
            newEmail.IdContato = Email.IdContato;
            newEmail.Descricao = Email.Descricao; 
        }
        public void DeleteEmail(Guid id)
        {
            var Email = GetEmail(id);

            ListEmails.Remove(Email);
        }

    }
}
