using NajotTalim.HR.API.Models;
using NajotTalim.HR.DataAccess;
using NajotTalim.HR.DataAccess.Entities;

namespace NajotTalim.HR.API.Services
{
    public class EmployeeCRUDService : IGenericCRUDService<EmployeeModel>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAddressRepository _addressRepository;

        public EmployeeCRUDService(IEmployeeRepository employeeRepository, IAddressRepository addressRepository)
        {
            _employeeRepository = employeeRepository;
            _addressRepository = addressRepository;
        }

        public async Task<EmployeeModel> Create(EmployeeModel employee)
        {
            var existingAddress = await _addressRepository.GetAddress(employee.AddressId);
            var newEmployee = new DataAccess.Entities.Employee
            {
                FullName = employee.FullName,
                Department = employee.Department,
                Email = employee.Email,
                Salary = employee.Salary
            };
            if(existingAddress != null)
            {
                newEmployee.Address = existingAddress;
            }
            var createdEmployee = await _employeeRepository.CreateEmployee(newEmployee);
            var result = new EmployeeModel
            {
                Id = createdEmployee.Id,
                FullName = createdEmployee.FullName,
                Department = createdEmployee.Department,
                Email = createdEmployee.Email,
                Salary = createdEmployee.Salary,
                AddressId = createdEmployee.Address.id
            };
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            return await _employeeRepository.DeleteEmployee(id);
        }

        public async Task<EmployeeModel> Get(int id)
        {
            var employee = await _employeeRepository.GetEmployee(id);
            var employeeModel = new EmployeeModel
            {
                Id = employee.Id,
                FullName = employee.FullName,
                Department = employee.Department,
                Email = employee.Email,
                Salary = employee.Salary
            };

            return employeeModel;
        }

        public async Task<IEnumerable<EmployeeModel>> GetAll()
        {
            var result = new List<EmployeeModel>();
            var employees = await _employeeRepository.GetEmployees();
            foreach (var employee in employees)
            {
                result.Add(new EmployeeModel
                {
                    Id = employee.Id,
                    FullName = employee.FullName,
                    Department = employee.Department,
                    Email = employee.Email,
                    Salary = employee.Salary
                });
            }
            return result;
        }

        public async Task<EmployeeModel> Update(int id, EmployeeModel model)
        {
            var employee = new Employee
            {
                Id = id,
                FullName = model.FullName,
                Department = model.Department,
                Email = model.Email,
                Salary = model.Salary
            };
            var updatedEmployee = await _employeeRepository.UpdateEmployee(id, employee);
            var result = new EmployeeModel
            {
                Id = updatedEmployee.Id,
                FullName = updatedEmployee.FullName,
                Department = updatedEmployee.Department,
                Email = updatedEmployee.Email,
                Salary = updatedEmployee.Salary
            };

            return result;
        }
    }
}
