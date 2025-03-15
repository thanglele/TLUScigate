using TLUScience.Entities;
using TLUScience.Models;

namespace TLUScience.Repository
{
    public interface IUserRepository
    {
        public string HashPassword(string password, out string salt);
        public bool VerifyPassword(string password, string storedHashWithSalt);
        //public Task<List<User>> GetFullUserAsync();
        public List<TaiKhoan> GetFullUser();
        public Task<TaiKhoan> ValidateUserAsync(LoginRequest request);

        public Task<TaiKhoan> AddNewPasswordtoDbAsync(TaiKhoan taiKhoan);
        //public Task<bool> AddUsertoDbAsync(TaiKhoan NewUser);
        //public Task<bool> RemoveUserDbAsync(TaiKhoan NewUser);
        //public Task<bool> AddUserRoletoDbAsync(int IDUser);
        //public Task<TaiKhoan> GetUserWithRolesAsync(int userId);
    }
}
