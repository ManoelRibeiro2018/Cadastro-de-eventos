using AutoMapper;
using Eventos.API.Domain;
using Eventos.API.DTO;
using Eventos.API.Interface;
using Eventos.API.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventos.API.Service
{
    public class PalestranteService : IPalestranteDTOInterface
    {
        private readonly IMapper _mapper;
        private readonly IPalestranteInterface  _palestranteInterface;
        public PalestranteService(IMapper mapper, IPalestranteInterface palestranteInterface)
        {
            _mapper = mapper;
            _palestranteInterface = palestranteInterface;
        }
        public async Task<PalestranteDTO> AddPalestrante(PalestranteDTO model)
        {
            var palestrante = _mapper.Map<Palestrante>(model);

            palestrante = await _palestranteInterface.AddPalestrante(palestrante);

            return _mapper.Map<PalestranteDTO>(palestrante);
            
        }

        public async Task DeletePalestrante(int id)
        {
          await _palestranteInterface.DeletePalestrante(id);
        }

        public async Task<List<PalestranteDTO>> GetAllPalestrantes(bool includeEventos = false)
        {
            var palestrantes = await _palestranteInterface.GetAllPalestrantes(includeEventos);
            if (palestrantes == null)
            {
                return null;
            }

           return _mapper.Map<List<PalestranteDTO>>(palestrantes);
        }

        public async Task<List<PalestranteDTO>> GetAllPalestrantesByNome(string nome, bool includeEventos = false)
        {
            var palestrantes = await _palestranteInterface.GetAllPalestrantesByNome(nome, includeEventos);
            if (palestrantes == null)
            {
                return null;
            }
            return _mapper.Map<List<PalestranteDTO>>(palestrantes);
        }

        public async Task<PalestranteDTO> GetPalestranteById(int palestranteId, bool includeEventos = false)
        {
            var evento = await _palestranteInterface.GetPalestranteById(palestranteId, includeEventos);
            if (evento == null)
            {
                return null;
            }
            return _mapper.Map<PalestranteDTO>(evento);
        }

        public async Task UpdatePalestrante(int id, PalestranteDTO model)
        {
            var palestrante = _mapper.Map<Palestrante>(model);
            await _palestranteInterface.UpdatePalestrante(id, palestrante);
        }
    }
}
