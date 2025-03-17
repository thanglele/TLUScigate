using TLUScience.Entities;
using TLUScience.Models;

namespace TLUScience.Services
{
    public interface IAuthenticationService
    {
        public List<TaiKhoan> ListUsers();
        #region LOGIN
        public void RenewCache();
        public int ValidateInput(LoginRequest request, bool skip);
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

        #region RESETSERVICES
        public Task<bool> CheckOTP(OTPRequest OTPRequest);
        public Task<TaiKhoan> RemovePassword(string Email);
        #endregion

        #region MAILSERVICES
        public Task<bool> CheckStatusOTPAccount(LoginRequest loginRequest);
        public Task<bool> SendMail(LoginRequest loginRequest);
        #endregion
    }
}