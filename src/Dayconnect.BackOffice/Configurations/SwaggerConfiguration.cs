using Microsoft.OpenApi.Models;

namespace DevSecOps.backoffice.Configurations;

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
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "DayId"}
                    },
                    Array.Empty<string>()
                }
            });

            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "DevSecOps BackOffice",
                Description = "Web API para para laboratório DevSecOps",
                TermsOfService = new Uri("https://bitbucket.daycoval.dev.br/projects/DBE/repos/dotnet.webapi.backofficecliente/browse"),
                Contact = new OpenApiContact
                {
                    Name = "DevSecOps",
                    Email = "desenv@bancodaycoval.com.br",
                    Url = new Uri("https://bitbucket.daycoval.dev.br/projects/DBE/repos/dotnet.webapi.backofficecliente/browse"),
                },
                License = new OpenApiLicense
                {
                    Name = "Daycoval",
                    Url = new Uri("https://bitbucket.daycoval.dev.br/projects/DBE/repos/dotnet.webapi.backofficecliente/browse"),
                }
            });
            c.EnableAnnotations(true, true);
        });

        return services;
    }
}