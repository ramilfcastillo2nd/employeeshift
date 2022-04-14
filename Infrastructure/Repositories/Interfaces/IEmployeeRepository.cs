using Infrastructure.Data.Entities;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> Employees();
    }
}
