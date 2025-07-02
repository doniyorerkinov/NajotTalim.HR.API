using NajotTalim.HR.API.Models;

namespace NajotTalim.HR.API
{
    public interface IEmployeeRepository
    {
        Task<Employee> CreateEmployee(Employee employee);

        Task<IEnumerable<Employee>> GetEmployees();
        
        Task<Employee> GetEmployee(int id);
        Task<Employee> UpdateEmployee(int id, Employee employee);
    }
}