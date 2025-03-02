using OAuthv2.Models;

namespace OAuthv2.Repository
{
    public interface IUserRepository
    {
        public string HashPassword(string password, out string salt);
        public bool VerifyPassword(string password, string storedHashWithSalt);
        public Task<List<User>> GetFullUserAsync();
        public List<User> GetFullUser();
        public Task<User> ValidateUserAsync(LoginRequest request);
        public Task<bool> AddUsertoDbAsync(User NewUser);
        public Task<bool> RemoveUserDbAsync(User NewUser);
        public Task<bool> AddUserRoletoDbAsync(int IDUser);
        public Task<User> GetUserWithRolesAsync(int userId);
    }
}
