using System.Net.Http.Json;
using DocuPipe.Clients.Job.Models;

namespace DocuPipe.Clients.Job;

public sealed class JobClient(HttpClient httpClient) : IJobClient
{
    public async Task<JobResponse?> GetJobAsync(string jobId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(jobId);

        using var response = await httpClient.GetAsync($"/job/{jobId}", cancellationToken).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        var payload = await response.Content.ReadFromJsonAsync<JobResponse>(cancellationToken).ConfigureAwait(false);
        return payload ?? null;
    }
}