using NajotTalim.HR.API.Models;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace NajotTalim.HR.API
{
    public static class MockEmployeeRepository
    {
        // CuncurrentDictionary multithreadingda foydalaniladi, bu api da ishlatilganda bir vaqtda bir nechta request kelsa bu thread save bo'ladi
        private static ConcurrentDictionary<int, Employee> _employees = new ConcurrentDictionary<int, Employee>();

        public static void Init()
        {
            _employees.TryAdd(1, new Employee { Id = 1, FullName = "Ali Valiyev", Department = "IT", Email = "ali.valiyev@example.com" });
            _employees.TryAdd(2, new Employee { Id = 2, FullName = "Gulnora Karimova", Department = "HR", Email = "gulnora.k@example.com" });
            _employees.TryAdd(3, new Employee { Id = 3, FullName = "Botir Saidov", Department = "Sales", Email = "botir.s@example.com" });
            _employees.TryAdd(4, new Employee { Id = 4, FullName = "Madina Khakimova", Department = "Marketing", Email = "madina.h@example.com" });
            _employees.TryAdd(5, new Employee { Id = 5, FullName = "Rustam Ismoilov", Department = "Finance", Email = "rustam.i@example.com" });
            _employees.TryAdd(6, new Employee { Id = 6, FullName = "Zarina Abdullayeva", Department = "Operations", Email = "zarina.a@example.com" });
            _employees.TryAdd(7, new Employee { Id = 7, FullName = "Shuhrat Pulatov", Department = "IT", Email = "shuhrat.p@example.com" });
            _employees.TryAdd(8, new Employee { Id = 8, FullName = "Dilnoza Alimova", Department = "HR", Email = "dilnoza.a@example.com" });
            _employees.TryAdd(9, new Employee { Id = 9, FullName = "Farrukh Komilov", Department = "Sales", Email = "farrukh.k@example.com" });
            _employees.TryAdd(10, new Employee { Id = 10, FullName = "Laylo Nurullayeva", Department = "Marketing", Email = "laylo.n@example.com" });
        }

        public static async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await Task.FromResult(_employees.Values);
        }

        public static async Task<Employee> GetEmployee(int id)
        {
            return await Task.FromResult(_employees[id]);
        }
    }
}
