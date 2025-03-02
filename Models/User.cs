using TLUScience.Models;

namespace OAuthv2.Models
{
    public class User
    {
        public int IdUser { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool IsActive { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public UserOTP userOTPs { get; set; }
    }

    public class UserReturn
    {
        public int IdUser { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateAt { get; set; }
    }

    public class LoginRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
    public class Registerform
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}
