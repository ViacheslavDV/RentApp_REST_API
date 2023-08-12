using System.ComponentModel.DataAnnotations;

namespace RentApp_REST_api.Models.Dto
{
    public class UserLoginRequestDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
