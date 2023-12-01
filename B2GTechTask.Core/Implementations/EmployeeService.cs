using B2GTechTask.Core.Interfaces;
using B2GTechTask.Infrastructure.DBContext;
using B2GTechTask.Infrastructure.Interfaces;
using B2GTechTask.Infrastructure.Models;

namespace B2GTechTask.Core.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public EmployeeData GetEmployee(int employeeId)
        {
            return _employeeRepository.GetEmployee(employeeId);
        }

        public IEnumerable<Employee> GetEmployees(DateTime? hiredate)
        {
            return _employeeRepository.GetEmployees(hiredate);
        }

        public void InsertEmployeePhoneNo(EmployeePhone employeePhone)
        {
            _employeeRepository.InsertEmployeePhoneNo(employeePhone);
        }
    }
}
