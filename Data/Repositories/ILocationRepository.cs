using AirlineApp.Data.Entities;
using System.Linq.Expressions;

namespace AirlineApp.Data.Repositories
{
    public interface ILocationRepository
    {
        Location Add(Location location);
        Location Update(Location location);
        Location? Get(Guid id);
        IEnumerable<Location> GetListAsync(Expression<Func<Location, bool>>? expression = null);
        bool Exist(Expression<Func<Location, bool>> expression);
    }
}
