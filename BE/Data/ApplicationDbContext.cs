using Microsoft.EntityFrameworkCore;
using OAuthv2.Models;
using TLUScience.Models;

namespace OAuthv2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserOTP> UserOTPs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình model nếu cần
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);
                entity.Property(e => e.Email).IsRequired();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole);
                entity.Property(e => e.IdRole).ValueGeneratedNever();
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                // Composite key
                entity.HasKey(e => new { e.IdUser, e.IdRole });

                entity.HasOne(e => e.User).WithMany(u => u.UserRoles).HasForeignKey(e => e.IdUser).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Role).WithMany(u => u.userRoles).HasForeignKey(e => e.IdRole).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<UserOTP>(entity => 
            {
                // Composite key
                entity.HasKey(e => new { e.IdUser });

                entity.HasOne(e => e.User).WithOne(u => u.userOTPs).HasForeignKey<UserOTP>(e => e.IdUser).OnDelete(DeleteBehavior.Cascade);
            });

            //modelBuilder.Entity<Token>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //    entity.HasOne(e => e.User).WithMany(u => u.Tokens).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Cascade);
            //});
        }
    }
}
