using Eventos.API.Domain;
using Eventos.API.Interface;
using Eventos.API.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.API.Repository
{
    public class PalestranteRepository : IPalestranteInterface
    {
        private readonly EventosDbContext _eventoDbContext;
        public PalestranteRepository(EventosDbContext eventosDb)
        {
            _eventoDbContext = eventosDb;
        }

        public Task<Palestrante> AddPalestrante(Palestrante palestrante)
        {
            _eventoDbContext.Palestrantes.Add(palestrante);
            _eventoDbContext.SaveChanges();

            return this.GetPalestranteByIdAsync(palestrante.Id);
        }
        public Task<Palestrante> UpdatePalestrante(int id, Palestrante palestrante)
        {
            throw new NotImplementedException();
        }

        public Task<Palestrante> DeletePalestrante(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _eventoDbContext.Palestrantes
                 .Include(p => p.RedeSociais);

            if (includeEventos)
            {
                query = query
                    .Include(p => p.Eventos)
                    .ThenInclude(e => e.Palestrantes);
            }

            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _eventoDbContext.Palestrantes
                .Include(p => p.RedeSociais);

            if (includeEventos)
            {
                query = query
                    .Include(p => p.Eventos)
                    .ThenInclude(e => e.Palestrantes);
            }

            query = query.OrderBy(e => e.Id).Where(e => e.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _eventoDbContext.Palestrantes
                .Include(p => p.RedeSociais);

            if (includeEventos)
            {
                query = query
                    .Include(p => p.Eventos)
                    .ThenInclude(e => e.Palestrantes);
            }

            query = query.OrderBy(p => p.Id).Where(p => p.Id == PalestranteId);

            return await query.SingleOrDefaultAsync();
        }

       
    }
}
