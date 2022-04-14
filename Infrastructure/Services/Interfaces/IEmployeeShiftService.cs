using Core.Dtos.EmployeeShifts;

namespace Infrastructure.Services.Interfaces
{
    public interface IEmployeeShiftService
    {
        Task<List<EmployeeShiftDto>> GetEmployeeShifts(int? employeeId);
    }
}
