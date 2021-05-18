using Eventos.API.DTO;
using Eventos.API.Interface;
using Eventos.API.Repository;
using Eventos.API.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.API.Extensions
{
    public static class ServiceColletionsExtensions
    {
        public static IServiceCollection AddAplicationService(this IServiceCollection services)
        {
            services.AddScoped<IEventoInterface, EventoRepository>();
            services.AddScoped<IPalestranteInterface, PalestranteRepository>();
            services.AddScoped<ILoteInterface, LoteRepository>();
            services.AddScoped<IRedeSocialInterface, RedeSocialRepository>();
            services.AddScoped<IEventoDTOInterface, EventoService>();

            return services;

        }
    }
}
