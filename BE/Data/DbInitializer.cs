using Microsoft.AspNetCore.Authentication;
using OAuthv2.Models;
using OAuthv2.Repository;

namespace OAuthv2.Data
{
    public static class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            // Ensure database is created
            context.Database.EnsureCreated();

            //Seed Role
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(
                    new Role
                    {
                        IdRole = -1, Name = "Role Ban", Description = "Phân quyền này bị cấm đăng nhập"
                    },
                    new Role
                    {
                        IdRole = 0, Name = "Administrator", Description = "Phân quyền cao nhất trong hệ thống NDCC"
                    },
                    new Role 
                    {
                        IdRole = 1, Name = "Administrator", Description = "Phân quyền quản trị hệ thống Tool Education"
                    },
                    new Role
                    {
                        IdRole = 2, Name = "Admin", Description = "Phân quyền Admin bậc 2 quản lý hệ thống NDCC tầm thấp"
                    },
                    new Role
                    {
                        IdRole = 3, Name = "Admin", Description = "Phân quyền Admin bậc 2 quản lý hệ thống NDCC tầm thấp"
                    },
                    new Role
                    {
                        IdRole = 4, Name = "User", Description = "Phân quyền vị trí người dùng thông thường"
                    },
                    new Role
                    {
                        IdRole = 5, Name = "User", Description = "Phân quyền vị trí người dùng thông thường"
                    }
                );
            }    

            //Seed User infor
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User
                    {
                        FullName = "Administrator",
                        Email = "administrator@thanglele08.id.vn",
                        PasswordHash = new UserRepository(context).HashPassword("LeTh@ng2884", out var salt),
                        IsActive = true,
                        CreateAt = DateTime.Now
                    },
                    new User
                    {
                        FullName = "2251172276",
                        Email = "",
                        PasswordHash = "",
                        IsActive = false,
                        CreateAt = DateTime.Now
                    },
                    new User
                    {
                        FullName = "Nguyễn Lê Đức",
                        Email = "nguyenleduchalongquangninh@gmail.com",
                        PasswordHash = new UserRepository(context).HashPassword("NguyenLeDuc1605", out var salt2),
                        IsActive = false,
                        CreateAt = DateTime.Now
                    },
                    new User
                    {
                        FullName = "2251172339",
                        Email = "2251172339@thanglele08.id.vn",
                        PasswordHash = "",
                        IsActive = false,
                        CreateAt = DateTime.Now
                    },
                    new User
                    {
                        FullName = "2251172345",
                        Email = "2251172345@thanglele08.id.vn",
                        PasswordHash = "",
                        IsActive = false,
                        CreateAt = DateTime.Now
                    },
                    new User
                    {
                        FullName = "Lê Đình Hải",
                        Email = "darwinnmeo@gmail.com",
                        PasswordHash = "",
                        IsActive = false,
                        CreateAt = DateTime.Now
                    },
                    new User
                    {
                        FullName = "Bùi Khắc Huy",
                        Email = "buikhachuy003@gmail.com",
                        PasswordHash = new UserRepository(context).HashPassword("27102004Huy@", out var salt6),
                        IsActive = false,
                        CreateAt = DateTime.Now
                    },
                    new User
                    {
                        FullName = "Canh2905@",
                        Email = "Canh2905@thanglele08.IdRole.vn",
                        PasswordHash = new UserRepository(context).HashPassword("Canh2905@", out var salt7),
                        IsActive = false,
                        CreateAt = DateTime.Now
                    },
                    new User
                    {
                        FullName = "Đào Thị Hảo",
                        Email = "daohaotb126@gmail.com",
                        PasswordHash = new UserRepository(context).HashPassword("Hao120604@!", out var salt8),
                        IsActive = false,
                        CreateAt = DateTime.Now
                    }, new User
                    {
                        FullName = "foodboy99",
                        Email = "foodboy99@thanglele08.id.vn",
                        PasswordHash = "",
                        IsActive = false,
                        CreateAt = DateTime.Now
                    }, new User
                    {
                        FullName = "Nguyễn Quang Huy",
                        Email = "huyga123ylf@gmail.com",
                        PasswordHash = new UserRepository(context).HashPassword("Huynguyen2005", out var salt10),
                        IsActive = false,
                        CreateAt = DateTime.Now
                    }, new User
                    {
                        FullName = "Ngô Minh Trung",
                        Email = "ngominhtrung08052004@gmail.com",
                        PasswordHash = new UserRepository(context).HashPassword("Toilatoi1@", out var salt11),
                        IsActive = false,
                        CreateAt = DateTime.Now
                    }, new User
                    {
                        FullName = "Nam300604",
                        Email = "Nam300604@thanglele08.id.vn",
                        PasswordHash = new UserRepository(context).HashPassword("nam0107nam", out var salt12),
                        IsActive = false,
                        CreateAt = DateTime.Now
                    }, new User
                    {
                        FullName = "Nguyen Huy Hoang",
                        Email = "huyhoangdznhatquadat@gmail.com",
                        PasswordHash = new UserRepository(context).HashPassword("nhh110906", out var salt13),
                        IsActive = false,
                        CreateAt = DateTime.Now
                    }, new User
                    {
                        FullName = "phwnghin",
                        Email = "phwnghin@thanglele08.id.vn",
                        PasswordHash = "",
                        IsActive = false,
                        CreateAt = DateTime.Now
                    }, new User
                    {
                        FullName = "tduc2172006",
                        Email = "tduc2172006@thanglele08.id.vn",
                        PasswordHash = "",
                        IsActive = false,
                        CreateAt = DateTime.Now
                    }, new User
                    {
                        FullName = "Lê Thắng",
                        Email = "lesythang2@gmail.com",
                        PasswordHash = new UserRepository(context).HashPassword("LeTh@ng2884", out var salt16),
                        IsActive = false,
                        CreateAt = DateTime.Now
                    }, new User
                    {
                        FullName = "thanhthanh04",
                        Email = "thanhthanh04@thanglele08.id.vn",
                        PasswordHash = "",
                        IsActive = false,
                        CreateAt = DateTime.Now
                    }, new User
                    {
                        FullName = "Nguyễn Thị Thanh Thảo",
                        Email = "thanhthao020303@gmail.com",
                        PasswordHash = new UserRepository(context).HashPassword("thanhthao020303", out var salt18),
                        IsActive = false,
                        CreateAt = DateTime.Now
                    }, new User
                    {
                        FullName = "Trịnh Văn Tuấn",
                        Email = "trinhtuan12333@gmail.com",
                        PasswordHash = new UserRepository(context).HashPassword("trinhtuan12@", out var salt19),                     
                        IsActive = false,
                        CreateAt = DateTime.Now
                    }, new User
                    {
                        FullName = "tungdeptrai",
                        Email = "tungdeptrai@thanglele08.id.vn",
                        PasswordHash = "",
                        IsActive = false,
                        CreateAt = DateTime.Now
                    },
                    new User
                    {
                        FullName = "vuxuanhuy",
                        Email = "vuxuanhuy@thanglele08.id.vn",
                        PasswordHash = "",
                        IsActive = false,
                        CreateAt = DateTime.Now
                    },
                    new User
                    {
                        FullName = "Ngô Ánh",
                        Email = "ntnanh12704@gmail.com",
                        PasswordHash = new UserRepository(context).HashPassword("vante1995", out var salt20),
                        IsActive = false,
                        CreateAt = DateTime.Now
                    }
                );
            }

            //Seed Roles
            if(!context.UserRoles.Any())
            {
                context.UserRoles.AddRange(new UserRole
                {
                    IdUser = 1,
                    IdRole = 0
                });

                for (int i = 2; i < 24; i++)
                {
                    context.UserRoles.AddRange(new UserRole
                    {
                        IdUser = i,
                        IdRole = 5
                    });
                }
            }    

            context.SaveChanges();
        }

        public static void Remove(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();
            context.SaveChanges();
        }
    }
}
