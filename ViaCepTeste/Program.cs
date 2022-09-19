using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViaCepTeste.Data;

namespace ViaCepTeste
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();

            //1. Obter o IWebHost que hospedará este aplicativo.
            var host = CreateHostBuilder(args).Build();


            //2. Encontre a camada de serviço dentro do nosso escopo.
            using (var scope = host.Services.CreateScope())
            {
                //3. Obtenha a instância de DatabaseContext em nossa camada de serviços
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<DatabaseContext>();

                //4. Chama o UserDbInitializer para criar dados de amostra
                UserDbInitializer.Initializer(services);
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
