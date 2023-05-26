using WebAPI.DAL;
using WebAPI.Models;

namespace WebAPI.Logic
{
    public class EmployeeOperation
    {
        private readonly EmployeeDAL _employeeDAL;

        public EmployeeOperation(ILogger<EmployeeOperation> logger, EmployeeDAL employeeDAL)
        {
            _employeeDAL = employeeDAL;
        }

        /// <summary>
        /// Métodp para obtener la lista de empleados y asignar el salario anual
        /// </summary>
        /// <returns>Lista de empleados</returns>
        public async Task<List<Employee>> GetEmployees()
        {
            List<Employee> employees = await _employeeDAL.GetEmployees();

            employees.ForEach(employee => {
                employee.AnnualSalary = GenerateAnnualSalary(employee.Employee_salary);
            });

            return employees;
        }

        /// <summary>
        /// Métodp para obtener el empleado y asignar el salario anual
        /// </summary>
        /// <param name="id">Identificador del empleado</param>
        /// <returns>Empleado</returns>
        public async Task<Employee> GetEmployee(int id)
        {
            Employee employee = await _employeeDAL.GetEmployeeById(id);
            if (employee != null)
            {
                employee.AnnualSalary = GenerateAnnualSalary(employee.Employee_salary);
            }

            return employee;

        }


        /// <summary>
        /// Método para calcular el salario anual del empleado
        /// </summary>
        /// <param name="salary">Salario mensual del empleado</param>
        /// <returns>Retorna el salario anual del empleado</returns>
        public static double GenerateAnnualSalary(double salary)
        {
            return salary * 12;
        }
    }
}
