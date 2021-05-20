using AutoMapper;
using Eventos.API.Domain;
using Eventos.API.DTO;
using Eventos.API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.API.Service
{
    public class RedeSocialService : IRedeSocialDTOInterface
    {
        private readonly IMapper _mapper;
        private readonly IRedeSocialInterface _redeSocialInterface;
        public RedeSocialService(IMapper mapper, IRedeSocialInterface redeSocialInterface)
        {
            _mapper = mapper;
            _redeSocialInterface = redeSocialInterface;                
        }
        public async Task<RedeSocialDTO> AddRedeSocial(RedeSocialDTO model)
        {
            var redeSocial = _mapper.Map<RedeSocial>(model);

            redeSocial = await _redeSocialInterface.AddRedeSocial(redeSocial);

            return _mapper.Map<RedeSocialDTO>(redeSocial);
        }

        public async Task DeleteRedeSocial(int id)
        {
           await _redeSocialInterface.DeleteRedeSocial(id);
        }

        public async Task<List<RedeSocialDTO>> GetAllRedeSocial()
        {
            var redeSociais = await _redeSocialInterface.GetAllRedeSocial();
            return _mapper.Map<List<RedeSocialDTO>>(redeSociais);
        }

        public async Task UpdateRedeSocial(int id, RedeSocialDTO model)
        {
            var redeSocial =  _mapper.Map<RedeSocial>(model);
            await _redeSocialInterface.UpdateRedeSocial(id, redeSocial);
        }
    }
}
