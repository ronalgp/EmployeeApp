namespace EmployeeApi.Entities;

public class Employees
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required DateOnly DOB { get; set; }
    public required string Gender { get; set; }
    public string? ImageUrl { get; set; }
    public required string City { get; set; }
    public required string Country { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
