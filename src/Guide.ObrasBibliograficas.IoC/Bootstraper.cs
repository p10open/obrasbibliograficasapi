using Guide.ObrasBibliograficas.Domain.Interfaces.Repositories;
using Guide.ObrasBibliograficas.Domain.Interfaces.Services;
using Guide.ObrasBibliograficas.Domain.Interfaces.UoW;
using Guide.ObrasBibliograficas.Domain.Services;
using Guide.ObrasBibliograficas.Infra.Data.Context;
using Guide.ObrasBibliograficas.Infra.Data.Repositories;
using Guide.ObrasBibliograficas.Infra.Data.UoW;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Guide.ObrasBibliograficas.IoC
{
    public static class Bootstraper
    {
        public static void RegistrarDI(this IServiceCollection service)
        {
            service.AddDbContext<ObrasBibliograficasContext>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();

            RegistrarRepositories(service);
            RegistrarServices(service);
        }

        static void RegistrarRepositories(IServiceCollection service)
        {
            service.AddScoped<IObraBibliograficaRepository, ObraBibliograficaRepository>();
        }

        static void RegistrarServices(IServiceCollection service)
        {
            service.AddScoped<IObraBibliograficaService, ObraBibliograficaService>();
        }
    }
}
