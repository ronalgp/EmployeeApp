using EmployeeApi.Dto;
using EmployeeApi.Entities;
using EmployeeApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers
{
    public class EmployeeController(IEmployeeRepository employeeRepository) : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<string>> GetEmployees()
        {
            return Ok(await employeeRepository.GetEmployees());
        }

        [HttpGet("GetEmployee/{email}")]
        public async Task<ActionResult<string>> GetEmployee(string email)
        {
            var employeeDetail = await employeeRepository.GetEmployee(email);
            if (employeeDetail == null) return BadRequest("Employee data not found");
            return Ok(await employeeRepository.GetEmployee(email));
        }

        [HttpPost("AddEmployee")]
        public async Task<ActionResult> AddEmployee(EmployeeDto employeeDto)
        {
            if (employeeDto == null) return BadRequest("Could not get the employee");

            var employeeDetail = await employeeRepository.GetEmployee(employeeDto.Email);
            if (employeeDetail != null) return BadRequest("Employee already exists.");

            var employee = new Employees()
            {
                Name = employeeDto.Name,
                Email = employeeDto.Email,
                DOB = employeeDto.DOB,
                Gender = employeeDto.Gender,
                City = employeeDto.City,
                Country = employeeDto.Country,
                CreatedAt = DateTime.Now
            };
            employeeRepository.AddEmployee(employee);

            if (await employeeRepository.SaveAllAsync()) return Ok("Employee added successfully.");
            return BadRequest("Failed to add employee.");
        }

        [HttpPost("UpdateEmployee")]
        public async Task<ActionResult> UpdateEmployee(EmployeeDto employeeDto)
        {
            if (string.IsNullOrEmpty(employeeDto.Email)) return BadRequest("Update failed.");

            var employeeDetail = await employeeRepository.GetEmployee(employeeDto.Email);
            if (employeeDetail == null) return BadRequest("Employee not found");

            employeeDetail.Name = employeeDto.Name ?? employeeDetail.Name;
            employeeDetail.DOB = employeeDto.DOB == default ? employeeDetail.DOB : employeeDto.DOB;
            employeeDetail.Gender = employeeDto.Gender ?? employeeDetail.Gender;
            employeeDetail.City = employeeDto.City ?? employeeDetail.City;
            employeeDetail.Country = employeeDto.Country ?? employeeDetail.Country;
            employeeDetail.UpdatedAt = DateTime.Now;

            employeeRepository.UpdateEmployee(employeeDetail);

            if (await employeeRepository.SaveAllAsync()) return Ok("Employee updated successfully.");
            return BadRequest("Failed to update employee");
        }

        [HttpGet("DeleteEmployee/{email}")]
        public async Task<ActionResult> DeleteEmployee(string email)
        {
            if (string.IsNullOrEmpty(email)) return BadRequest("Email not found.");

            var employeeDetail = await employeeRepository.GetEmployee(email);
            if (employeeDetail == null) return BadRequest("Employee not found");

            employeeRepository.DeleteEmployee(employeeDetail);

            if (await employeeRepository.SaveAllAsync()) return Ok("Employee deleted successfully");
            return BadRequest("Failed to deleted employee");
        }
        
    }
}
