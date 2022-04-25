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
                        .Where(x => x.EmployeeId == employee.EmployeeId)
                        .ToListAsync();

                    var totalHours = 0.0;
                    if (employeeShift != null)
                        foreach(var shift in employeeShift)
                            totalHours += (shift.Shift.ShiftEnd - shift.Shift.ShiftStart).TotalHours;

                    totalHours = totalHours * 5 * 4;
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
                       .Where(x => x.EmployeeId == employee.EmployeeId)
                       .ToListAsync();

                    var totalHours = 0.0;
                    if (employeeShift != null)
                        foreach (var shift in employeeShift)
                            totalHours += (shift.Shift.ShiftEnd - shift.Shift.ShiftStart).TotalHours;

                    totalHours = totalHours * 5 * 4;

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
