using Eventos.API.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventos.API.Interface
{
    public interface IPalestranteInterface
    {
        Task<Palestrante> AddPalestrante(Palestrante model);
        Task UpdatePalestrante(int id, Palestrante model);
        Task DeletePalestrante(int id);
        Task<List<Palestrante>> GetAllPalestrantesByNome(string nome, bool includeEventos = false);
        Task<List<Palestrante>> GetAllPalestrantes(bool includeEventos = false);
        Task<Palestrante> GetPalestranteById(int palestranteId, bool includeEventos = false);
    }
}
