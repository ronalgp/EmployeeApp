using EmployeeApi.Entities;

namespace EmployeeApi.Interfaces;

public interface IEmployeeRepository
{
    Task<IReadOnlyList<Employees>> GetEmployees();
    Task<Employees?> GetEmployee(string email);
    void AddEmployee(Employees employee);
    void UpdateEmployee(Employees employee);
    void DeleteEmployee(Employees employee);
    Task<bool> SaveAllAsync();
}
