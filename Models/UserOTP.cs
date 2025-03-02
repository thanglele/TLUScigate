using OAuthv2.Models;

namespace TLUScience.Models
{
    public class UserOTP
    {
        public int IdUser { get; set; }
        public short OTP { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        public DateTime ExpireAt { get; set; } = DateTime.Now.AddMinutes(5);
        public User User { get; set; }
    }
}
