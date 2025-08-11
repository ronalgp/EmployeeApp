using EmployeeApi.Data;
using EmployeeApi.Entities;
using EmployeeApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Repositories;

public class EmployeeRepository(EmployeeDBContext context) : IEmployeeRepository
{
    public async Task<IReadOnlyList<Employees>> GetEmployees()
    {
        return await context.Employees.ToListAsync();
    }

    public async Task<Employees?> GetEmployee(string email)
    {
        return await context.Employees.SingleOrDefaultAsync(x => x.Email == email);
    }

    public void AddEmployee(Employees employee)
    {
        context.Employees.Add(employee);
    }

    public void UpdateEmployee(Employees employee)
    {
        context.Employees.Update(employee);
    }
    
    public void DeleteEmployee(Employees employee)
    {
        context.Employees.Remove(employee);
    }
    public async Task<bool> SaveAllAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}
