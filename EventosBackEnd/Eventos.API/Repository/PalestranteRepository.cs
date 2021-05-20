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
        public async Task<Palestrante> AddPalestrante(Palestrante model)
        {
            _eventoDbContext.Palestrantes.Add(model);
            _eventoDbContext.SaveChanges();
            return await GetPalestranteById(model.Id);
        }
        public async Task UpdatePalestrante(int id, Palestrante model)
        {
            var palestrante = _eventoDbContext.Palestrantes.SingleOrDefault(p => p.Id == id);
            if (palestrante == null)
            {
                throw new ArgumentException("Palestrante não encontrado");
            }

            palestrante.Update(model.Nome, model.MiniCurriculo, model.ImagemUrl, model.Telefone, model.Email);
            await _eventoDbContext.SaveChangesAsync();
        }
        public async Task DeletePalestrante(int id)
        {
            var palestrante = _eventoDbContext.Palestrantes.SingleOrDefault(p => p.Id == id);
            if (palestrante == null)
            {
                throw new ArgumentException("Palestrante não encontrado");
            }
            _eventoDbContext.Palestrantes.Remove(palestrante);
            await _eventoDbContext.SaveChangesAsync();
        }
        public async Task<List<Palestrante>> GetAllPalestrantes(bool includeEventos = false)
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

            return await query.ToListAsync();
        }
        public async Task<Palestrante> GetPalestranteById(int PalestranteId, bool includeEventos = false)
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
