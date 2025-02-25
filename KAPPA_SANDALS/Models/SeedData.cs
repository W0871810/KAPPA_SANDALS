using KAPPA_SANDALS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace KAPPA_SANDALS.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new KAPPA_SANDALSContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<KAPPA_SANDALSContext>>()))
            {
                // Look for any sandals.
                if (context.Sandal.Any())
                {
                    return;   // DB has been seeded
                }
                context.Sandal.AddRange(
                    new Sandal
                    {
                        Color = "Red",
                        Design = "Strappy",
                        Price = 49.99M,
                        Age = 1,
                        Size = 8
                    },
                    new Sandal
                    {
                        Color = "Blue",
                        Design = "Flip Flop",
                        Price = 29.99M,
                        Age = 1,
                        Size = 9
                    },
                    new Sandal
                    {
                        Color = "Green",
                        Design = "Sporty",
                        Price = 59.99M,
                        Age = 2,
                        Size = 10
                    },
                    new Sandal
                    {
                        Color = "Black",
                        Design = "Formal",
                        Price = 79.99M,
                        Age = 3,
                        Size = 11
                    },
                    new Sandal
                    {
                        Color = "White",
                        Design = "Casual",
                        Price = 39.99M,
                        Age = 1,
                        Size = 7
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
