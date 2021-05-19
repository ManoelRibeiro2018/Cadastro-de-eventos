using Eventos.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.API.Interface
{
    public interface ILoteDTOInterface
    {
        LoteDTO AddLote(LoteDTO model);
        void Update(int idEvento, int id, LoteDTO model);
        Task<bool> Delete(int idEvento, int id);
        List<LoteDTO> GetAllLotesbyEvento(int eventoId);
        Task<LoteDTO> GetLoteById(int id);
    }
}
