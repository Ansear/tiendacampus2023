using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.UnitOfWork;

namespace API.Extension;
    public static class ApplicationServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options => 
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin() //Restringir quien entra accede a un endpoint (https://domain.com)
                    .AllowAnyMethod() //Bloquear metodos HTTP o verdos para realizar las peticiones (GET,POST)
                    .AllowAnyHeader()); //Headers o encabezados "content-type"
        });

        public static void AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork,UnitOfWork>();
        }
    }