namespace EmployeeApi.Dto;

public class EmployeeDto
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateOnly DOB { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string? ImageUrl { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
}
