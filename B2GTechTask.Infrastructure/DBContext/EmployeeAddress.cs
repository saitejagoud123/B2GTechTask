using System;
using System.Collections.Generic;

namespace B2GTechTask.Infrastructure.DBContext
{
    public partial class EmployeeAddress
    {
        public int EmployeeAddressId { get; set; }
        public int EmployeeId { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
    }
}
