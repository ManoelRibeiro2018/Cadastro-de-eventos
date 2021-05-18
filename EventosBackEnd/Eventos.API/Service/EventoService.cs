using AutoMapper;
using Eventos.API.Domain;
using Eventos.API.DTO;
using Eventos.API.Interface;
using Eventos.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.API.Service
{
    public class EventoService : IEventoDTOInterface
    {
        private readonly IEventoInterface _eventoRepository;

        private readonly IMapper _mapper;
        public EventoService(IEventoInterface eventoRepository, IMapper mapper)
        {
            _eventoRepository = eventoRepository;
            _mapper = mapper;
        }
        public async Task<EventoDTO> AddEvento(EventoDTO model)
        {
            try
            {
                var evento = _mapper.Map<Evento>(model);
                var resultado = await _eventoRepository.AddEvento(evento);
                if (resultado == null)
                {
                    return null;
                }
                return _mapper.Map<EventoDTO>(resultado);


            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteEvento(int id)
        {
           await _eventoRepository.DeleteEvento(id);
        }

        public async Task<List<EventoDTO>> GetAllEventosAsync(bool includePalestrante = false)
        {
            var eventos = await _eventoRepository.GetAllEventosAsync(includePalestrante);
            if (eventos == null)
            {
                return null;
            }

            var eventosDTO = _mapper.Map<List<EventoDTO>>(eventos);

            return eventosDTO;

        }

        public async Task<List<EventoDTO>> GetAllEventosByTemaAsync(string tema, bool includePalestrante = false)
        {
            var eventos = await _eventoRepository.GetAllEventosByTemaAsync(tema, includePalestrante);
            if (eventos == null)
            {
                return null;
            }
            var eventosDTO = _mapper.Map<List<EventoDTO>>(eventos);

            return eventosDTO;

        }

        public async Task<EventoDTO> GetEventoByIdAsync(int eventoId, bool includePalestrante = false)
        {
            var evento = await _eventoRepository.GetEventoByIdAsync(eventoId, includePalestrante);
            if (evento == null)
            {
                return null;
            }

            var eventoDto = _mapper.Map<EventoDTO>(evento);

            return eventoDto;
        }

        public async Task UpdateEvento(int id, EventoDTO model)
        {
            var evento = _mapper.Map<Evento>(model);
            await _eventoRepository.UpdateEvento(id,evento);
        }
    }
}
