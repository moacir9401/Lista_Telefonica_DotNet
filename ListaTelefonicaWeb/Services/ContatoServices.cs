using ListaTelefonico.Models;
using ListaTelefonico.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ListaTelefonico.Services
{
    public class ContatoServices : IContatoServices
    {
        private static List<Contato> ListContatos = new List<Contato>();
        public List<Contato> GetAllContatos()
        {
            return ListContatos;
        }
        public Contato GetContato(Guid id)
        {
            return ListContatos.FirstOrDefault(c => c.Id == id);
        }
        public Guid CreateContato(Contato contato)
        {
            contato.Id = Guid.NewGuid();
            ListContatos.Add(contato);

            return contato.Id;
        }
        public void UpdateContato(Contato contato)
        {
            var newContato = ListContatos.First(c => c.Id == contato.Id);
            newContato.Nome = contato.Nome;
            newContato.Sobrenome = contato.Sobrenome;
            newContato.Cargo = contato.Cargo;
            newContato.Empresa = contato.Empresa;
            newContato.Apelido = contato.Apelido;
            newContato.DataNascimento = contato.DataNascimento;
            newContato.Observacoes = contato.Observacoes;
        }
        public void DeleteContato(Guid id)
        {
            var contato = GetContato(id);

            ListContatos.Remove(contato);
        }
         
    }

}
