#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dndgenesis.Models;

namespace dndgenesis.Data
{
    public class dndgenesisContext : DbContext
    {
        public dndgenesisContext (DbContextOptions<dndgenesisContext> options)
            : base(options)
        {
        }

        public DbSet<dndgenesis.Models.DndClass> DndClass { get; set; }
    }
}
