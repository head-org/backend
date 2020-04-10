using Head.Api.Infrastructure.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Head.Api.Infrastructure.Swagger
{
    public static class Setup
    {
        internal static void SwaggerSetup(this IServiceCollection services, OpenApiInfo settings)
        {
            if (settings.Version != null)
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc(settings.Version, settings);
                    c.DocumentFilter<LowercaseDocumentFilter>();
                    c.OperationFilter<AuthOperationFilter>();
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme.",
                        Type = SecuritySchemeType.Http,
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Scheme = "Bearer"
                    });
                });
            }
        }
    }
}
