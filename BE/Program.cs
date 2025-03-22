using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TLUScience.Data;
using TLUScience.Services;
using TLUScience.Repository;
using System.Net.NetworkInformation;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.HttpOverrides;
using TLUScience.Interface;
using TLUScience.Entities;

Console.WriteLine("Starting Identity OAuth2");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "API TLU Scigate", Version = "v1" });

        // Thêm JWT Authentication vào Swagger UI
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Nhập token vào đây: Bearer {token}",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
    });

    //Cache RAM
    //Chuyển 1 phần dữ liệu từ DB -> Cache : Giảm tải cho hệ thống SQL
    builder.Services.AddMemoryCache();

    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                           ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])),
            ClockSkew = TimeSpan.Zero
        };

        // Xử lý sự kiện khi authentication thất bại
        options.Events = new JwtBearerEvents
        {
            // Log khi nhận token
            OnMessageReceived = context =>
            {
                var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();

                var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                if (string.IsNullOrEmpty(token))
                {
                    logger.LogWarning("No token found in Authorization header.");
                }
                else
                {
                    logger.LogInformation($"Token received: {token}");
                }

                return Task.CompletedTask;
            },

            // Log khi xác thực thất bại
            OnAuthenticationFailed = context =>
            {
                var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();

                logger.LogError("Authentication failed.");
                logger.LogError($"Error: {context.Exception.Message}");

                return Task.CompletedTask;
            },

            // Log và redirect khi token không hợp lệ hoặc thiếu
            OnChallenge = async context =>
            {
                var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();

                context.HandleResponse();

                logger.LogWarning("Authentication challenge triggered.");

                var loginUrl = "/login";
                var returnUrl = context.Request.Path;
                var redirectUrl = $"{loginUrl}?returnUrl={Uri.EscapeDataString(returnUrl)}";

                var html = $@"
            <html>
                <head>
                    <title>Redirecting...</title>
                </head>
                <body>
                    <script>
                        window.location.href = '{redirectUrl}';
                    </script>
                    <noscript>
                        <meta http-equiv='refresh' content='0;url={redirectUrl}' />
                    </noscript>
                    <p>Please wait while you're redirecting to the login page...</p>
                </body>
            </html>";

                context.Response.ContentType = "text/html";
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync(html);
            },

            // Log khi bị từ chối truy cập
            OnForbidden = async context =>
            {
                var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();

                logger.LogWarning("Access forbidden. User does not have the required permissions.");

                var loginUrl = "/login";
                var html = $@"
            <html>
                <head>
                    <title>Access Denied</title>
                </head>
                <body>
                    <script>
                        window.location.href = '{loginUrl}';
                    </script>
                    <noscript>
                        <meta http-equiv='refresh' content='0;url={loginUrl}' />
                    </noscript>
                    <p>Access denied. Redirecting to login page...</p>
                </body>
            </html>";

                context.Response.ContentType = "text/html";
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync(html);
            }
        };
    });

    builder.Services.AddMvc();

    // Add services to the container.
    builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IGiangVienRepository, GiangVienRepository>();
    builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

    builder.Services.AddScoped<ITapChiAnPhamRepository, TapChiAnPhamRepository>();
    builder.Services.AddScoped<ITapChiAnPhamService, TapChiAnPhamService>();

    builder.Services.AddScoped<IBaoCaoThongKeRepository, BaoCaoThongKeRepository>();
    builder.Services.AddScoped<IBaoCaoThongKeService, BaoCaoThongKeService>();

    builder.Services.AddScoped<ICongBoKhoaHocRepository, CongBoKhoaHocRepository>();
    builder.Services.AddScoped<ICongBoKhoaHocService, CongBoKhoaHocService>();

    builder.Services.AddScoped<INCKHSinhVienRepository, NCKHSinhVienRepository>();
    builder.Services.AddScoped<INCKHSinhVienService, NCKHSinhVienService>();

    builder.Services.AddScoped<ISinhVienNCKHRepository, SinhVienNCKHRepository>();
    builder.Services.AddScoped<ITienDoRepository, TienDoRepository>();
    builder.Services.AddScoped<IDeTaiNghienCuuRepository, DeTaiNghienCuuRepository>();
    builder.Services.AddScoped<ISinhVienRepository, SinhVienRepository>();

    builder.Services.AddScoped<ITacGiaCongBoRepository, TacGiaCongBoRepository>();



    // Đăng ký các service
    builder.Services.AddScoped<IGiangVienService, GiangVienService>();

    // Đăng ký TokenService
    builder.Services.AddSingleton<TokenService>();

    // Thêm CORS service
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAllOrigins", corsBuilder =>
        {
            corsBuilder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
        });
    });

    builder.Services.AddControllersWithViews();
    builder.Logging.ClearProviders();
    builder.Logging.AddConsole();

    var app = builder.Build();

    //if (args.Contains("/remove"))
    //{
    //    Console.WriteLine("Removing database and Migrations");
    //    try
    //    {
    //        var scope = app.Services.CreateScope();
    //        var services = scope.ServiceProvider;
    //        var context = services.GetRequiredService<ApplicationDbContext>();
    //        DbInitializer.Remove(context);

    //        // Xóa thư mục Migrations
    //        string migrationsPath = Path.Combine(Directory.GetCurrentDirectory(), "Migrations");
    //        if (Directory.Exists(migrationsPath))
    //        {
    //            Directory.Delete(migrationsPath, true);
    //            Console.WriteLine("Migrations folder deleted successfully.");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"An error occurred: {ex.Message}");
    //    }
    //    Console.WriteLine("Done remove Database and Migrations. Exiting.");
    //    return;
    //}

    //if (args.Contains("/seed"))
    //{
    //    Console.WriteLine("Seeding database...");
    //    // Seed Data
    //    var scope = app.Services.CreateScope();
    //    var services = scope.ServiceProvider;
    //    var context = services.GetRequiredService<ApplicationDbContext>();
    //    DbInitializer.Seed(context);
    //    Console.WriteLine("Done seeding database. Exiting.");
    //    return;
    //}

    app.UseCookiePolicy(new CookiePolicyOptions
    {
        MinimumSameSitePolicy = SameSiteMode.None,
        Secure = CookieSecurePolicy.Always
    });

    app.UseCors("AllowAllOrigins");

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();
    
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
    });

    app.Use(async (context, next) =>
    {
        if (context.Request.Path == "/")
        {
            context.Response.Redirect("/swagger");
            return;
        }
        await next();
    });

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseStatusCodePages(context =>
    {
        if (context.HttpContext.Response.StatusCode == 404)
        {
            context.HttpContext.Response.Redirect("https://api.thanglele08.id.vn/404");
        }

        if (context.HttpContext.Response.StatusCode == 500)
        {
            context.HttpContext.Response.Redirect("https://api.thanglele08.id.vn/500");
        }
        return Task.CompletedTask;
    });

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Auth}");

    app.Run();
}
catch (Exception ex) when (ex is not HostAbortedException)
{
    Console.WriteLine("Có lỗi xảy ra, mã lỗi: " + ex.ToString());
    throw;
}
finally
{
    Console.WriteLine("Shutdown Identity OAuth2");
}