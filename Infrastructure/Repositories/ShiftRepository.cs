using Infrastructure.Data;
using Infrastructure.Data.Entities;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Repositories
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly EmployeeShiftContext _context;
        public ShiftRepository(EmployeeShiftContext context)
        {
            _context = context;
        }
        public IQueryable<Shift> Shifts()
        {
            return _context.Shifts;
        }
    }
}
