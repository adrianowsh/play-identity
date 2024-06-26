using Duende.IdentityServer.Models;

namespace Play.Identity.Service.Settings;

public sealed class IdentityServerSettings
{
     public IReadOnlyCollection<ApiScope> ApiScopes { get; init; } = Array.Empty<ApiScope>();
     public IReadOnlyCollection<Client> Clients { get; init; }
     public IReadOnlyCollection<IdentityResource> IdentityResources =>
        [
             new IdentityResources.OpenId(),
             new IdentityResources.Profile()
        ];
}
