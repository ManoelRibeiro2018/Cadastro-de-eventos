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
    public class EventoRepository : IEventoInterface
    {
        private readonly EventosDbContext _eventoDbContext;
        public EventoRepository(EventosDbContext eventosDb)
        {
            _eventoDbContext = eventosDb;
        }
        public async Task<Evento> AddEvento(Evento model)
        {
            _eventoDbContext.Eventos.Add(model);
            _eventoDbContext.SaveChanges();

            return await this.GetEventoByIdAsync(model.Id);
        }
        public async Task UpdateEvento(int id, Evento model)
        {
            var evento =  _eventoDbContext.Eventos.SingleOrDefault(e => e.Id == id);

            if (evento == null)
            {
                throw new ArgumentException("Usuario não encontrado!!");
            }

            evento.Update(model.Local, model.DataEvento, model.Tema, model.QtdPessoas, model.ImageUrl, model.Telefone, model.Email);
           await _eventoDbContext.SaveChangesAsync();
        }

        public async Task DeleteEvento(int id)
        {
            var evento = await _eventoDbContext.Eventos.SingleOrDefaultAsync(e => e.Id == id);
            if (evento == null)
            {
                throw new ArgumentException("Usuário invalido");
            }

            _eventoDbContext.Eventos.Remove(evento);
            _eventoDbContext.SaveChanges();
        }
        public async Task<List<Evento>> GetAllEventosAsync(bool includePalestrante = false)
        {
            IQueryable<Evento> query = _eventoDbContext.Eventos
                 .Include(e => e.Lotes)
                 .Include(e => e.RedesSociais);

            if (includePalestrante)
            {
                query = query
                    .Include(e => e.Palestrantes)
                    .ThenInclude(p => p.Eventos);
            }

            query = query.OrderBy(e => e.Id);

            return await query.ToListAsync();
        }
        public async Task<List<Evento>> GetAllEventosByTemaAsync(string tema, bool includePalestrante = false)
        {
            IQueryable<Evento> query = _eventoDbContext.Eventos.Where(e => e.Tema == tema)
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if (includePalestrante)
            {
                query = query
                    .Include(e => e.Palestrantes)
                    .ThenInclude(p => p.Eventos);
            }

            query = query.OrderBy(e => e.Id).Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToListAsync();
        }
        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrante = false)
        {
            IQueryable<Evento> query = _eventoDbContext.Eventos.Where(e => e.Id == eventoId);
               

            if (includePalestrante)
            {
                query = query.Include(e => e.Palestrantes); 
            }
               

            return await query.SingleOrDefaultAsync();
        }

    }
}
