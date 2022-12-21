namespace AbandonedMiracle.Api.Settings;

public class JwtSettings
{
    public const string Section = "Jwt";
    public string Key { get; set; } = default!;
    public string Issuer { get; set; } = default!;
    public string Audience { get; set; } = default!;
}