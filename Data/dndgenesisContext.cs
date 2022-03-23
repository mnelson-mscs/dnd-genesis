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
        public DbSet<dndgenesis.Models.DndSubclass> DndSubclass { get; set; }
        public DbSet<dndgenesis.Models.Book> Book { get; set; }
        public DbSet<dndgenesis.Models.Race> Race { get; set; }
        public DbSet<dndgenesis.Models.Subrace> Subrace { get; set; }
        public DbSet<dndgenesis.Models.Spell> Spell { get; set; }
        public DbSet<dndgenesis.Models.SchoolMagic> SchoolMagic { get; set; }

    }
}
