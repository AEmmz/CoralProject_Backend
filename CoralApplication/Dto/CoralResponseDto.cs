using CoralApplication.Models;

namespace CoralApplication.Dto;

public class CoralResponseDto
{
    public CoralModel Coral { get; set; }
    public DateTime Date { get; set; }
    public string Message { get; set; }
}