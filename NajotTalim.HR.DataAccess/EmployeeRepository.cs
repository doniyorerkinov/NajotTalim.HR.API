using Microsoft.EntityFrameworkCore;
using NajotTalim.HR.DataAccess.Entities;
using System.Threading.Tasks;
using NajotTalim.HR.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajotTalim.HR.DataAccess
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;
        public EmployeeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Employee> CreateEmployee(Employee data)
        {
            await _dbContext.Employees.AddAsync(data);
            await _dbContext.SaveChangesAsync();
            return data;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _dbContext.Employees.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(int id, Employee data)
        {
                var updatedEmployee = _dbContext.Attach(data);
                updatedEmployee.State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return data;
        }
    }
}
