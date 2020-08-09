using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.API.Validacoes;
using Desafio.Dominio.Validacoes;
using Desafio.Repositorio.Database;
using Desafio.Respositorio.Repositorios;
using Desafio.Respositorio.Repositorios.Contratos;
using FluentValidation.Results;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Desafio.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("config.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IColaboradorRepository, ColaboradorRepositorio>();
            services.AddScoped<IEquipeRepository, EquipeRepositorio>();
            services.AddScoped<EquipeValidator>();
            services.AddScoped<ColaboradorValidator>();
            services.AddScoped<ValidationResult>();

            var connectionString = Configuration.GetConnectionString("DesafioDB");
            services.AddDbContext<DesafioContext>(option =>
                option.UseLazyLoadingProxies()
                .UseMySql(connectionString, m => m.MigrationsAssembly("Desafio.Repositorio")));
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

            // app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
