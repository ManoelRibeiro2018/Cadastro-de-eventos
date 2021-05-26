 using Eventos.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.API.Interface
{
    public interface IEventoDTOInterface
    {
        Task<EventoDTO> AddEvento(EventoDTO model);
        Task UpdateEvento(int id, EventoDTO model);
        Task DeleteEvento(int id);
        Task<List<EventoDTO>> GetAllEventosByTemaAsync(string tema, bool includePalestrante = false);
        Task<List<EventoDTO>> GetAllEventosAsync(bool includePalestrante = false);
        Task<EventoDTO> GetEventoByIdAsync(int eventoId, bool includePalestrante = false);
    }
}
