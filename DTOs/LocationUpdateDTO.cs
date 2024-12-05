namespace AirlineApp.DTOs
{
    public class LocationUpdateDTO
    {
        public required string Country { get; init; } = default!;
        public required string City { get; init; } = default!;
    }
}
