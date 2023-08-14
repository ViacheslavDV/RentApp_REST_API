namespace RentApp_REST_api.Configurations
{
    public class JwtConfig
    {
        public string JwtSecret { get; set; }
        public TimeSpan ExpireTimeRate { get; set; }
    }
}
