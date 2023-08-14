using System.ComponentModel.DataAnnotations;

namespace RentApp_REST_api.Models.Dto
{
    public class TokenRequestDTO
    {
        [Required]
        public string Token { get; set; }

        [Required]
        public string RefreshToken { get; set; }
    }
}
