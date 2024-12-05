using System.ComponentModel.DataAnnotations;

namespace AirlineApp.Data.Entities
{
    public class Location
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Country { get; set; } = default!;

        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string City { get; set; } = default!;
    }
}
