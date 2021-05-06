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
    public class RedeSocialRepository : IRedeSocialInterface
    {
        private readonly EventosDbContext _eventoDbContext;
        public RedeSocialRepository(EventosDbContext eventosDb)
        {
            _eventoDbContext = eventosDb;
        }
        public async Task<RedeSocial> AddRedeSocial(RedeSocial model)
        {
            _eventoDbContext.RedeSociais.Add(model);
            await _eventoDbContext.SaveChangesAsync();
            return  _eventoDbContext.RedeSociais.FirstOrDefault(r => r.Id == model.Id);
        }
        public async Task DeleteRedeSocial(int id)
        {
            var redeSocial = _eventoDbContext.RedeSociais.SingleOrDefault(r => r.Id == id);
            if (redeSocial == null)
            {
                throw new ArgumentException("Rede Social não encotrada");
            }

            _eventoDbContext.RedeSociais.Remove(redeSocial);
          await  _eventoDbContext.SaveChangesAsync();
        }
        public async Task UpdateRedeSocial(int id, RedeSocial model)
        {
            var redeSocial = _eventoDbContext.RedeSociais.SingleOrDefault(r => r.Id == id);
            if (redeSocial == null)
            {
                throw new ArgumentException("Rede Social não encotrada");
            }
            redeSocial.Update(model.Nome, model.URL);
            await _eventoDbContext.SaveChangesAsync();
        }
        public async Task<List<RedeSocial>> GetAllRedeSocial()
        {
            IQueryable<RedeSocial> redeSocial = _eventoDbContext.RedeSociais
                .Include(r => r.Palestrante);

            return await redeSocial.ToListAsync();
        }

       
    }
}
