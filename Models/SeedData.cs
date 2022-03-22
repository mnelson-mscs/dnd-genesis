using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using dndgenesis.Data;
using System;
using System.Linq;

namespace dndgenesis.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new dndgenesisContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<dndgenesisContext>>()))
            {
                // Look for any movies.
                if (context.DndClass.Any())
                {
                    return;   // DB has been seeded
                }

                context.DndClass.AddRange(
                    new DndClass
                    {
                        DndClassName = "Artificer"
                    },
                    new DndClass
                    {
                        DndClassName = "Barbarian"
                    },
                    new DndClass
                    {
                        DndClassName = "Bard"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}