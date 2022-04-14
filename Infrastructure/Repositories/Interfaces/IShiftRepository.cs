using Infrastructure.Data.Entities;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IShiftRepository
    {
        IQueryable<Shift> Shifts();
    }
}
