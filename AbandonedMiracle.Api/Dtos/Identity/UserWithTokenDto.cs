namespace AbandonedMiracle.Api.Dtos.Identity;

public class UserWithTokenDto : UserDto
{
    public string Token { get; set; } = default!;
}