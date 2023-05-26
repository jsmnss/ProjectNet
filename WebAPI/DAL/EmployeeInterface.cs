using WebAPI.Models;

namespace WebAPI.DAL
{
    public interface IEmployeeInterface
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(int id);
    }
}
