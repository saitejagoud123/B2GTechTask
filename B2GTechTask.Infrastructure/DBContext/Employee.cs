using System;
using System.Collections.Generic;

namespace B2GTechTask.Infrastructure.DBContext
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? HireDate { get; set; }
    }
}
