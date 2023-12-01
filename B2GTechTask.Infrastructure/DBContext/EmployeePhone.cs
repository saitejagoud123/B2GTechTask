using System;
using System.Collections.Generic;

namespace B2GTechTask.Infrastructure.DBContext
{
    public partial class EmployeePhone
    {
        public int EmployeePhoneId { get; set; }
        public int EmployeeId { get; set; }
        public string? PhoneArea { get; set; }
        public string? Phone { get; set; }
        public string? PhoneExt { get; set; }
    }
}
