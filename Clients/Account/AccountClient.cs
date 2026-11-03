using System.Net.Http.Json;
using DocuPipe.Clients.Account.Models;
using DocuPipe.Extensions;

namespace DocuPipe.Clients.Account;

public sealed class AccountClient(HttpClient httpClient) : IAccountClient
{
    public async Task<AccountResponse?> GetAccountAsync(CancellationToken cancellationToken = default)
    {
        using var response = await httpClient.GetAsync("/account", cancellationToken).ConfigureAwait(false);
        await response.EnsureSuccessWithBodyAsync(cancellationToken).ConfigureAwait(false);

        return await response.Content.ReadFromJsonAsync<AccountResponse>(cancellationToken).ConfigureAwait(false);
    }
}
