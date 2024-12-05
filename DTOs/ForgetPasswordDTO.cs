using System.ComponentModel.DataAnnotations;

namespace AirlineApp.DTOs
{
    public class ForgetPasswordDTO
    {
        [Required]
        public string Email { get; set; }
    }
}
