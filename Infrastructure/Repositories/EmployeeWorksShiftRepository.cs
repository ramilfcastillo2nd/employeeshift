using Infrastructure.Data;
using Infrastructure.Data.Entities;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Repositories
{
    public class EmployeeWorksShiftRepository : IEmployeeWorksShiftRepository
    {
        private readonly EmployeeShiftContext _context;
        public EmployeeWorksShiftRepository(EmployeeShiftContext context)
        {
            _context = context;
        }
        public IQueryable<EmployeeWorksShift> EmployeeWorksShifts()
        {
            return _context.EmployeeWorksShifts;
        }
    }
}
