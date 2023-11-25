using employees.Data;
using employees.Entities;
using Microsoft.EntityFrameworkCore;

namespace employees.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DataContext _context;

        public EmployeeService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Employees>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employees> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task AddEmployeeAsync(Employees employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(Employees updatedEmployee)
        {
            var dbEmployee = await _context.Employees.FindAsync(updatedEmployee.EmployeeID);
            if (dbEmployee != null)
            {
                dbEmployee.Name = updatedEmployee.Name;
                dbEmployee.Department = updatedEmployee.Department;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var dbEmployee = await _context.Employees.FindAsync(id);
            if (dbEmployee != null)
            {
                _context.Employees.Remove(dbEmployee);
                await _context.SaveChangesAsync();
            }
        }
    }
}
