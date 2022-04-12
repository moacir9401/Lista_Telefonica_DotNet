using ListaTelefonico.Models;
using Microsoft.EntityFrameworkCore;

namespace ListaTelefonicaWeb.Models.Context
{

    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> option) : base(option)
        {

        }

        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Email> Emails { get; set; }
    }
}
