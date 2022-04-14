using System;
using System.Collections.Generic;

namespace Infrastructure.Data.Entities
{
    public partial class Shift
    {
        public int ShiftId { get; set; }
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }
        public string ShiftName { get; set; } = null!;
    }
}
