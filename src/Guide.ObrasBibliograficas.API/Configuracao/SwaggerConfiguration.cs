using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Guide.ObrasBibliograficas.API.Configuracoes
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Teste Web Motors",
                    Description = "API",
                });
            });

            services.ConfigureSwaggerGen(opt =>
            {
            });
        }
    }
}
