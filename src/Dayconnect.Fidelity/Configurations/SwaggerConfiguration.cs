using Dayconnect.Fidelity.Filters;
using Microsoft.OpenApi.Models;

namespace Dayconnect.Fidelity.Configurations
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection IntegrateSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {

                c.AddSecurityDefinition("DayId", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Name = "DayId",
                    Description = "Autenticacao via DayId"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "DayId"}
                        },
                        new string[] {}
                    }
                });

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Daycoval Fidelity",
                    Description = "Web API para gerenciar os clientes do Dayconnect pela Fidelity",
                    TermsOfService = new Uri("https://colocar.readme.bitbucket"),
                    Contact = new OpenApiContact
                    {
                        Name = "Dayconnect - Projetos",
                        Email = "desenv@bancodaycoval.com.br",
                        Url = new Uri("http://colocar.servidor.dev/DaycovalFidelityApi"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Daycoval",
                        Url = new Uri("https://colocar.readme.bitbucket"),
                    }
                });
                c.EnableAnnotations(enableAnnotationsForInheritance: true, enableAnnotationsForPolymorphism: true);
            });

            return services;
        }
    }
}
