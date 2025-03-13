namespace TLUScience.Models
{
    public class TaiKhoan
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string? MatKhau { get; set; }
        public string VaiTro { get; set; }
        public ICollection<UserOTP> userOTPs { get; set; }
        public ICollection<GiangVien> GiangViens { get; set; }
    }

    //public class UserReturn
    //{
    //    public int IdUser { get; set; }
    //    public string Email { get; set; }
    //    public string? Password { get; set; }
    //}

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
        public string? Role { get; set; }
        public string? Messages { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? ExpiresAt { get; set; }
    }

    public class LoginRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

    public class OTPRequest
    {
        public string? Email { get; set; }
        public string? OTP { get; set; }
    }
}
