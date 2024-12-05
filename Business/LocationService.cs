using AirlineApp.Data.Entities;
using AirlineApp.Data.Repositories;
using AirlineApp.DTOs;

namespace AirlineApp.Business
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public BaseResponse<LocationDTO> AddLocation(LocationCreateDTO model)
        {
            //check if location exist with same country and city
            var locationExist = _locationRepository.Exist(l => l.Country.ToLower() == model.Country.ToLower() && l.City.ToLower() == model.City.ToLower());

            if (locationExist) 
            {
                return new BaseResponse<LocationDTO>
                {
                    Message = $"Location already exist",
                    Status = false
                };
            }

            //add the location
            var location = new Location
            {
                Country = model.Country,
                City = model.City
            };

            _locationRepository.Add(location);
            return new BaseResponse<LocationDTO>
            {
                Message = "Location added successfully",
                Status = true,
                Data = new LocationDTO(location.Id, location.Country, location.City)
            };
        }

        public IEnumerable<LocationDTO> GetAllLocations(string? country = null, string? city = null)
        {
            var locations = _locationRepository.GetListAsync();
            return locations.Select(l => new LocationDTO(l.Id, l.Country, l.City));
        }

        public BaseResponse<LocationDTO> GetLocation(Guid locationId)
        {
            var location = _locationRepository.Get(locationId);

            if (location == null)
            {
                return new BaseResponse<LocationDTO>
                {
                    Message = "Location can not be found",
                    Status = false
                };
            }

            return new BaseResponse<LocationDTO>
            {
                Message = "Location retrieved",
                Status = true,
                Data = new LocationDTO(locationId, location.Country, location.City)
            };
        }

        public BaseResponse<LocationDTO> UpdateLocation(Guid locationId, LocationUpdateDTO model)
        {
            var location = _locationRepository.Get(locationId);

            if (location == null)
            {
                return new BaseResponse<LocationDTO>
                {
                    Message = "Location can not be found",
                    Status = false
                };
            }

            location.Country = model.Country;
            location.City = model.City;
            _locationRepository.Update(location);
            return new BaseResponse<LocationDTO>
            {
                Message = "Location added successfully",
                Status = true,
                Data = new LocationDTO(location.Id, location.Country, location.City)
            };

        }
    }
}
