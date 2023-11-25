using employees.Data;
using employees.Entities;
using employees.Services.EmployeeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace employees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeRepository;

        public EmployeeController(IEmployeeService employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employees>>> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Employees>>> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null) { return NotFound("Employee Not Found"); }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<List<Employees>>> AddEmployee(Employees employee)
        {
            await _employeeRepository.AddEmployeeAsync(employee);
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpPut]
        public async Task<ActionResult<List<Employees>>> UpdateEmployee(Employees updatedEmployee)
        {
            await _employeeRepository.UpdateEmployeeAsync(updatedEmployee);
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employees>>> DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            return Ok(employees);
        }
    }
}
