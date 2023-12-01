using B2GTechTask.Core.Interfaces;
using B2GTechTask.Infrastructure.DBContext;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace B2GTechTask.Controllers
{
    //TODO : Add ILogger to all controllers
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Employee>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<Employee> Get([FromQuery] DateTime? hiredate)
        {
            return _employeeService.GetEmployees(hiredate);
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employee))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var employee = _employeeService.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
    }
}
