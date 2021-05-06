using Eventos.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.API.Interface
{
    public interface IRedeSocialInterface
    {
        Task<RedeSocial> AddRedeSocial(RedeSocial model);
        Task UpdateRedeSocial(int id, RedeSocial model);
        Task DeleteRedeSocial(int id);
        Task<List<RedeSocial>> GetAllRedeSocial();

    }
}
