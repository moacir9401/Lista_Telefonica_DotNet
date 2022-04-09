using ListaTelefonico.Models;
using System;
using System.Collections.Generic;

namespace ListaTelefonico.Services.Interface
{
    public interface IEmailServices
    {
        List<Email> GetAllEmails();
        List<Email> GetAllEmailsContato(Guid id);
        Email GetEmail(Guid id);
        void CreateEmail(Email contato);
        void UpdateEmail(Email contato);
        void DeleteEmail(Guid id);
    }
} 