using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public sealed class RegisterDto
{
    [Required]
    [Length(minimumLength: 4, maximumLength: 8)]
    public string Username { get; set; } = string.Empty;

    [Required]
    [Length(minimumLength: 4, maximumLength: 8)]
    public string Password { get; set; } = string.Empty;
}
