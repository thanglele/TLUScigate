using Duende.IdentityServer.Models;
using OAuthv2.Models;
using OAuthv2.Repository;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace OAuthv2.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private List<User> CacheUsers;
        private readonly IUserRepository _userRepository;
        private readonly TokenService _tokenService;

        private static readonly string _from = "lesythang2@gmail.com";
        private static readonly string _pass = "jyap afuo ntog iyry";

        private static readonly string _host = "smtp.gmail.com";
        private static readonly int _port = 587;

        public AuthenticationService(IUserRepository userRepository, TokenService tokenService)
        {
            _userRepository = userRepository;

            CacheUsers = userRepository.GetFullUser();
            _tokenService = tokenService;
        }

        public async void RenewCache()
        {
            Console.WriteLine("Update Cache");
            CacheUsers = await _userRepository.GetFullUserAsync();
        }

        public List<User> ListUsers()
        {
            RenewCache();
            return CacheUsers;
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

        public User CheckLoginWithCache(LoginRequest request)
        {
            try
            {
                for (int i = 0; i < CacheUsers.Count; i++)
                {
                    if (CacheUsers[i].Email == request.Email && _userRepository.VerifyPassword(request.Password, CacheUsers[i].PasswordHash) == true)
                    {
                        return CacheUsers[i];
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<User> CheckLoginWithDb(LoginRequest request)
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

        public async Task<ResponseToken> SaveTokenWithDb(User user)
        {
            int? maxrole = 10;
            try
            {
                /* Xử lý Token theo thứ tự:
                 * GenerateToken -> AddNewTokenAsync (repo) -> return static and tokenlogin*/

                //Tạo token
                Models.Token token = _tokenService.GenerateToken(await _userRepository.GetUserWithRolesAsync(user.IdUser));

                //Cấp token mới
                ResponseToken responseToken = new ResponseToken()
                {
                    staticID = 200,
                    Id = token.UserId,
                    AccessToken = token.AccessToken,
                    RefreshToken = token.RefeshToken,
                    ExpiresAt = token.ExpiresAt
                };
                RenewCache();

                responseToken.Messages = "Đăng nhập thành công, đang chuyển hướng...";
                responseToken.Email = user.Email;

                foreach (var userrole in user.UserRoles)
                {
                    if (userrole.IdRole < maxrole)
                    {
                        maxrole = userrole.IdRole;
                    }
                }

                responseToken.MaxRole = maxrole;

                return responseToken;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi trong quá trình cấp Token, mã lỗi: " + ex.ToString());
                return new ResponseToken()
                {
                    staticID = 500,
                    Id = user.IdUser,
                    Messages = "Có lỗi xảy ra trong quá trình đăng nhập, vui lòng thử lại sau.",
                    AccessToken = null,
                    RefreshToken = null,
                    ExpiresAt = null
                };
            }
        }

        #endregion

        #region REGISTER SERVICES
        public async Task<ResponseToken> AddNewUsersToDb(User NewUser)
        {
            try
            {
                NewUser.PasswordHash = _userRepository.HashPassword(NewUser.PasswordHash, out var salt);
                if(await _userRepository.AddUsertoDbAsync(NewUser) == true)
                {
                    CacheUsers = await _userRepository.GetFullUserAsync();
                    for (int i = 0; i < CacheUsers.Count(); i++)
                    {
                        //Kiểm tra thông tin có sẵn trong hệ thống
                        if(NewUser.Email == CacheUsers[i].Email)
                        {
                            if(await _userRepository.AddUserRoletoDbAsync(CacheUsers[i].IdUser) == false)
                            {
                                //Add infor không thành công, Rollback trans
                                //Xóa tài khoản đã thêm vào hệ thống
                                await _userRepository.RemoveUserDbAsync(CacheUsers[i]);

                                return new ResponseToken()
                                {
                                    staticID = 500,
                                    Id = null,
                                    Messages = "Có lỗi xảy ra trong quá trình đăng ký, vui lòng thử lại sau.",
                                    AccessToken = null,
                                    RefreshToken = null,
                                    ExpiresAt = null
                                };
                            }
                            else
                            {
                                int? maxrole = 10;
                                //Cấp token mới
                                Models.Token token = _tokenService.GenerateToken(CacheUsers[i]);
                                ResponseToken responseToken = new ResponseToken()
                                {
                                    staticID = 200,
                                    Id = token.UserId,
                                    AccessToken = token.AccessToken,
                                    RefreshToken = token.RefeshToken,
                                    ExpiresAt = token.ExpiresAt
                                };
                                RenewCache();

                                responseToken.Messages = "Đăng nhập thành công, đang chuyển hướng...";

                                foreach (var userrole in NewUser.UserRoles)
                                {
                                    if (userrole.IdRole < maxrole)
                                    {
                                        maxrole = userrole.IdRole;
                                    }
                                }

                                responseToken.MaxRole = maxrole;
                                responseToken.Email = NewUser.Email;

                                // Tạo HttpClient
                                using (HttpClient client = new HttpClient())
                                {
                                    try
                                    {
                                        // Thiết lập content là JSON
                                        var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(new
                                        {
                                            email = responseToken.Email,
                                            isActive = false,
                                            KeyDActive = "",
                                            SerialKey = ""
                                        }), Encoding.UTF8, "application/json");

                                        // Gửi POST request
                                        HttpResponseMessage response = await client.PostAsync("https://api.thanglele08.id.vn/DigitalActive/addUser", content);

                                        // Đọc kết quả trả về
                                        string result = await response.Content.ReadAsStringAsync();

                                        // Kiểm tra trạng thái
                                        if (response.IsSuccessStatusCode)
                                        {
                                            Console.WriteLine("Request thành công:");
                                            Console.WriteLine(result);
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Request thất bại. Mã lỗi: {response.StatusCode}");
                                            Console.WriteLine(result);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
                                    }
                                }

                                return responseToken;

                                //return await SaveTokenWithDb(CacheUsers[i]);
                            }    
                        }    
                    }
                    return new ResponseToken()
                    {
                        staticID = 500,
                        Id = null,
                        Messages = "Có lỗi xảy ra trong quá trình đăng ký, vui lòng thử lại sau.",
                        AccessToken = null,
                        RefreshToken = null,
                        ExpiresAt = null
                    };
                }
                return new ResponseToken()
                {
                    staticID = 500,
                    Id = null,
                    Messages = "Có lỗi xảy ra trong quá trình đăng ký, vui lòng thử lại sau.",
                    AccessToken = null,
                    RefreshToken = null,
                    ExpiresAt = null
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi trong quá trình đăng ký, mã lỗi: " + ex.ToString());
                return new ResponseToken()
                {
                    staticID = 500,
                    Id = NewUser.IdUser,
                    Messages = "Có lỗi xảy ra trong quá trình đăng ký, vui lòng thử lại sau.",
                    AccessToken = null,
                    RefreshToken = null,
                    ExpiresAt = null
                };
            }
        }
        public int ValidateInputRegister(Registerform request)
        {
            //Kiểm tra Chuỗi trống trong loggin
            if (string.IsNullOrEmpty(request.Password) == true || string.IsNullOrEmpty(request.Email) == true || string.IsNullOrEmpty(request.Email) == true)
            {
                return 400;
            }

            //Kiểm tra chuỗi thực thi, SQL Injection trong string
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

            //Kiểm tra chuỗi email có phải là email hợp lệ hay không
            string valueRegrex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (Regex.IsMatch(request.Email, valueRegrex) == false)
            {
                return 400;
            }

            //Kiểm tra thoát thành công
            return 200;
        }

        public bool CheckUserAvailable(string username)
        {
            RenewCache();
            for(int i = 0; i < CacheUsers.Count(); i++)
            {
                if(username == CacheUsers[i].Email)
                {
                    //Xuất hiện tài khoản sẵn trên hệ thống, trả false
                    return false;
                }    
            }
            return true;
        }
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
