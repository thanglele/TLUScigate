using Microsoft.Extensions.Caching.Memory;
using TLUScience.Models;
using TLUScience.Entities;

namespace TLUScience.Services
{
    public interface IAuthenticationService
    {
        public List<TaiKhoan> ListUsers();
        #region LOGIN
        public void RenewCache();
        public int ValidateInput(LoginRequest request);
        public TaiKhoan CheckLoginWithCache(LoginRequest request);
        public Task<TaiKhoan> CheckLoginWithDb(LoginRequest request);
        public ResponseToken SaveTokenWithDb(TaiKhoan user);
        public ResponseToken NewPassword(LoginRequest request);
        #endregion

        #region REGISTER
        //public int ValidateInputRegister(Registerform request);
        //public bool CheckUserAvailable(string username);
        //public Task<ResponseToken> AddNewUsersToDb(User NewUser);
        #endregion

        #region MAILSERVICES
        public Task<string> SendMail(string to, string subject, string body);
        #endregion
    }
}
