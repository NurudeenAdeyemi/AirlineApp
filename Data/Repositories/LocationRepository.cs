using AirlineApp.Data.Context;
using AirlineApp.Data.Entities;
using System.Linq.Expressions;

namespace AirlineApp.Data.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        protected readonly ApplicationDbContext _context;

        public LocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Location Add(Location location)
        {
            _context.Locations.Add(location);
            _context.SaveChanges();
            return location;
        }

        public bool Exist(Expression<Func<Location, bool>> expression)
        {
            return _context.Locations.Any(expression);
        }

        public Location? Get(Guid id)
        {
            var location = _context.Locations.Find(id);
            return location;
        }

        public IEnumerable<Location> GetListAsync(Expression<Func<Location, bool>>? expression = null)
        {
            if (expression != null) 
            {
                return _context.Locations.Where(expression).ToList();
            }
            return _context.Locations.ToList();
        }

        public Location Update(Location location)
        {
            _context.Locations.Update(location);
            _context.SaveChanges();
            return location;
        }
    }
}
