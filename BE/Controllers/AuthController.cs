﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TLUScience.Models;
using TLUScience.Services;
using System.Text.Json;
using Org.BouncyCastle.Crypto.Utilities;
using System.Runtime.InteropServices;
using Azure;
using TLUScience.Entities;

namespace TLUScience.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthenticationService authenService;

        public AuthController(IAuthenticationService authenticationService)
        {
            authenService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost("[controller]/login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (authenService.ValidateInput(request, false) == 400)
            {
                //Trả trạng thái không thành công do lỗi kí tự
                return StatusCode(400, new ResponseToken()
                {
                    staticID = 400,
                    Id = null,
                    Messages = "Thông tin đăng nhập không hợp lệ, vui lòng kiểm tra lại!"
                });
            }
            ResponseToken response = new ResponseToken();
            //Temp User đã nhận hash
            TaiKhoan temp_User = authenService.CheckLoginWithCache(request);
            if (temp_User == null)
            {
                temp_User = await authenService.CheckLoginWithDb(request);
                if (temp_User == null)
                {
                    //Trả trạng thái không thành công do không tồn tại tài khoản
                    return StatusCode(400, new ResponseToken()
                    {
                        staticID = 400,
                        Id = null,
                        Messages = "Email hoặc mật khẩu không chính xác"
                    });
                }
                else
                {
                    Console.WriteLine(temp_User);
                    authenService.RenewCache();
                    response = authenService.SaveTokenWithDb(temp_User);
                    return Ok(response);
                }
            }
            response = authenService.SaveTokenWithDb(temp_User);

            Response.Cookies.Append("TokenInfor", JsonSerializer.Serialize(response), new CookieOptions
            {
                Domain = ".thanglele08.id.vn",
                Path = "/",
                HttpOnly = false,
                Secure = true,
                Expires = DateTime.Now.AddHours(4),
                SameSite = SameSiteMode.None
            });
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("[controller]/NewPassword")]
        public IActionResult NewPassword([FromBody] LoginRequest RequestPassword)
        {
            if (authenService.ValidateInput(RequestPassword, false) == 400)
            {
                //Trả trạng thái không thành công do lỗi kí tự
                return StatusCode(400, new ResponseToken()
                {
                    staticID = 400,
                    Id = null,
                    Messages = "Thông tin yêu cầu không hợp lệ, vui lòng kiểm tra lại!"
                });
            }
            else
            {
                ResponseToken responseToken = authenService.NewPassword(RequestPassword);
                if (responseToken == null)
                {
                    return BadRequest(new ResponseToken()
                    {
                        staticID = 400,
                        Id = null,
                        Messages = "Có lỗi trong quá trình cập nhật mật khẩu, hãy kiểm tra lại.",
                        Email = RequestPassword.Email
                    });
                }
                else
                {
                    Response.Cookies.Append("TokenInfor", JsonSerializer.Serialize(responseToken), new CookieOptions
                    {
                        Domain = ".thanglele.cloud",
                        Path = "/",
                        HttpOnly = false,
                        Secure = true,
                        Expires = DateTime.Now.AddHours(4),
                        SameSite = SameSiteMode.None
                    });
                    return Ok(responseToken);
                }
            }
        }

        [AllowAnonymous]
        [HttpPost("[controller]/forgetpassword")]
        public async Task<IActionResult> ForgetPassword([FromBody] LoginRequest request)
        {
            if (authenService.ValidateInput(request, true) == 400)
            {
                //Trả trạng thái không thành công do lỗi kí tự
                return StatusCode(400, new ResponseToken()
                {
                    staticID = 400,
                    Id = null,
                    Messages = "Thông tin yêu cầu không hợp lệ, vui lòng kiểm tra lại!"
                });
            }

            if (await authenService.CheckStatusOTPAccount(request))
            {
                if (await authenService.SendMail(request) == true)
                {
                    return Ok(new ResponseToken()
                    {
                        staticID = 200,
                        Email = request.Email,
                        Messages = "Gửi Mail OTP thành công!"
                    });
                }
                else
                {
                    return StatusCode(500, new ResponseToken()
                    {
                        staticID = 500,
                        Email = request.Email,
                        Messages = "Lỗi không thể gửi mail, vui lòng thao tác lại!"
                    });
                }
            }
            else
            {
                //Trả trạng thái không thành công do gửi quá nhiều yêu cầu OTP
                return StatusCode(400, new ResponseToken()
                {
                    staticID = 400,
                    Email = request.Email,
                    Messages = "Thao tác bị chặn do gửi quá nhiều yêu cầu OTP!"
                });
            }
        }

        [AllowAnonymous]
        [HttpPost("[controller]/CheckOTP")]
        public async Task<IActionResult> CheckOTP([FromBody] OTPRequest OTPRequest)
        {
            if (await authenService.CheckOTP(OTPRequest) == true)
            {
                if (await authenService.RemovePassword(OTPRequest.Email) == null)
                {
                    return StatusCode(500, new ResponseToken()
                    {
                        staticID = 500,
                        Email = OTPRequest.Email,
                        Messages = "Lỗi hệ thống máy chủ, vui lòng thao tác lại!"
                    });
                }
                else
                {
                    return Ok(new ResponseToken()
                    {
                        staticID = 200,
                        Email = OTPRequest.Email,
                        Messages = "Xóa mật khẩu cũ thành công!"
                    });
                }
            }
            else
            {
                return StatusCode(400, new ResponseToken()
                {
                    staticID = 400,
                    Email = OTPRequest.Email,
                    Messages = "Sai mã OTP!"
                });
            }
        }

        [AllowAnonymous]
        [HttpGet("[controller]/logout")]
        public IActionResult Logout()
        {
            // Thiết lập cookie với thời gian hết hạn trong quá khứ
            Response.Cookies.Append("TokenInfor", string.Empty, new CookieOptions
            {
                Domain = ".thanglele08.id.vn",
                Path = "/",
                HttpOnly = false,
                Secure = true,
                Expires = DateTimeOffset.UtcNow.AddDays(-1),
                SameSite = SameSiteMode.None
            });
            return Redirect("/");
        }

        //[Authorize(Roles = "Administrator")]
        //[HttpGet("/listUsers")]
        //public IActionResult listUsers()
        //{
        //    List<User> users = authenService.ListUsers();
        //    List<UserReturn> response = new List<UserReturn>();
        //    for(int i = 0; i < users.Count; i++)
        //    {
        //        response.Add(new UserReturn()
        //        {
        //            IdUser = users[i].IdUser,
        //            FullName = users[i].FullName,
        //            Email = users[i].Email,
        //            PasswordHash = users[i].PasswordHash == "" ? "" : "Dữ liệu bị ẩn",
        //            IsActive = users[i].IsActive,
        //            CreateAt = users[i].CreateAt,
        //        });
        //    }    
        //    return Ok(response);
        //}

        //[Authorize(Roles = "Administrator")]
        //[HttpGet("/listUsers/{username}")]
        //public IActionResult actionResult(string email) 
        //{ 
        //    List<User> users = authenService.ListUsers();
        //    User user = users.Find(x => x.Email == email);
        //    if (user == null)
        //    {
        //        return StatusCode(404, new ResponseToken()
        //        {
        //            staticID = 404,
        //            Id = null,
        //            Messages = "Không tìm thấy người dùng!"
        //        });
        //    }
        //    else
        //    {
        //        UserReturn response = new UserReturn()
        //        {
        //            IdUser = user.IdUser,
        //            FullName = user.FullName,
        //            Email = user.Email,
        //            PasswordHash = user.PasswordHash,
        //            IsActive = user.IsActive,
        //            CreateAt = user.CreateAt,
        //        };
        //        return Ok(response);
        //    }    
        //}

        //[AllowAnonymous]
        //[HttpPost("/register")]
        //public async Task<IActionResult> Register([FromBody] Registerform UserRegis)
        //{
        //    if(authenService.ValidateInputRegister(UserRegis) == 400)
        //    {
        //        //Trả trạng thái không thành công do lỗi kí tự
        //        return StatusCode(400, new ResponseToken()
        //        {
        //            staticID = 400,
        //            Id = null,
        //            Messages = "Thông tin đăng ký không hợp lệ, vui lòng kiểm tra lại!"
        //        });
        //    }    

        //    if(authenService.CheckUserAvailable(UserRegis.Email) == false)
        //    {
        //        //Trả trạng thái không thành công do tài khoản này đã có sẵn
        //        return StatusCode(400, new ResponseToken()
        //        {
        //            staticID = 400,
        //            Id = null,
        //            Messages = "Tài khoản đăng kí đã có sẵn trong hệ thống!"
        //        });
        //    }    
        //    else
        //    {
        //        //Chưa hash
        //        User User = new User()
        //        {
        //            PasswordHash = UserRegis.Password,
        //            FullName = UserRegis.FullName,
        //            Email = UserRegis.Email,
        //            IsActive = false,
        //            CreateAt = DateTime.Now,
        //        };

        //        ResponseToken response = await authenService.AddNewUsersToDb(User);

        //        Response.Cookies.Append("TokenInfor", JsonSerializer.Serialize(response), new CookieOptions
        //        {
        //            Domain = ".thanglele08.id.vn",
        //            Path = "/",
        //            HttpOnly = false,
        //            Secure = true,
        //            Expires = DateTime.Now.AddHours(4),
        //            SameSite = SameSiteMode.None
        //        });
        //        return Ok(response);
        //    }
        //}
    }
}