using System.Linq;
using Microsoft.EntityFrameworkCore;
using ViaCepTeste.Models;

namespace ViaCepTeste.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opt) : base(opt)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        public User Get(string usuario, string senha)
        {
            return User.Where(x => x.Usuario.ToLower() == usuario.ToLower() && x.Senha == x.Senha).FirstOrDefault();
        }
        public DbSet<User> User { get; set; }
    }
}
