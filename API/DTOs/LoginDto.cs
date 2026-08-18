namespace API.DTOs;

public sealed class LoginDto
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}