using Eventos.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.API.Interface
{
    public interface IPalestranteInterface
    {
        Task<Palestrante> AddPalestrante(Palestrante palestrante);
        Task<Palestrante> UpdatePalestrante(int id, Palestrante palestrante);
        Task<Palestrante> DeletePalestrante(int id);
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false);
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false);
    }
}
