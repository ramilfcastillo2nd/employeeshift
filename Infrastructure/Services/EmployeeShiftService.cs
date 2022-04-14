using Core.Dtos.EmployeeShifts;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class EmployeeShiftService : IEmployeeShiftService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeWorksShiftRepository _employeeWorksShiftRepository;
        public EmployeeShiftService(IEmployeeRepository employeeRepository, IEmployeeWorksShiftRepository employeeWorksShiftRepository)
        {
            _employeeRepository = employeeRepository;
            _employeeWorksShiftRepository = employeeWorksShiftRepository;
        }
        public async Task<List<EmployeeShiftDto>> GetEmployeeShifts(int? employeeId)
        {
            var lstEmployeeShifts = new List<EmployeeShiftDto>();
            if (employeeId == null)
            {
                var employees = await _employeeRepository.Employees().AsNoTracking().ToListAsync();

                foreach (var employee in employees)
                {
                    var employeeShift = await _employeeWorksShiftRepository.EmployeeWorksShifts().AsNoTracking()
                        .Include(x => x.Shift)
                        .FirstOrDefaultAsync(x => x.EmployeeId == employee.EmployeeId);
                    var totalHours = 0.0;
                    if (employeeShift != null)
                        totalHours = (employeeShift.Shift.ShiftEnd - employeeShift.Shift.ShiftStart).TotalHours;

                    lstEmployeeShifts.Add(new EmployeeShiftDto
                    {
                        EmployeeId = employee.EmployeeId,
                        FullName = $"{employee.FirstName} {employee.Surname}",
                        TotalNumberWorkHours = totalHours
                    });
                }
            }
            else
            {
                var employee = await _employeeRepository.Employees().AsNoTracking().FirstOrDefaultAsync(x => x.EmployeeId == employeeId);

                if (employee != null)
                {
                    var employeeShift = await _employeeWorksShiftRepository.EmployeeWorksShifts().AsNoTracking()
                                                .Include(x => x.Shift)
                                                .FirstOrDefaultAsync(x => x.EmployeeId == employee.EmployeeId);
                    var totalHours = 0.0;
                    if (employeeShift != null)
                        totalHours = (employeeShift.Shift.ShiftEnd - employeeShift.Shift.ShiftStart).TotalHours;

                    lstEmployeeShifts.Add(new EmployeeShiftDto
                    {
                        EmployeeId = employee.EmployeeId,
                        FullName = $"{employee.FirstName} {employee.Surname}",
                        TotalNumberWorkHours = totalHours
                    });
                }
            }

            return lstEmployeeShifts;

        }
    }
}
