using ListaTelefonico.Models;
using System;
using System.Collections.Generic;

namespace ListaTelefonico.Services.Interface
{
    public interface ITelefoneServices
    { 
        List<Telefone> GetAllTelefones();
        List<Telefone> GetAllTelefonesContato(Guid id);
        Telefone GetTelefone(Guid id);
        void CreateTelefone(Telefone contato);
        void UpdateTelefone(Telefone contato);
        void DeleteTelefone(Guid id);
    }
}
