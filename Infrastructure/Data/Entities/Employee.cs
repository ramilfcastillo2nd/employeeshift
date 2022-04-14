using System;
using System.Collections.Generic;

namespace Infrastructure.Data.Entities
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string Surname { get; set; } = null!;
    }
}
