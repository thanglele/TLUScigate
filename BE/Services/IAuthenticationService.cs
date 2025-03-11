using Microsoft.Extensions.Caching.Memory;
using OAuthv2.Models;

namespace OAuthv2.Services
{
    public interface IAuthenticationService
    {
        public List<User> ListUsers();
        #region LOGIN
        public Task RenewCache();
        public int ValidateInput(LoginRequest request);
        public CacheUser CheckLoginWithCache(LoginRequest request);
        public Task<CacheUser> CheckLoginWithDb(LoginRequest request);
        public Task<ResponseToken> SaveTokenWithDb(CacheUser user);
        #endregion

        #region REGISTER
        public int ValidateInputRegister(Registerform request);
        public bool CheckUserAvailable(string username);
        public Task<ResponseToken> AddNewUsersToDb(User NewUser);
        #endregion

        #region MAILSERVICES
        public Task<string> SendMail(string to, string subject, string body);
        #endregion
    }
}
