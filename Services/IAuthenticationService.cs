using OAuthv2.Models;

namespace OAuthv2.Services
{
    public interface IAuthenticationService
    {
        public List<User> ListUsers();
        #region LOGIN
        public void RenewCache();
        public int ValidateInput(LoginRequest request);
        public User CheckLoginWithCache(LoginRequest request);
        public Task<User> CheckLoginWithDb(LoginRequest request);
        public Task<ResponseToken> SaveTokenWithDb(User user);
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
