using Core.Dtos.Employees;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<List<EmployeeDto>> GetllEmployees()
        {
            var employees = await _employeeRepository.Employees().AsNoTracking().ToListAsync();
            var employeesMapped = employees.Select(x => new EmployeeDto { 
                EmployeeId = x.EmployeeId,
                FullName = $"{x.FirstName} {x.Surname}"
            }).ToList();

            return employeesMapped;
        }
    }
}
