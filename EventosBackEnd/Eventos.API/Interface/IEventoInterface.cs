using Eventos.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.API.Interface
{
    public interface IEventoInterface
    {
        Task<Evento> AddEvento(Evento model);
        void UpdateEvento(int id, Evento model);
        void DeleteEvento(int id);
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante  = false);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrante = false);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrante = false);
    }
}
