using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using ViaCepTeste.Models;

namespace ViaCepTeste.Data
{
    public class UserDbInitializer
    {
        public static void Initializer(IServiceProvider serviceProvider)
        {
            using(var context = new DatabaseContext(serviceProvider.GetRequiredService<DbContextOptions<DatabaseContext>>()))
            {
                if(context.User.Any())
                {
                    return;
                }

                context.User.Add(
                    new User
                    {
                        Id = 1,
                        Usuario = "marcosvini",
                        Senha = "parli",
                        Role = "admin"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
