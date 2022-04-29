using Core.Dtos.EmployeeShifts;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

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

                    if (employeeShift != null)
                    {
                        //var months = new List<ShiftDisplayDto>();
                        foreach (var shift in employeeShift)
                        {
                            if (shift.Shift.ShiftStart.Month == shift.Shift.ShiftEnd.Month)
                            {
                                var totalDays = 1;

                                var hrs = (shift.Shift.ShiftEnd - shift.Shift.ShiftStart).TotalHours;
                                var totalHoursInMonth = totalDays * hrs * 5 * 4;

                                var empShiftCount = lstEmployeeShifts.Where(x => x.EmployeeId == employee.EmployeeId).ToList();

                                var employeeFullName = $"{employee.FirstName} {employee.Surname}";
                                var empId = employee.EmployeeId;

                                lstEmployeeShifts.Add(new EmployeeShiftDto
                                {
                                    EmployeeId = empId,
                                    FullName = employeeFullName,
                                    Month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(shift.Shift.ShiftStart.Month),
                                    TotalNumberWorkHours = totalHoursInMonth
                                });
                            }
                            else
                            {

                                int daysInFirstMonth = DateTime.DaysInMonth(shift.Shift.ShiftStart.Year, shift.Shift.ShiftStart.Month);
                                DateTime last = shift.Shift.ShiftStart.AddDays(daysInFirstMonth - 1);

                                var totalDaysFirstMonth = Math.Round((last - shift.Shift.ShiftStart).TotalDays) + 1;

                                var hrsFirstMonth = (last - shift.Shift.ShiftStart).TotalHours;
                                var totalHourInFirstMonth = totalDaysFirstMonth * hrsFirstMonth * 5 * 4;

                                var employeeFullName = $"{employee.FirstName} {employee.Surname}";
                                var empId = employee.EmployeeId;

                                lstEmployeeShifts.Add(new EmployeeShiftDto
                                {
                                    EmployeeId = empId,
                                    FullName = employeeFullName,
                                    Month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(shift.Shift.ShiftStart.Month),
                                    TotalNumberWorkHours = totalHourInFirstMonth
                                });

                                DateTime first = Convert.ToDateTime($"{shift.Shift.ShiftEnd.Month}/1/{shift.Shift.ShiftEnd.Year} {shift.Shift.ShiftEnd.Hour}:{shift.Shift.ShiftEnd.Minute}:{shift.Shift.ShiftEnd.Second}");

                                var totalDaysSecondMonth = Math.Round((shift.Shift.ShiftEnd - first).TotalDays) + 1;

                                var hrsSecondMonth = (shift.Shift.ShiftEnd - first).TotalHours;
                                var totalHourInSecondMonth = totalDaysSecondMonth * hrsSecondMonth;

                                lstEmployeeShifts.Add(new EmployeeShiftDto
                                {
                                    EmployeeId = empId,
                                    FullName = employeeFullName,
                                    Month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(shift.Shift.ShiftEnd.Month),
                                    TotalNumberWorkHours = totalHourInFirstMonth
                                });
                            }
                        }
                    }
                }
            }
            else
            {
                var employee = await _employeeRepository.Employees().AsNoTracking().FirstOrDefaultAsync(x => x.EmployeeId == employeeId);

                if (employee != null)
                {
                    var employeeShiftAssignment = await _employeeWorksShiftRepository.EmployeeWorksShifts().AsNoTracking()
                       .Include(x => x.Shift)
                       .Where(x => x.EmployeeId == employee.EmployeeId)
                       .ToListAsync();

                    if (employeeShiftAssignment != null)
                        foreach (var shift in employeeShiftAssignment)
                        {
                            if (shift.Shift.ShiftStart.Month == shift.Shift.ShiftEnd.Month)
                            {
                                var totalDays = 1;

                                var hrs = (shift.Shift.ShiftEnd - shift.Shift.ShiftStart).TotalHours;
                                var totalHoursInMonth = totalDays * hrs * 5 * 4;

                                var empShiftCount = lstEmployeeShifts.Where(x => x.EmployeeId == employee.EmployeeId).ToList();

                                var employeeFullName = $"{employee.FirstName} {employee.Surname}";
                                var empId = employee.EmployeeId;

                                lstEmployeeShifts.Add(new EmployeeShiftDto
                                {
                                    EmployeeId = empId,
                                    FullName = employeeFullName,
                                    Month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(shift.Shift.ShiftStart.Month),
                                    TotalNumberWorkHours = totalHoursInMonth
                                });
                            }
                            else
                            {

                                int daysInFirstMonth = DateTime.DaysInMonth(shift.Shift.ShiftStart.Year, shift.Shift.ShiftStart.Month);
                                DateTime last = shift.Shift.ShiftStart.AddDays(daysInFirstMonth - 1);

                                var totalDaysFirstMonth = Math.Round((last - shift.Shift.ShiftStart).TotalDays) + 1;

                                var hrsFirstMonth = (last - shift.Shift.ShiftStart).TotalHours;
                                var totalHourInFirstMonth = totalDaysFirstMonth * hrsFirstMonth * 5 * 4;

                                var empShiftCountFirst = lstEmployeeShifts.Where(x => x.EmployeeId == employee.EmployeeId).ToList();

                                var employeeFullName = $"{employee.FirstName} {employee.Surname}";
                                var empId = employee.EmployeeId;

                                lstEmployeeShifts.Add(new EmployeeShiftDto
                                {
                                    EmployeeId = empId,
                                    FullName = employeeFullName,
                                    Month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(shift.Shift.ShiftStart.Month),
                                    TotalNumberWorkHours = totalHourInFirstMonth
                                });

                                DateTime first = Convert.ToDateTime($"{shift.Shift.ShiftEnd.Month}/1/{shift.Shift.ShiftEnd.Year} {shift.Shift.ShiftEnd.Hour}:{shift.Shift.ShiftEnd.Minute}:{shift.Shift.ShiftEnd.Second}");

                                var totalDaysSecondMonth = Math.Round((shift.Shift.ShiftEnd - first).TotalDays) + 1;

                                var hrsSecondMonth = (shift.Shift.ShiftEnd - first).TotalHours;
                                var totalHourInSecondMonth = totalDaysSecondMonth * hrsSecondMonth;


                                lstEmployeeShifts.Add(new EmployeeShiftDto
                                {
                                    EmployeeId = empId,
                                    FullName = employeeFullName,
                                    Month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(shift.Shift.ShiftEnd.Month),
                                    TotalNumberWorkHours = totalHourInFirstMonth
                                });
                            }
                        }

                }
            }

            var result = (from item in lstEmployeeShifts
                           group item by new { item.FullName, item.Month } into grouping
             select new EmployeeShiftDto()
             {
                 EmployeeId = grouping.FirstOrDefault().EmployeeId,
                 FullName = grouping.FirstOrDefault().FullName,
                 Month = grouping.FirstOrDefault().Month,
                 TotalNumberWorkHours = grouping.Sum(c => c.TotalNumberWorkHours)    
             }).ToList();


            return result;

        }
    }
}
