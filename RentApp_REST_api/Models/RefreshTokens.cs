namespace RentApp_REST_api.Models
{
    public class RefreshTokens
    {
        public int Id { get; set; }
        public string userId { get; set; }
        public string Token { get; set; }
        public string JwtId { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
