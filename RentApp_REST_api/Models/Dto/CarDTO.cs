using System.ComponentModel.DataAnnotations;

namespace RentApp_REST_api.Models.Dto
{
    public class CarDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(25)]
        public string Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int HorsePower { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public int Price { get; set; }

        public int Rating { get; set; }

        [Required]
        [MaxLength(400)]
        public string Description { get; set; }

        [Required]
        [MaxLength(100)]
        public string Details { get; set; }
    }
}
