using B2GTechTask.Infrastructure.DBContext;
using B2GTechTask.Infrastructure.Models;

namespace B2GTechTask.Infrastructure.Interfaces
{
    public interface IEmployeeRepository
    {
        public IEnumerable<Employee> GetEmployees(DateTime? hiredate);
        public EmployeeData GetEmployee(int employeeId);
        public void InsertEmployeePhoneNo(EmployeePhone employeePhone);
    }
}
