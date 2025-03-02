namespace OAuthv2.Models
{
    public class Token
    {
        public int UserId { get; set; }
        public string AccessToken { get; set; }
        public string RefeshToken { get; set; }
        public DateTime ExpiresAt { get; set; }
    }

    public class ResponseToken
    {
        public int? staticID { get; set; }
        public int? Id { get; set; }
        public string? Email { get; set; }
        public int? MaxRole { get; set; }
        public string? Messages { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? ExpiresAt { get; set; }
    }
}
