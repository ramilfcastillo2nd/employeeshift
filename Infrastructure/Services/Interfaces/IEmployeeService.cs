using Core.Dtos.Employees;

namespace Infrastructure.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetllEmployees();
    }
}
