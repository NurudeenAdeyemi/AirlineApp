namespace AirlineApp.DTOs
{
    public class LocationCreateDTO
    {
        public required string Country { get; init; } = default!;
        public required string City { get; init; } = default!;
    }
}
