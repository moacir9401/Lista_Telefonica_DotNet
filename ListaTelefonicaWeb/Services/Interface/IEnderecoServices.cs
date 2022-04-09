using ListaTelefonico.Models;
using System;
using System.Collections.Generic;

namespace ListaTelefonico.Services.Interface
{
    public interface IEnderecoServices
    { 
        List<Endereco> GetAllEnderecos();
        List<Endereco> GetAllEnderecosContato(Guid id);
        Endereco GetEndereco(Guid id);
        void CreateEndereco(Endereco contato);
        void UpdateEndereco(Endereco contato);
        void DeleteEndereco(Guid id);
    }
}
