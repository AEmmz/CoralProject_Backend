using CoralApplication.Models;

namespace CoralApplication.Dto;

public class UserResponseDto
{
    public UserModel UserDetails { get; set; }
    public DateTime Date { get; set; }
    public string Message { get; set; }
}