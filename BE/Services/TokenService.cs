using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using OAuthv2.Models;

namespace OAuthv2.Services
{
    public class TokenService
    {
        #region SECRET KEY
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private static string HashSecretKey(string secretKey)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(secretKey));
                return Convert.ToBase64String(hashBytes);
            }
        }
        #endregion

        #region GENERATE TOKEN WORKING
        public Token GenerateToken(User user)
        {
            // Giải mã khóa từ Base64
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

            // Access token claims
            List<Claim> accessTokenClaims = new List<Claim>
    {
        new Claim("Email", user.Email),
        new Claim("FullName", user.FullName),
        new Claim("TokenType", "AccessToken"),
        new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString()),
        new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.UtcNow.AddHours(4)).ToUnixTimeSeconds().ToString()),
        new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString())
    };

            // Refresh token claims
            List<Claim> refreshTokenClaims = new List<Claim>
    {
        new Claim("Email", user.Email),
        new Claim("TokenType", "RefreshToken"),
        new Claim("UniqueIdentifier", Guid.NewGuid().ToString()),
        new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString()),
        new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.UtcNow.AddDays(1)).ToUnixTimeSeconds().ToString()),
        new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString())
    };

            // Kiểm tra UserRoles
            if (user.UserRoles != null)
            {
                foreach (var userRole in user.UserRoles)
                {
                    if (userRole?.Role?.Name != null)
                    {
                        accessTokenClaims.Add(new Claim(ClaimTypes.Role, userRole.Role.Name));
                        refreshTokenClaims.Add(new Claim(ClaimTypes.Role, userRole.Role.Name));
                    }
                }
            }

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            // Tạo Access Token
            SecurityTokenDescriptor accessTokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                Subject = new ClaimsIdentity(accessTokenClaims),
                Expires = DateTime.Now.AddHours(4),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            };

            var TempToken = tokenHandler.CreateToken(accessTokenDescriptor);
            string accessToken = tokenHandler.WriteToken(TempToken);

            // Tạo Refresh Token
            SecurityTokenDescriptor RefreshTokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                Subject = new ClaimsIdentity(refreshTokenClaims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            };

            TempToken = tokenHandler.CreateToken(RefreshTokenDescriptor);
            string refreshToken = tokenHandler.WriteToken(TempToken);

            return new Token()
            {
                UserId = user.IdUser,
                AccessToken = "Bearer " + accessToken,
                RefeshToken = "Bearer " + refreshToken,
                ExpiresAt = DateTime.Now.AddHours(4)
            };
        }

        #endregion

        #region TOKEN REFRESH WORKING
        //public ResponseToken RefreshToken(string refreshToken)
        //{
        //    // Xác thực refreshToken
        //    var handler = new JwtSecurityTokenHandler();
        //    var tokenValidationParameters = new TokenValidationParameters
        //    {
        //        ValidateIssuerSigningKey = true,
        //        IssuerSigningKey = new SymmetricSecurityKey(HashSecretKey(_reSecretKey)),
        //        ValidateIssuer = false,
        //        ValidateAudience = false,
        //        ClockSkew = TimeSpan.Zero // Không cho phép độ trễ
        //    };

        //    try
        //    {
        //        // Kiểm tra và giải mã refreshToken
        //        var principal = handler.ValidateToken(refreshToken, tokenValidationParameters, out var validatedToken);

        //        // Tạo lại accessToken
        //        var user = GetUserFromClaims(principal); // Phương thức để lấy thông tin người dùng từ claims
        //        return GenerateToken(user); // Tạo token mới
        //    }
        //    catch (SecurityTokenExpiredException)
        //    {
        //        throw new Exception("Refresh token đã hết hạn.");
        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception("Refresh token không hợp lệ.");
        //    }
        //}

        // Phương thức để lấy thông tin người dùng từ claims
        //private User GetUserFromClaims(ClaimsPrincipal principal)
        //{
        //    // Lấy thông tin người dùng từ claims
        //    var username = principal.FindFirst(ClaimTypes.Name)?.Value;
        //    // Tìm kiếm người dùng trong cơ sở dữ liệu và trả về
        //    return userService.FindByUsername(username); // Giả sử có userService để tìm kiếm người dùng
        //}
        #endregion
    }
}