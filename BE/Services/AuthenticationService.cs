using Microsoft.Extensions.Caching.Memory;
using TLUScience.Models;
using TLUScience.Repository;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using TLUScience.Entities;

namespace TLUScience.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IMemoryCache _cache;
        private static readonly string _cacheKey = "CacheUsers", _cacheOTP = "CacheOTPs";
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
                _cache.Set(_cacheKey, users, TimeSpan.FromMinutes(30));
            }
        }

        public void RenewCache()
        {
            Console.WriteLine("Update Cache...");
            var users = _userRepository.GetFullUser();
            var otps = _userRepository.GetFullOTP();
            _cache.Set(_cacheKey, users, TimeSpan.FromMinutes(30));
            _cache.Set(_cacheOTP, otps, TimeSpan.FromMinutes(15));
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
        public int ValidateInput(LoginRequest request, bool skip)
        {
            if (skip == true)
            {
                //Chỉ kiểm tra Email

                //Kiểm tra Chuỗi trống trong loggin
                if (string.IsNullOrEmpty(request.Email) == true || request.Email.Length > 255)
                {
                    return 400;
                }

                string valueRegrex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if (Regex.IsMatch(request.Email, valueRegrex) == false)
                {
                    return 400;
                }

                //Kiểm tra thoát thành công
                return 200;
            }
            else
            {
                //Kiểm tra Email và Password

                //Kiểm tra Chuỗi trống trong loggin
                if (string.IsNullOrEmpty(request.Password) == true || string.IsNullOrEmpty(request.Email) == true || request.Password.Length > 255 || request.Email.Length > 255)
                {
                    return 400;
                }

                string valueRegrex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if (Regex.IsMatch(request.Email, valueRegrex) == false)
                {
                    return 400;
                }

                ////Kiểm tra chuỗi mật khẩu có đạt đủ điều kiện mật khẩu mạnh hay không
                valueRegrex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
                if (Regex.IsMatch(request.Password, valueRegrex) == false)
                {
                    return 400;
                }

                //Kiểm tra thoát thành công
                return 200;
            }
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

                        Token token = _tokenService.GenerateToken(users[i]);
                        //RenewCache();

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
            finally
            {
                RenewCache();
            }
        }

        #endregion

        #region RESETSERVICES
        public async Task<bool> CheckOTP(OTPRequest OTPRequest)
        {
            try
            {
                //if(string.IsNullOrEmpty(OTPRequest.Email) == true) return false;

                RenewCache();

                if (!_cache.TryGetValue(_cacheKey, out List<TaiKhoan> users))
                {
                    RenewCache();
                    users = _cache.Get<List<TaiKhoan>>(_cacheKey);
                }
                var otps = _cache.Get<List<OTP>>(_cacheOTP);

                for (int i = 0; i < users.Count(); i++)
                {
                    if (OTPRequest.Email == users[i].Email)
                    {
                        for (int j = 0; j < otps.Count(); j++)
                        {
                            if (otps[j].MaOTP == OTPRequest.OTP && otps[j].TrangThai == "ChuaSuDung" && (otps[j].ThoiGianHetHan - DateTime.Now).TotalSeconds > 0)
                            {
                                return true;
                            }
                            Console.WriteLine("TIME: " + (DateTime.Now - otps[j].ThoiGianHetHan).TotalSeconds.ToString());
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public Task<TaiKhoan> RemovePassword(string Email)
        {
            try
            {
                if (!_cache.TryGetValue(_cacheKey, out List<TaiKhoan> users))
                {
                    RenewCache();
                    users = _cache.Get<List<TaiKhoan>>(_cacheKey);
                }

                for (int i = 0; i < users.Count(); i++)
                {
                    if (Email == users[i].Email)
                    {
                        users[i].MatKhau = null;
                        return _userRepository.RemovePasswordtoDbAsync(users[i]);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
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
        public async Task<bool> CheckStatusOTPAccount(LoginRequest loginRequest)
        {
            try
            {
                if(ValidateInput(loginRequest, true) == 400)
                {
                    _userRepository.CleanOldOTP();
                    RenewCache();

                    if (!_cache.TryGetValue(_cacheKey, out List<TaiKhoan> users))
                    {
                        RenewCache();
                        users = _cache.Get<List<TaiKhoan>>(_cacheKey);
                    }
                    var otps = _cache.Get<List<OTP>>(_cacheOTP);
                    int CountSent = 0;

                    for (int i = 0; i < users.Count(); i++)
                    {
                        // Kiểm tra tài khoản xuất hiện
                        if (users[i].Email == loginRequest.Email)
                        {
                            for (int j = 0; j < otps.Count(); j++)
                            {
                                // Đếm số OTP còn hoạt động
                                if (otps[j].TaiKhoanID == users[i].ID && (otps[j].ThoiGianHetHan - DateTime.Now).TotalSeconds > 0)
                                {
                                    CountSent++;
                                    if (CountSent > 3)
                                    {
                                        break;
                                    }
                                }
                                Console.WriteLine("EMAIL: " + users[i].Email + "Count: " + CountSent + " //// " + "TIME: " + (DateTime.Now - otps[j].ThoiGianHetHan).TotalSeconds.ToString());
                            }
                            if (CountSent > 3)
                            {
                                //Dừng logic nếu có trên 3 OTP hoạt động
                                break;
                            }
                            else
                            {
                                //Check OK
                                return true;
                            }
                        }
                    }
                    //Không có tài khoản trong hệ thống, trả lỗi về
                    return false;
                }
                else
                {
                    return false;
                }    
            }
            catch (Exception ex)
            {
                Console.WriteLine("SERVICES CHECK OTP ERROR: " + ex.ToString());
                return false;
            }
        }
        public async Task<bool> SendMail(LoginRequest loginRequest)
        {
            try
            {
                if (!_cache.TryGetValue(_cacheKey, out List<TaiKhoan> users))
                {
                    RenewCache();
                    users = _cache.Get<List<TaiKhoan>>(_cacheKey);
                }

                for (int i = 0; i < users.Count(); i++)
                {
                    if (loginRequest.Email == users[i].Email)
                    {
                        TaiKhoan taiKhoan = users[i];

                        OTP userOTP = new OTP()
                        {
                            TaiKhoanID = taiKhoan.ID,
                            MaOTP = new Random().Next(100000, 1000000).ToString(),
                            TrangThai = "ChuaSuDung"
                        };

                        if (await _userRepository.AddNewOTP(userOTP) == true)
                        {
                            MailMessage mail = new MailMessage();
                            SmtpClient SmtpServer = new SmtpClient(_host);

                            mail.From = new MailAddress(_from);
                            mail.To.Add(taiKhoan.Email);
                            mail.Subject = "Đây là mã xác minh của bạn " + userOTP.MaOTP;
                            mail.Body = @"
<div class=""""><div class=""aHl""></div><div id="":pi"" tabindex=""-1""></div><div id="":ps"" class=""ii gt"" jslog=""20277; u014N:xr6bB; 1:WyIjdGhyZWFkLWY6MTgxMDUyNjk3ODg0MzI2NTMxNiJd; 4:WyIjbXNnLWY6MTgxMDUyNjk3ODg0MzI2NTMxNiIsbnVsbCxudWxsLG51bGwsbnVsbCxudWxsLG51bGwsbnVsbCxudWxsLG51bGwsbnVsbCxudWxsLG51bGwsbnVsbCxudWxsLG51bGwsbnVsbCxudWxsLG51bGwsbnVsbCxudWxsLDBd"">
<div id="":p0"" class=""a3s aiL ""><u></u>
    <div style=""padding:0;margin:0;font-family:Tahoma;font-size:14px;display:block;background:#ffffff"" bgcolor=""#ffffff"">
        <img width=""1px"" height=""1px"" alt="""" class=""CToWUd"" data-bit=""iit"">
        <table align=""center"" cellpadding=""0"" cellspacing=""0"" width=""100%"" height=""100%"">
            <tbody>
                <tr>
                    <td align=""center"" valign=""top"" bgcolor=""#ffffff"" width=""100%"">
                        <table cellspacing=""0"" cellpadding=""0"" width=""100%"">
                            <tbody>
                                <tr>
                                    <td style=""background:#1f1f1f"" width=""100%"">
                                        <center>
                                            <table cellspacing=""0"" cellpadding=""0"" width=""100%"" style=""max-width:600px"">
                                                <tbody>
                                                    <tr>
                                                        <td valign=""top"" style=""background:#1f1f1f;padding:10px 10px 10px 20px"">
                                                            <a href=""https://scigate.thanglele08.id.vn/"" style=""text-decoration:none"">
                                                                <img src=""https://cdn.thanglele08.id.vn/img/lele.png"" height=""40"" alt=""lele Logo"" class=""CToWUd"" data-bit=""iit"">
                                                            </a>
                                                        </td>
                                                        <td valign=""top"" style=""background:#1f1f1f;padding:10px 15px 10px 10px"">
                                                            <table border=""0"" cellpadding=""0"" cellspacing=""0"" align=""right"">
                                                                <tbody>
                                                                    <tr>
                                                                        <td align=""right"" style=""color:#b9b9b9"">
                                                                            Hệ thống quản lý khoa học TLU
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td style=""background:#1660cf"" width=""100%"">
                                        <center>
                                            <table cellspacing=""0"" cellpadding=""10"" width=""100%"" style=""max-width:600px"">
                                                <tbody>
                                                    <tr>
                                                        <td style=""font-family:tahoma;background:#1660cf;color:#ffffff;font-weight:bold;font-size:16px;padding-bottom:0"">
                                                            THƯ XÁC THỰC OTP
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style=""font-style:italic;color:#ffffff;font-size:10pt"">
                                                            Email tự động vui lòng không phản hồi
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td style=""color:#282828"">
                                        <center>
                                            <table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width:600px"">
                                                <tbody>
                                                    <tr>
                                                        <td align=""left"" style=""padding:20px"">
                                                            <div>
                                                                <p>Nhập mã gồm 6 chữ số bên dưới để xác minh danh tính của bạn và lấy lại quyền truy cập vào tài khoản TLUScigate của bạn.</p>
                                                                <b>OTP: " + userOTP.MaOTP + @"</b><br>
                                                                <p>Mã OTP có có hiệu lực trong vòng 5 phút.</p>
                                                                <p>Cảm ơn bạn đã giúp chúng tôi bảo vệ tài khoản của bạn.</p>
                                                                <p>Hệ thống TLUScigate</p>
                                                                <p>===================================================</p>
                                                                <p>Nếu bạn không thực hiện thao tác này, hãy bỏ qua Email này.</p>
                                                                <p>Thời gian: " + userOTP.ThoiGianTao + @"</p>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign=""top"" style=""background-color:#363636"">
                                        <center>
                                            <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width:600px"">
                                                <tbody>
                                                    <tr>
                                                        <td valign=""top"" style=""padding:20px"">
                                                            <table cellspacing=""0"" cellpadding=""0"" width=""100%"">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style=""padding-top:15px;padding-right:20px;color:#e9e9e9"">
                                                                            <b>Trường Đại học Thủy lợi</b>
                                                                            <br>
                                                                            Địa chỉ: 175 Tây Sơn, Trung Liệt, Đống Đa, Hà Nội
                                                                        </td>
                                                                        <td style=""padding-top:15px;padding-right:20px;color:#e9e9e9"">
                                                                            <b>Hệ thống Quản lý Khoa học Trường Đại học Thủy lợi</b>
                                                                            <br>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </center>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</div>
";

                            mail.IsBodyHtml = true;
                            mail.Priority = MailPriority.High;

                            SmtpServer.Port = _port;
                            SmtpServer.Credentials = new System.Net.NetworkCredential(_from, _pass);
                            SmtpServer.EnableSsl = true;
                            await SmtpServer.SendMailAsync(mail);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR SEND MAIL: " + ex.ToString());
                return false;
            }
        }
        #endregion

    }
}