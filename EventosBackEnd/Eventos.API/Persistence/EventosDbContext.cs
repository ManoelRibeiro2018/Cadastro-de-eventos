using Eventos.API.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.API.Persistence
{
    public class EventosDbContext : DbContext
    {
        public EventosDbContext(DbContextOptions<EventosDbContext> options) : base(options)
        {

        }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<RedeSocial> RedeSociais { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Evento
            modelBuilder.Entity<Evento>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Evento>()
                .HasMany(e => e.Palestrantes)
                .WithMany(p => p.Eventos);

            modelBuilder.Entity<Evento>()
             .Property(e => e.Tema)
             .HasMaxLength(3);

            modelBuilder.Entity<Evento>()
                .HasMany(e => e.RedesSociais)
                .WithOne(r => r.Evento)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Evento>()
                .HasMany(e => e.Lotes)
                .WithOne(l => l.Evento)
                .OnDelete(DeleteBehavior.Cascade);

            //Palestrante

            modelBuilder.Entity<Palestrante>()
                .HasMany(p => p.RedeSociais)
                .WithOne(r => r.Palestrante)
                .OnDelete(DeleteBehavior.Cascade);



        }

    }
}
