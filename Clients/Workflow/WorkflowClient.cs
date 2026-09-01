using System.Net.Http.Json;
using DocuPipe.Clients.Workflow.Models;
using DocuPipe.Extensions;

namespace DocuPipe.Clients.Workflow;

public sealed class WorkflowClient(HttpClient httpClient) : IWorkflowClient
{
    public async Task<RunWorkflowResponse?> RunWorkflowAsync(string workflowId, RunWorkflowRequest request,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(workflowId);
        ArgumentNullException.ThrowIfNull(request);

        using var response = await httpClient
            .PostAsDocuPipeJsonAsync($"/v2/workflow/{Uri.EscapeDataString(workflowId)}/run", request, cancellationToken)
            .ConfigureAwait(false);
        await response.EnsureSuccessWithBodyAsync(cancellationToken).ConfigureAwait(false);

        var payload = await response.Content.ReadFromJsonAsync<RunWorkflowResponse>(cancellationToken).ConfigureAwait(false);
        return payload ?? null;
    }

    public async Task<List<WorkflowSummary>> ListWorkflowsAsync(CancellationToken cancellationToken = default)
    {
        using var response = await httpClient.GetAsync("/workflows", cancellationToken).ConfigureAwait(false);
        await response.EnsureSuccessWithBodyAsync(cancellationToken).ConfigureAwait(false);

        var payload = await response.Content.ReadFromJsonAsync<List<WorkflowSummary>>(cancellationToken).ConfigureAwait(false);
        return payload ?? [];
    }
}
