using ListaTelefonico.Models;
using ListaTelefonico.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ListaTelefonico.Services
{
    public class EnderecoServices : IEnderecoServices
    {
        private static List<Endereco> ListEnderecos = new List<Endereco>();
        public List<Endereco> GetAllEnderecos()
        {
            return ListEnderecos;
        }
        public List<Endereco> GetAllEnderecosContato(Guid id)
        {
            return ListEnderecos.Where(e => e.IdContato == id).ToList();
        }
        public Endereco GetEndereco(Guid id)
        {
            return ListEnderecos.FirstOrDefault(c => c.Id == id);
        }
        public void CreateEndereco(Endereco Endereco)
        {
            Endereco.Id = Guid.NewGuid();

            ListEnderecos.Add(Endereco);
        }
        public void UpdateEndereco(Endereco Endereco)
        {
            var newEndereco = ListEnderecos.First(c => c.Id == Endereco.Id);

            newEndereco.Logradouro = Endereco.Logradouro;
            newEndereco.Numero = Endereco.Numero;
            newEndereco.Bairro = Endereco.Bairro;
            newEndereco.Cidade = Endereco.Cidade;
            newEndereco.UF = Endereco.UF;
            newEndereco.CEP = Endereco.CEP; 
        }
        public void DeleteEndereco(Guid id)
        {
            var Endereco = GetEndereco(id);

            ListEnderecos.Remove(Endereco);
        }

    }
}
