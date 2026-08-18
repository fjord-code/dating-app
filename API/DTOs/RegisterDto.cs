namespace API.DTOs;

public sealed class RegisterDto
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}