using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using WebAPI.Controllers;
using WebAPI.Models;

namespace WebAPI.DAL
{
    public class EmployeeDAL : IEmployeeInterface
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly ILogger<EmployeeDAL> _logger;

        public EmployeeDAL(IConfiguration config, ILogger<EmployeeDAL> logger)
        {
            _httpClient = new HttpClient();
            _config = config;
            _logger = logger;
        }

        /// <summary>
        /// Métodp para obtener la lista de empleados de la API
        /// </summary>
        /// <returns>Lista de empleados</returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Employee>> GetEmployees()
        {
            _logger.LogInformation("Procespo para consumir empleados");
            try
            {
                
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var enpoint = _config.GetValue<string>("Urls:EmployeesApi");
                _logger.LogInformation($"Endpoint: {enpoint}");
                HttpResponseMessage resulEmployees = await _httpClient.GetAsync(enpoint);
                resulEmployees.EnsureSuccessStatusCode();
                if (resulEmployees.IsSuccessStatusCode)
                {
                    var infoResponse = await resulEmployees.Content.ReadAsStringAsync();
                    _logger.LogInformation($"Respuesta: {infoResponse}");
                    var result = JsonConvert.DeserializeObject<ResponseEmployeeAPI>(infoResponse);
                    if (result != null && result.Status == "success")
                    {
                        return result.Data;
                    }
                    else
                    {
                        _logger.LogError($"Error al obtener la lista de empleados.{result?.Message}");
                        throw new Exception($"Error al obtener la lista de empleados.{result?.Message}");
                    }
                    
                } else
                {
                    _logger.LogError("Error al obtener la lista de empleados.");
                    throw new Exception("Error al obtener la lista de empleados.");
                }
            }
            catch(Exception ex)
            {   
                _logger.LogError($"Error al obtener la lista de empleados, Error: ${ex.Message}");
                throw new Exception($"Error al obtener la lista de empleados, Error: ${ex.Message}");
            }
        }

        /// <summary>
        /// Métodp para obtener el empleado por el identificador de la API
        /// </summary>
        /// <param name="id">Identificador del empleado</param>
        /// <returns>Empleado</returns>
        /// <exception cref="Exception"></exception>
        public async Task<Employee> GetEmployeeById(int id)
        {
            _logger.LogInformation("Procespo para consumir el emmpleado por id");
            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var enpoint = _config.GetValue<string>("Urls:EmployeeApi");
                _logger.LogInformation($"Endpoint: {enpoint}");
                HttpResponseMessage resulEmployees = await _httpClient.GetAsync(enpoint + id);
                resulEmployees.EnsureSuccessStatusCode();
                if (resulEmployees.IsSuccessStatusCode)
                {
                    var infoResponse = await resulEmployees.Content.ReadAsStringAsync();
                    _logger.LogInformation($"Respuesta: {infoResponse}");
                    var result = JsonConvert.DeserializeObject<ResponseEmployeeAPI>(infoResponse);
                    if (result != null && result.Status == "success")
                    {
                        return result.Data[0];
                    }
                    else
                    {
                        _logger.LogError($"Error al obtener la lista de empleados.{result?.Message}");
                        throw new Exception($"Error al obtener la lista de empleados.{result?.Message}");
                    }
                }
                else
                {
                    _logger.LogError($"Error al obtener la lista de empleados. {resulEmployees.StatusCode}");
                    throw new Exception($"Error al obtener la lista de empleados. {resulEmployees.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener la lista de empleados, Error: ${ex.Message}");
                throw new Exception($"Error al obtener la lista de empleados, Error: ${ex.Message}");
            }
        }
    }
}
