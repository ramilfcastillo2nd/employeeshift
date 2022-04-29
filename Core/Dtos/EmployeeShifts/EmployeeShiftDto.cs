namespace Core.Dtos.EmployeeShifts
{
    public class EmployeeShiftDto
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Month { get; set; }
        public double TotalNumberWorkHours { get; set; }
    }
}
