using DocuPipe.Clients.Workflow.Models;

namespace DocuPipe.Clients.Workflow;

public interface IWorkflowClient
{
    Task<RunWorkflowResponse?> RunWorkflowAsync(string workflowId, RunWorkflowRequest request, CancellationToken cancellationToken = default);

    Task<List<WorkflowSummary>> ListWorkflowsAsync(CancellationToken cancellationToken = default);
}
