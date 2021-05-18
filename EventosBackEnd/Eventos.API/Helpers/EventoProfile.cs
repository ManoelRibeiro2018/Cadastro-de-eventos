using AutoMapper;
using Eventos.API.Domain;
using Eventos.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.API.Helpers
{
    public class EventoProfile : Profile
    {
        public EventoProfile()
        {
            CreateMap<Evento, EventoDTO>().ReverseMap();
        }
    }
}
