using Microsoft.Extensions.Caching.Memory;
using TLUScience.Models;
using TLUScience.Entities;
using TLUScience.Repository;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace TLUScience.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IMemoryCache _cache;
        private static readonly string _cacheKey = "CacheUsers";
        private readonly IUserRepository _userRepository;
        private readonly TokenService _tokenService;

        private static readonly string _from = "lesythang2@gmail.com";
        private static readonly string _pass = "jyap afuo ntog iyry";

        private static readonly string _host = "smtp.gmail.com";
        private static readonly int _port = 587;

        public AuthenticationService(IUserRepository userRepository, TokenService tokenService, IMemoryCache cache)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _cache = cache;
            LoadCache();
        }

        private void LoadCache()
        {
            if (!_cache.TryGetValue(_cacheKey, out List<TaiKhoan> users))
            {
                users = _userRepository.GetFullUser();   
                _cache.Set(_cacheKey, users, TimeSpan.FromMinutes(10));
            }
        }

        public void RenewCache()
        {
            Console.WriteLine("Update Cache...");
            var users = _userRepository.GetFullUser();
            _cache.Set(_cacheKey, users, TimeSpan.FromMinutes(10));
        }

        public List<TaiKhoan> ListUsers()
        {
            if (!_cache.TryGetValue(_cacheKey, out List<TaiKhoan> users))
            {
                LoadCache();
                users = _cache.Get<List<TaiKhoan>>(_cacheKey);
            }
            return users;
        }

        #region LOGIN SERVICES
        public int ValidateInput(LoginRequest request)
        {
            //Kiểm tra Chuỗi trống trong loggin
            if (string.IsNullOrEmpty(request.Password) == true || string.IsNullOrEmpty(request.Email) == true)
            {
                return 400;
            }

            ////Kiểm tra chuỗi thực thi, SQL Injection trong string
            //string valueRegrex = @"^[\w\s]";
            //if (Regex.IsMatch(request.Username, valueRegrex) == false || Regex.IsMatch(request.Password, valueRegrex) == false)
            //{
            //    return 400;
            //}

            ////Kiểm tra chuỗi mật khẩu có đạt đủ điều kiện mật khẩu mạnh hay không
            //valueRegrex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            //if (Regex.IsMatch(request.Password, valueRegrex) == false)
            //{
            //    return 400;
            //}

            //Kiểm tra thoát thành công
            return 200;
        }

        public TaiKhoan CheckLoginWithCache(LoginRequest request)
        {
            try
            {
                if (!_cache.TryGetValue(_cacheKey, out List<TaiKhoan> users))
                {
                    LoadCache();
                    users = _cache.Get<List<TaiKhoan>>(_cacheKey);
                }

                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].Email == request.Email && _userRepository.VerifyPassword(request.Password, users[i].MatKhau))
                    {
                        return users[i];
                    }      
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<TaiKhoan> CheckLoginWithDb(LoginRequest request)
        {
            try
            {
                return await _userRepository.ValidateUserAsync(request);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ResponseToken SaveTokenWithDb(TaiKhoan user)
        {
            try
            {
                /* Xử lý Token theo thứ tự:
                 * GenerateToken -> AddNewTokenAsync (repo) -> return static and tokenlogin*/

                //Tạo token
                Token token = _tokenService.GenerateToken(user);

                //Cấp token mới
                ResponseToken responseToken = new ResponseToken()
                {
                    staticID = 200,
                    Id = token.UserId,
                    AccessToken = token.AccessToken,
                    RefreshToken = token.RefeshToken,
                    ExpiresAt = token.ExpiresAt
                };

                responseToken.Messages = "Đăng nhập thành công, đang chuyển hướng...";
                responseToken.Email = user.Email;
                responseToken.Role = user.VaiTro; 

                return responseToken;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi trong quá trình cấp Token, mã lỗi: " + ex.ToString());
                return new ResponseToken()
                {
                    staticID = 500,
                    Id = user.ID,
                    Messages = "Có lỗi xảy ra trong quá trình đăng nhập, vui lòng thử lại sau.",
                    AccessToken = null,
                    RefreshToken = null,
                    ExpiresAt = null
                };
            }
        }

        public ResponseToken NewPassword(LoginRequest request)
        {
            try
            {
                if (!_cache.TryGetValue(_cacheKey, out List<TaiKhoan> users))
                {
                    LoadCache();
                    users = _cache.Get<List<TaiKhoan>>(_cacheKey);
                }

                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].Email == request.Email && users[i].MatKhau == null)
                    {
                        users[i].MatKhau = _userRepository.HashPassword(request.Password, out _);
                        _userRepository.AddNewPasswordtoDbAsync(users[i]);
                        //LoadCache();

                        Token token = _tokenService.GenerateToken(users[i]);
                        RenewCache();

                        return new ResponseToken
                        {
                            staticID = 200,
                            Id = token.UserId,
                            AccessToken = token.AccessToken,
                            RefreshToken = token.RefeshToken,
                            ExpiresAt = token.ExpiresAt,
                            Messages = "Cập nhật mật khẩu mới thành công, đang chuyển hướng...",
                            Email = users[i].Email,
                            Role = users[i].VaiTro
                        };
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region REGISTER SERVICES
        //public async Task<ResponseToken> AddNewUsersToDb(User newUser)
        //{
        //    try
        //    {
        //        newUser.PasswordHash = _userRepository.HashPassword(newUser.PasswordHash, out _);
        //        if (await _userRepository.AddUsertoDbAsync(newUser))
        //        {
        //            await RenewCache();
        //            var users = _cache.Get<List<User>>(_cacheKey);
        //            var user = users?.FirstOrDefault(u => u.Email == newUser.Email);

        //            if (user != null)
        //            {
        //                if (!await _userRepository.AddUserRoletoDbAsync(user.IdUser))
        //                {
        //                    await _userRepository.RemoveUserDbAsync(user);
        //                    return new ResponseToken { staticID = 500, Messages = "Lỗi đăng ký!" };
        //                }

        //                var token = _tokenService.GenerateToken(user);
        //                await RenewCache();

        //                return new ResponseToken
        //                {
        //                    staticID = 200,
        //                    Id = token.UserId,
        //                    AccessToken = token.AccessToken,
        //                    RefreshToken = token.RefeshToken,
        //                    ExpiresAt = token.ExpiresAt,
        //                    Messages = "Đăng ký thành công!",
        //                    Email = newUser.Email,
        //                    MaxRole = newUser.UserRoles.Min(ur => ur.IdRole)
        //                };
        //            }
        //        }
        //        return new ResponseToken { staticID = 500, Messages = "Lỗi đăng ký!" };
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Lỗi đăng ký: " + ex.ToString());
        //        return new ResponseToken { staticID = 500, Messages = "Lỗi đăng ký!" };
        //    }
        //}
        //public int ValidateInputRegister(Registerform request)
        //{
        //    //Kiểm tra Chuỗi trống trong loggin
        //    if (string.IsNullOrEmpty(request.Password) == true || string.IsNullOrEmpty(request.Email) == true || string.IsNullOrEmpty(request.Email) == true)
        //    {
        //        return 400;
        //    }

        //    //Kiểm tra chuỗi thực thi, SQL Injection trong string
        //    //string valueRegrex = @"^[\w\s]";
        //    //if (Regex.IsMatch(request.Username, valueRegrex) == false || Regex.IsMatch(request.Password, valueRegrex) == false)
        //    //{
        //    //    return 400;
        //    //}

        //    ////Kiểm tra chuỗi mật khẩu có đạt đủ điều kiện mật khẩu mạnh hay không
        //    //valueRegrex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
        //    //if (Regex.IsMatch(request.Password, valueRegrex) == false)
        //    //{
        //    //    return 400;
        //    //}

        //    //Kiểm tra chuỗi email có phải là email hợp lệ hay không
        //    string valueRegrex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        //    if (Regex.IsMatch(request.Email, valueRegrex) == false)
        //    {
        //        return 400;
        //    }

        //    //Kiểm tra thoát thành công
        //    return 200;
        //}

        //public bool CheckUserAvailable(string username)
        //{
        //    if (!_cache.TryGetValue(_cacheKey, out List<User> users))
        //    {
        //        LoadCache();
        //        users = _cache.Get<List<User>>(_cacheKey);
        //    }

        //    return users?.Any(u => u.Email == username) == false;
        //}
        #endregion

        #region mailServices
        public async Task<string> SendMail(string to, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(_host);

                mail.From = new MailAddress(_from);
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;

                mail.Priority = MailPriority.High;

                SmtpServer.Port = _port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(_from, _pass);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return "Mail sent!";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

    }
}
