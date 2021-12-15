using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToReadApi.Models;
using Microsoft.Extensions.DependencyInjection;


namespace ToReadApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();

            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<ToReadContext>();
                SeedDB(context);
                //try
                //{
                //    SeedData.Initialize(services);
                //}
                //catch (Exception ex)
                //{
                //    var logger = services.GetRequiredService<ILogger<Program>>();
                //    logger.LogError(ex, "An error occurred seeding the DB.");
                //}
            }

            host.Run();

        }

        public static void SeedDB(ToReadContext context)
        {
            var ReadItemList = context.ToReadItems.ToList();
            if (ReadItemList.Count > 0) return;

            var Books = new List<ToReadItem>();
            Books.Add(new ToReadItem
            {
                Id = 1,
                Name = "Harry Potter and the Chamber of Secrets",
                IsRead = true,
                Opinion = "nice",
                Comment = "better then the previuos one",

            });
            Books.Add(new ToReadItem
            {
                Id = 2,
                Name = "Eragon",
                IsRead = true,
                Opinion = "great",
                Comment = "nice",

            });
            Books.Add(new ToReadItem
            {
                Id = 3,
                Name = "Metro 2033",
                IsRead = false,
                Opinion = "heard its good",
                Comment = "none",

            });
            Books.Add(new ToReadItem
            {
                Id = 4,
                Name = "Silmarillion",
                IsRead = true,
                Opinion = "The best so far",
                Comment = "Read all other tolkien books",

            });


            context.AddRange(Books);
            context.SaveChanges();

        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
