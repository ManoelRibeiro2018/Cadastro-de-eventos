using Eventos.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.API.Interface
{
    public interface IPalestranteDTOInterface
    {
        Task<PalestranteDTO> AddPalestrante(PalestranteDTO model);
        Task UpdatePalestrante(int id, PalestranteDTO model);
        Task DeletePalestrante(int id);
        Task<List<PalestranteDTO>> GetAllPalestrantes(bool includeEventos = false);
        Task<PalestranteDTO> GetPalestranteById(int palestranteId, bool includeEventos = false);
    }
}
