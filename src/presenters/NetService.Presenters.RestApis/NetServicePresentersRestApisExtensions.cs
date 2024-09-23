using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NetService.Presenters.RestApis;

#pragma warning disable IDE0130
// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.Hosting;
#pragma warning restore IDE0130

public static class NetServicePresentersRestApisExtensions
{
    public static IHostApplicationBuilder AddRestApis(
        this IHostApplicationBuilder builder,
        AddRestApisOptions? apisOptions = null)
    {
        var controllers = builder.Services.AddControllers();

        if (apisOptions?.Parts is { } parts)
        {
            foreach (var partType in parts)
            {
                controllers.AddApplicationPart(partType);
            }
        }

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(genOptions =>
            {
                if (apisOptions?.Parts is { } parts)
                {
                    foreach (var partType in parts)
                    {
                        var xmlFileName = $"{partType.GetName().Name}.xml";
                        var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                        if (File.Exists(xmlFilePath))
                        {
                            genOptions.IncludeXmlComments(xmlFilePath);
                        }
                    }
                }
            });

        return builder;
    }

    public static WebApplication UseRestApis(
        this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapControllers();

        return app;
    }
}

public class AddRestApisOptions
{
    public IEnumerable<Assembly>? Parts { get; set; }
}
