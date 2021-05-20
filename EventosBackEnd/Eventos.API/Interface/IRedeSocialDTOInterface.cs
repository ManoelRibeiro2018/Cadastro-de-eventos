using Eventos.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.API.Interface
{
    public interface IRedeSocialDTOInterface
    {
        Task<RedeSocialDTO> AddRedeSocial(RedeSocialDTO model);
        Task UpdateRedeSocial(int id, RedeSocialDTO model);
        Task DeleteRedeSocial(int id);
        Task<List<RedeSocialDTO>> GetAllRedeSocial();
    }
}
