using ListaTelefonico.Models;
using System;
using System.Collections.Generic;

namespace ListaTelefonico.Services.Interface
{
    public interface IContatoServices
    { 
        List<Contato> GetAllContatos();
        Contato GetContato(Guid id);
        Guid CreateContato(Contato contato);
        void UpdateContato(Contato contato);
        void DeleteContato(Guid id);
    }
}
