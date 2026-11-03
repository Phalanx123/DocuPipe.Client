using DocuPipe.Clients.Account.Models;

namespace DocuPipe.Clients.Account;

public interface IAccountClient
{
    Task<AccountResponse?> GetAccountAsync(CancellationToken cancellationToken = default);
}
