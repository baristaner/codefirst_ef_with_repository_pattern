using employees.Entities;

namespace employees.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<List<Employees>> GetAllEmployeesAsync();
        Task<Employees> GetEmployeeByIdAsync(int id);
        Task AddEmployeeAsync(Employees employee);
        Task UpdateEmployeeAsync(Employees updatedEmployee);
        Task DeleteEmployeeAsync(int id);
    }
}
