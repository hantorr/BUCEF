using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BUCEF.Models.BD
{
    public class BucContext : DbContext
    {

        public BucContext(DbContextOptions<BucContext> options)
            : base(options)
        { }

        public DbSet<Persona> Persona { get; set; }
        public DbSet<PersonaNatural> PersonaNatural { get; set; }
        public DbSet<Localizacion> Localizacion { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>().ToTable("Persona");
            modelBuilder.Entity<PersonaNatural>().ToTable("PersonaNatural");
            modelBuilder.Entity<Localizacion>().ToTable("Localizacion");
            modelBuilder.Entity<TipoDocumento>().ToTable("TipoDocumento");
        }

    }
}
