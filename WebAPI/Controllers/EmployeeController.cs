using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WebAPI.Logic;
using WebAPI.Models;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase

    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly EmployeeOperation _employeeOperation;

        public EmployeeController(ILogger<EmployeeController> logger, EmployeeOperation employeeOperation)
        {
            _employeeOperation = employeeOperation;
            _logger = logger;
        }

        /// <summary>
        /// Método HTTP GET que consume una API para obtener la lista de los empleados
        /// </summary>
        /// <returns>Lista de empleados</returns>
        [HttpGet()]
        public async Task<IActionResult> GetEmployees()
        {
            EmployeesResponse response = new();
            try
            {
                response.Employees = await _employeeOperation.GetEmployees();
                response.Status = "ok";
                _logger.LogInformation($"Respuesta para obtener los empleados: {response}");
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener los empleado: {ex.Message}");
                response.Status = "error";
                response.Message = $"Se genero un error: {ex.Message}";
                return StatusCode(500, response);
            }
        }

        /// <summary>
        /// Método HTTP GET para Obtener la informacionde del empleado
        /// </summary>
        /// <param name="id">Identificador del empleado a buscar</param>
        /// <returns>Infomarcion del empleado</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> getEmployee(int id)
        {
            EmployeeResponse response = new();
            _logger.LogInformation($"Id del cliente: {id}");
            try
            {
                response.Employee = await _employeeOperation.GetEmployee(id);
                response.Status = "ok";
                _logger.LogInformation($"Respuesta para obtener el empleado: {response}");
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener el empleado: {ex.Message}");
                response.Status = "error";
                response.Message = $"Se genero un error: {ex.Message}";
                return StatusCode(500, response);
            }
        }

    }
}
