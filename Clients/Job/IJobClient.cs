using DocuPipe.Clients.Job.Models;

namespace DocuPipe.Clients.Job;

public interface IJobClient
{
    Task<JobResponse?> GetJobAsync(string jobId, CancellationToken cancellationToken = default);
}