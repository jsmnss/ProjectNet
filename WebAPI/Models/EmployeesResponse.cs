namespace WebAPI.Models
{
    public class EmployeesResponse
    {
        public string Status { get; set; }
        public List<Employee> Employees { get; set; }
        public string Message { get; set; }
    }
}
