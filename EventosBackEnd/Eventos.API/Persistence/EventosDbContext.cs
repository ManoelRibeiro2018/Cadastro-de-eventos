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
    }
}
