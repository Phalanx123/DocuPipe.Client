using DocuPipe.Clients.Document;
using DocuPipe.Clients.Schema;
using DocuPipe.Clients.Standardization;
using DocuPipe.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DocuPipe;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddDocuPipeClient(IConfiguration configuration, string sectionName = "DocuPipe")
        {
            return services.AddDocuPipeClient(builder => builder.Bind(configuration.GetSection(sectionName)));
        }

        public IServiceCollection AddDocuPipeClient(Action<DocuPipeClientOptions> configure)
        {
            services.Configure(configure);
            RegisterClients(services);
            return services;
        }

        public IServiceCollection AddDocuPipeClient(Action<OptionsBuilder<DocuPipeClientOptions>> configure)
        {
            var optionsBuilder = services.AddOptions<DocuPipeClientOptions>();
            configure(optionsBuilder);

            RegisterClients(services);
            return services;
        }
    }

    private static void RegisterClients(IServiceCollection services)
    {
        services.AddHttpClient<IStandardizationClient, StandardizationClient>(ApplyOptions);

        services.AddHttpClient<IDocumentClient, DocumentClient>(ApplyOptions);

        services.AddHttpClient<ISchemaClient, SchemaClient>(ApplyOptions);
    }

    private static void ApplyOptions(IServiceProvider serviceProvider, HttpClient httpClient)
    {
        var options = serviceProvider.GetRequiredService<IOptions<DocuPipeClientOptions>>().Value;

        if (!string.IsNullOrWhiteSpace(options.BaseUrl))
        {
            httpClient.BaseAddress = new Uri(options.BaseUrl);
        }

        if (string.IsNullOrWhiteSpace(options.ApiKey))
        {
            return;
        }

        var headerName = string.IsNullOrWhiteSpace(options.ApiKeyHeaderName) ? "x-api-key" : options.ApiKeyHeaderName;
        httpClient.DefaultRequestHeaders.Remove(headerName);
        httpClient.DefaultRequestHeaders.Add(headerName, options.ApiKey);
    }
}
