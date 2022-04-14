using Infrastructure.Data.Entities;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IEmployeeWorksShiftRepository
    {
        IQueryable<EmployeeWorksShift> EmployeeWorksShifts();
    }
}
