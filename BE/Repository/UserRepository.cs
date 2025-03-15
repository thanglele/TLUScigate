using TLUScience.Models;
using TLUScience.Data;
using System;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using TLUScience.Entities;

namespace TLUScience.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext SciGate_Auth;
        
        public UserRepository(AppDbContext Scigate_Auth)
        {
            this.SciGate_Auth = Scigate_Auth;
        }

        #region PREPARE CACHE
        //Chỉ sử dụng thuộc tính này cho quá trình khởi tạo lần đầu tiên!
        public List<TaiKhoan> GetFullUser()
        {
            try
            {
                Console.WriteLine("GET CACHE USERS");
                List<TaiKhoan> listAccount = SciGate_Auth.TaiKhoans.ToList();
                return listAccount;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR REPOSITORY: " + ex.ToString());
                return null;
            }
        }

        //public async Task<List<User>> GetFullUserAsync()
        //{
        //    try
        //    {
        //        Console.WriteLine("GET CACHE USERS ASYNC");
        //        return await NDCC_Auth.Users.ToListAsync();
        //    }
        //    catch (Exception ex) 
        //    {
        //        Console.WriteLine("ERROR REPOSITORY: " + ex.ToString());
        //        return null;
        //    }
        //}
        #endregion

        #region LOGIN REPOSITORY
        //With login
        public bool VerifyPassword(string passwordinput, string storedHashWithSalt)
        {
            // Split hash and salt
            var parts = storedHashWithSalt.Split(':');
            if (parts.Length != 2) return false;

            var storedHash = Convert.FromBase64String(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);

            // Hash input password with the same salt
            using var pbkdf2 = new Rfc2898DeriveBytes(passwordinput, salt, 10000, HashAlgorithmName.SHA256);
            var computedHash = pbkdf2.GetBytes(32);

            // Compare computed hash with stored hash
            return storedHash.SequenceEqual(computedHash);
        }

        public async Task<TaiKhoan> ValidateUserAsync(LoginRequest request)
        {
            try
            {
                request.Email = Convert.ToString(request.Email);
                request.Password = Convert.ToString(request.Password);
                if (request.Email == string.Empty || request.Password == string.Empty)
                {
                    return null;
                }
                else
                {
                    List<TaiKhoan> listAccount = await SciGate_Auth.TaiKhoans.ToListAsync();
                    foreach (TaiKhoan account in listAccount)
                    {
                        if (account.Email == request.Email && VerifyPassword(request.Password, account.MatKhau) == true)
                        {
                            return account;
                        }
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("REPOSITORY ERROR: ValidateUserAsync -> " + ex.ToString());
                return null;
            }
        }

        public async Task<TaiKhoan> AddNewPasswordtoDbAsync(TaiKhoan taiKhoan)
        {
            try
            {
                SciGate_Auth.TaiKhoans.Update(taiKhoan);

                await SciGate_Auth.SaveChangesAsync();
                return taiKhoan;
            }
            catch (Exception ex)
            {
                Console.WriteLine("REPOSITORY ERROR: AddUserLocalAsync -> " + ex.ToString());
                return null;
            }
        }

        //public User ValidateUser(LoginRequest request)
        //{
        //    try
        //    {
        //        request.Username = Convert.ToString(request.Username);
        //        request.Password = Convert.ToString(request.Password);
        //        if (request.Username == string.Empty || request.Password == string.Empty)
        //        {
        //            return null;
        //        }
        //        else
        //        {
        //            List<User> listDb = NDCC_Auth.Users.ToList();
        //            foreach (User user in listDb)
        //            {
        //                if (user.Username.ToLower() == request.Username.ToLower() && VerifyPassword(request.Password, user.PasswordHash) == true)
        //                {
        //                    return user;
        //                }
        //            }
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("REPOSITORY ERROR: ValidateUserAsync -> " + ex.ToString());
        //        return null;
        //    }
        //}
        #endregion

        #region TOKEN REPOSITORY

        //public async Task<User> GetUserWithRolesAsync(int IdUser)
        //{
        //    return await NDCC_Auth.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).FirstOrDefaultAsync(u => u.IdUser == IdUser);
        //}

        #endregion

        #region REGISTER REPOSITORY
        //With register
        public string HashPassword(string password, out string salt)
        {
            // Generate a unique salt
            using var hmac = new HMACSHA512();
            salt = Convert.ToBase64String(hmac.Key);

            // Hash password using PBKDF2
            using var pbkdf2 = new Rfc2898DeriveBytes(password, hmac.Key, 10000, HashAlgorithmName.SHA256);
            var hash = pbkdf2.GetBytes(32);

            // Combine hash and salt into one string
            return $"{Convert.ToBase64String(hash)}:{salt}";
        }

        //public async Task<bool> AddUsertoDbAsync(User NewUser)
        //{
        //    try
        //    {
        //        NDCC_Auth.Users.Add(NewUser);
        //        await NDCC_Auth.SaveChangesAsync();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("REPOSITORY ERROR: AddUserLocalAsync -> " + ex.ToString());
        //        return false;
        //    }
        //}

        //public async Task<bool> RemoveUserDbAsync(User NewUser)
        //{
        //    try
        //    {
        //        NDCC_Auth.Users.Remove(NewUser);
        //        await NDCC_Auth.SaveChangesAsync();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("REPOSITORY ERROR: RemoveUserLocalAsync -> " + ex.ToString());
        //        return false;
        //    }
        //}

        //public async Task<bool> AddUserRoletoDbAsync(int IDUser)
        //{
        //    try
        //    {
        //        NDCC_Auth.UserRoles.Add(new UserRole()
        //        {
        //            IdUser = IDUser,
        //            IdRole = new Random().Next(4, 6)
        //        });
        //        await NDCC_Auth.SaveChangesAsync();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("REPOSITORY ERROR: AddUserRoleAsync -> " + ex.ToString());
        //        return false;
        //    }
        //}
        #endregion
    }
}
