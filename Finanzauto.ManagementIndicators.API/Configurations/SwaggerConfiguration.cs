using Microsoft.OpenApi.Models;

namespace Finanzauto.ManagementIndicators.API.Configurations
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Management Indicators API V1",
                    Description = "Management Indicators API V1"
                });
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
                xmlFiles.ForEach(xmlFile => options.IncludeXmlComments(xmlFile));

            });
            return services;
        }
    }
}
