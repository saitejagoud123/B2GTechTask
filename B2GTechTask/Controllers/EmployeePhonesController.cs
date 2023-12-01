using B2GTechTask.Core.Interfaces;
using B2GTechTask.Infrastructure.DBContext;
using Microsoft.AspNetCore.Mvc;

namespace B2GTechTask.Controllers
{
    //TODO : Add ILogger to all controllers
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeePhonesController : ControllerBase
    {
        //TODO : Need to implement different service and repos
        private readonly IEmployeeService _employeeService;

        public EmployeePhonesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public IActionResult Post(EmployeePhone employeePhone)
        {
            //TODO: Need to add validations
            _employeeService.InsertEmployeePhoneNo(employeePhone);
            return Ok();
        }
    }
}
