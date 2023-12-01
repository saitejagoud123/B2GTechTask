namespace B2GTechTask.Infrastructure.Models
{
    public partial class EmployeeData
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? HireDate { get; set; }
        public int EmployeeAddressId { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public int EmployeePhoneId { get; set; }
        public string? PhoneArea { get; set; }
        public string? Phone { get; set; }
        public string? PhoneExt { get; set; }
    }
}
