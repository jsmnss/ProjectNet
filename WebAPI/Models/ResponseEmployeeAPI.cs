namespace WebAPI.Models
{
    public class ResponseEmployeeAPI
    {
        public string Status { get; set; }
        public List<Employee> Data { get; set; }
        public string Message { get; set; }
        
    }
}
