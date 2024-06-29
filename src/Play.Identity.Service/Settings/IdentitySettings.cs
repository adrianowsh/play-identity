namespace Play.Identity.Service.Settings;

public sealed class IdentitySettings
{
    public string AdminUserEmail { get; init; }
    public string AdminUserPassword { get; init; }
    public decimal StartingGil { get; init; }
}
