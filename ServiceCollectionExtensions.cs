using DocuPipe.Client.Api.Document;
using DocuPipe.Client.Api.Schema;
using DocuPipe.Client.Api.Standardization;
using DocuPipe.Client.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DocuPipe.Client;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDocuPipeClient(this IServiceCollection services, IConfiguration configuration, string sectionName = "DocuPipe")
    {
        return services.AddDocuPipeClient(builder => builder.Bind(configuration.GetSection(sectionName)));
    }

    public static IServiceCollection AddDocuPipeClient(this IServiceCollection services, Action<DocuPipeClientOptions> configure)
    {
        services.Configure(configure);
        RegisterClients(services);
        return services;
    }

    public static IServiceCollection AddDocuPipeClient(this IServiceCollection services, Action<OptionsBuilder<DocuPipeClientOptions>> configure)
    {
        var optionsBuilder = services.AddOptions<DocuPipeClientOptions>();
        configure(optionsBuilder);

        RegisterClients(services);
        return services;
    }

    private static void RegisterClients(IServiceCollection services)
    {
        services.AddHttpClient<IStandardizationClient, StandardizationClient>((serviceProvider, httpClient) =>
        {
            ApplyOptions(serviceProvider, httpClient);
        });

        services.AddHttpClient<IDocumentClient, DocumentClient>((serviceProvider, httpClient) =>
        {
            ApplyOptions(serviceProvider, httpClient);
        });

        services.AddHttpClient<ISchemaClient, SchemaClient>((serviceProvider, httpClient) =>
        {
            ApplyOptions(serviceProvider, httpClient);
        });
    }

    private static void ApplyOptions(IServiceProvider serviceProvider, HttpClient httpClient)
    {
        var options = serviceProvider.GetRequiredService<IOptions<DocuPipeClientOptions>>().Value;

        if (!string.IsNullOrWhiteSpace(options.BaseUrl))
        {
            httpClient.BaseAddress = new Uri(options.BaseUrl);
        }

        if (!string.IsNullOrWhiteSpace(options.ApiKey))
        {
            var headerName = string.IsNullOrWhiteSpace(options.ApiKeyHeaderName) ? "x-api-key" : options.ApiKeyHeaderName;
            httpClient.DefaultRequestHeaders.Remove(headerName);
            httpClient.DefaultRequestHeaders.Add(headerName, options.ApiKey);
        }
    }
}
