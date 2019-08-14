using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Guide.ObrasBibliograficas.API.Configuracoes;
using Guide.ObrasBibliograficas.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Guide.ObrasBibliograficas.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSwaggerConfig();

            services.AddCors();

            services.AddOptions();

            services.RegistrarDI();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api-docs/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(s =>
            {
                s.RoutePrefix = "api-docs";
                s.SwaggerEndpoint("v1/swagger.json", "Api v1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
