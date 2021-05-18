using Eventos.API.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventos.API.Interface
{
    public interface IEventoInterface
    {
        Task<Evento> AddEvento(Evento model);
        Task UpdateEvento(int id, Evento model);
        Task DeleteEvento(int id);
        Task<List<Evento>> GetAllEventosByTemaAsync(string tema, bool includePalestrante  = false);
        Task<List<Evento>> GetAllEventosAsync(bool includePalestrante = false);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrante = false);
    }
}
