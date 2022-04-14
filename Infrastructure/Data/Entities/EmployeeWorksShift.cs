using System;
using System.Collections.Generic;

namespace Infrastructure.Data.Entities
{
    public partial class EmployeeWorksShift
    {
        public int EmployeeId { get; set; }
        public int ShiftId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual Shift Shift { get; set; } = null!;
    }
}
