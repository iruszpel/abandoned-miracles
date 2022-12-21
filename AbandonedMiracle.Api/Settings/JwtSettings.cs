namespace AbandonedMiracle.Api.Settings;

public class JwtSettings
{
    public const string Section = "Jwt";
    public string Key { get; set; } = default!;
}