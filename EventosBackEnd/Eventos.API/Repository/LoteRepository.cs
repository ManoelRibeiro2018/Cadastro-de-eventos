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
    public class LoteRepository : ILoteInterface
    {
        private readonly EventosDbContext _eventoDbContext;
        public LoteRepository(EventosDbContext eventosDb)
        {
            _eventoDbContext = eventosDb;
        }
        public Lote AddLote(Lote model)
        {
            _eventoDbContext.Lotes.Add(model);
            _eventoDbContext.SaveChanges();
            return  _eventoDbContext.Lotes.SingleOrDefault(l => l.Id == model.Id);

        }

        public void Update(int idEvento, int id, Lote model)
        {
            var lote = _eventoDbContext.Lotes.SingleOrDefault(l => l.EventoId == idEvento && l.Id == id);
            if (lote == null)
            {
                throw new ArgumentException("Lote não encontrado!!!");
            }

            lote.Update(model.Nome, model.Preco, model.DataFim, model.DataFim, model.Quantidade);

        }

        public async Task<bool> Delete(int idEvento, int id)
        {
            var lote = _eventoDbContext.Lotes.SingleOrDefault(l => l.EventoId == idEvento && l.Id == id);

            if (lote == null)
            {
                throw new ArgumentException("usuário não encontrado");
            }
            _eventoDbContext.Lotes.Remove(lote);

            return await _eventoDbContext.SaveChangesAsync() == 1 ? true : false;
        }

        public List<Lote> GetAllLotesbyEvento(int eventoId)
        {

            IQueryable<Lote> query = _eventoDbContext.Lotes.AsNoTracking();

            query = query.OrderBy(l => l.Id).Where(l => l.EventoId == eventoId);

            return  query.ToList();
        }

        public async Task<Lote> GetLoteById(int id)
        {
            IQueryable<Lote> query = _eventoDbContext.Lotes.AsNoTracking();
                
                
                query = query.Where(l => l.Id == id);

            return await query.SingleOrDefaultAsync();
        }

       
    }
}
