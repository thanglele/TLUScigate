﻿using TLUScience.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using TLUScience.Entities;

namespace TLUScience.Repository
{
    public interface IUserRepository
    {
        public string HashPassword(string password, out string salt);
        public bool VerifyPassword(string password, string storedHashWithSalt);
        //public Task<List<User>> GetFullUserAsync();
        public List<TaiKhoan> GetFullUser();
        public List<OTP> GetFullOTP();
        public void CleanOldOTP();
        public Task<TaiKhoan> ValidateUserAsync(LoginRequest request);
        public Task<TaiKhoan> AddNewPasswordtoDbAsync(TaiKhoan taiKhoan);
        public Task<TaiKhoan> RemovePasswordtoDbAsync(TaiKhoan taiKhoan);
        public Task<bool> AddNewOTP(OTP userOTP);
        public Task<bool> ChangeStaticOTP(OTP userOTP);
        //public Task<bool> AddUsertoDbAsync(TaiKhoan NewUser);
        //public Task<bool> RemoveUserDbAsync(TaiKhoan NewUser);
        //public Task<bool> AddUserRoletoDbAsync(int IDUser);
        //public Task<TaiKhoan> GetUserWithRolesAsync(int userId);
    }
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext SciGate_Auth;

        public UserRepository(AppDbContext Scigate_Auth)
        {
            this.SciGate_Auth = Scigate_Auth;
        }

        #region PREPARE CACHE
        public List<TaiKhoan> GetFullUser()
        {
            try
            {
                Console.WriteLine("GET CACHE USERS");
                return SciGate_Auth.TaiKhoans.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR REPOSITORY: " + ex.ToString());
                return null;
            }
        }

        public List<OTP> GetFullOTP()
        {
            try
            {
                Console.WriteLine("GET CACHE OTP");
                return SciGate_Auth.OTPs.ToList();
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

        public async Task<TaiKhoan> RemovePasswordtoDbAsync(TaiKhoan taiKhoan)
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

        #region OTP REPOSITORY
        public void CleanOldOTP()
        {
            try
            {
                List<OTP> userOTP = SciGate_Auth.OTPs.ToList();
                for (int i = 0; i < userOTP.Count(); i++)
                {
                    if ((DateTime.Now - userOTP[i].ThoiGianHetHan).TotalMinutes > 2 || userOTP[i].TrangThai == "DaSuDung")
                    {
                        SciGate_Auth.OTPs.Remove(userOTP[i]);
                    }
                }
                SciGate_Auth.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR REPOSITORY: " + ex.ToString());
            }
        }
        public async Task<bool> AddNewOTP(OTP userOTP)
        {
            try
            {
                SciGate_Auth.OTPs.Add(userOTP);
                await SciGate_Auth.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR REPOSITORY: " + ex.ToString());
                return false;
            }
        }
        public async Task<bool> ChangeStaticOTP(OTP userOTP)
        {
            try
            {
                userOTP.TrangThai = "DaSuDung";
                SciGate_Auth.OTPs.Update(userOTP);
                await SciGate_Auth.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR REPOSITORY: " + ex.ToString());
                return false;
            }
        }
        #endregion
    }
}