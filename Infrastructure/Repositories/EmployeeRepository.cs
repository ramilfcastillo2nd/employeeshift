using Infrastructure.Data;
using Infrastructure.Data.Entities;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeShiftContext _context;
        public EmployeeRepository(EmployeeShiftContext context)
        {
            _context = context;
        }
        public IQueryable<Employee> Employees()
        {
            return _context.Employees;
        }
    }
}
