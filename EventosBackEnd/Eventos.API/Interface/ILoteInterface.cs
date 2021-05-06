using Eventos.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.API.Interface
{
    public interface ILoteInterface
    {
        Lote AddLote(Lote model);
        void Update(int idEvento, int id, Lote model);
        Task<bool> Delete(int idEvento, int id);
        List<Lote> GetAllLotesbyEvento(int eventoId);
        Task<Lote> GetLoteById(int id);

    }
}
