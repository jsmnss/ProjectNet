namespace WebAPI.Models
{
    public class EmployeeResponse
    {
        public string Status { get; set; }
        public Employee Employee { get; set; }
        public string Message { get; set; }
    }
}
