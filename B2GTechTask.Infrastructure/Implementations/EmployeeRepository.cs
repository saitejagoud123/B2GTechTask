using B2GTechTask.Infrastructure.DBContext;
using B2GTechTask.Infrastructure.Interfaces;
using B2GTechTask.Infrastructure.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace B2GTechTask.Infrastructure.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly B2GContext _b2GContext;

        public EmployeeRepository(B2GContext b2GContext)
        {
            _b2GContext = b2GContext;
        }

        public EmployeeData GetEmployee(int employeeId)
        {
            EmployeeData employeeData = null;
            var employeeIdParam = new SqlParameter("@EmployeeID", employeeId);
            var employees = _b2GContext.Employees.FromSqlRaw("EXEC [dbo].[proc_Employee_get_employee] @EmployeeID", employeeIdParam).ToList();
            var addresses = _b2GContext.EmployeeAddresses.FromSqlRaw("EXEC [dbo].[proc_Employee_get_address_ilst] @EmployeeID", employeeIdParam).ToList();
            var phonenos = _b2GContext.EmployeePhones.FromSqlRaw("EXEC [dbo].[proc_Employee_get_phone_list] @EmployeeID", employeeIdParam).ToList();

            if (employees != null && employees.Count > 0)
            {
                employeeData = new EmployeeData();
                var employee = employees.FirstOrDefault();
                var address = addresses.FirstOrDefault();
                var phoneNo = phonenos.FirstOrDefault();
                if (employee != null)
                {
                    employeeData.EmployeeId = employee.EmployeeId;
                    employeeData.DateOfBirth = employee.DateOfBirth;
                    employeeData.HireDate = employee.HireDate;
                    employeeData.FirstName = employee.FirstName;
                    employeeData.LastName = employee.LastName;
                }
                if (address != null)
                {
                    employeeData.EmployeeAddressId = address.EmployeeAddressId;
                    employeeData.StreetAddress = address.StreetAddress;
                    employeeData.City = address.City;
                    employeeData.State = address.State;
                    employeeData.ZipCode = address.ZipCode;
                }
                if (phoneNo != null)
                {
                    employeeData.EmployeePhoneId = phoneNo.EmployeePhoneId;
                    employeeData.PhoneArea = phoneNo.PhoneArea;
                    employeeData.Phone = phoneNo.Phone;
                    employeeData.PhoneExt = phoneNo.PhoneExt;
                }
            }
            return employeeData;
        }

        public IEnumerable<Employee> GetEmployees(DateTime? hiredate)
        {
            var hireDateParam = new SqlParameter("@HireYearFilter", hiredate == null ? DBNull.Value : hiredate);
            return _b2GContext.Employees.FromSqlRaw("EXEC [dbo].[proc_Employee_get_employee_list] @HireYearFilter", hireDateParam);
        }

        public void InsertEmployeePhoneNo(EmployeePhone employeePhone)
        {
            try
            {
                var employeeIdParam = new SqlParameter("@EmployeeID", employeePhone.EmployeeId);
                var PhoneParam = new SqlParameter("@Phone", employeePhone.Phone);
                var PhoneAreaParam = new SqlParameter("@PhoneArea", employeePhone.PhoneArea);
                var PhoneExtParam = new SqlParameter("@PhoneExt", employeePhone.PhoneExt);

                _b2GContext.Database.ExecuteSqlRaw("EXEC [dbo].[proc_Employee_insert_phone] @EmployeeID,@PhoneArea,@Phone,@PhoneExt",
                            employeeIdParam, PhoneParam, PhoneAreaParam, PhoneExtParam);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Type: {ex.GetType().FullName}");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            }
        }
    }
}
