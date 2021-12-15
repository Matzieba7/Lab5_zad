using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
//using ToReadApi.Data;
using System;
using System.Linq;

namespace ToReadApi.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ToReadContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ToReadContext>>()))
            {
                // Look for any movies.
                if (context.ToReadItems.Any())
                {
                    return;   // DB has been seeded
                }

                context.ToReadItems.AddRange(
                    new ToReadItem
                    {
                        Id = 1,
                        Name = "Tunele",
                        IsRead = false,
                        Opinion = "Good",
                        Comment = "Destroyed Cover"
                    },

                    new ToReadItem
                    {
                        Id = 2,
                        Name = "Tunele",
                        IsRead = false,
                        Opinion = "Good",
                        Comment = "Destroyed Cover"
                    },

                    new ToReadItem
                    {
                        Id = 3,
                        Name = "Tunele",
                        IsRead = false,
                        Opinion = "Good",
                        Comment = "Destroyed Cover"
                    },

                    new ToReadItem
                    {
                        Id = 4,
                        Name = "Tunele",
                        IsRead = false,
                        Opinion = "Good",
                        Comment = "Destroyed Cover"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}