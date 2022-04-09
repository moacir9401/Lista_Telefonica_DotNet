using ListaTelefonico.Models;
using ListaTelefonico.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ListaTelefonico.Services
{
    public class TelefoneServices : ITelefoneServices
    {
        private static List<Telefone> ListTelefones = new List<Telefone>();
        public List<Telefone> GetAllTelefones()
        {
            return ListTelefones;
        }
        public List<Telefone> GetAllTelefonesContato(Guid id)
        {
            return ListTelefones.Where(e => e.IdContato == id).ToList();
        }
        public Telefone GetTelefone(Guid id)
        {
            return ListTelefones.FirstOrDefault(c => c.Id == id);
        }
        public void CreateTelefone(Telefone Telefone)
        {
            Telefone.Id = Guid.NewGuid();
            ListTelefones.Add(Telefone);
        }
        public void UpdateTelefone(Telefone Telefone)
        {
            var newTelefone = ListTelefones.First(c => c.Id == Telefone.Id);

            newTelefone.IdContato = Telefone.IdContato;
            newTelefone.Numero = Telefone.Numero; 
        }
        public void DeleteTelefone(Guid id)
        {
            var Telefone = GetTelefone(id);

            ListTelefones.Remove(Telefone);
        }

    }
}
