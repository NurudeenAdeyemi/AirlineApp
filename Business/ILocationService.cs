using AirlineApp.DTOs;

namespace AirlineApp.Business
{
    public interface ILocationService
    {
        BaseResponse<LocationDTO> AddLocation(LocationCreateDTO model);
        BaseResponse<LocationDTO> UpdateLocation(Guid locationId, LocationUpdateDTO model);
        BaseResponse<LocationDTO> GetLocation(Guid locationId);
        IEnumerable<LocationDTO> GetAllLocations(string? country = null, string? city = null);
    }
}
