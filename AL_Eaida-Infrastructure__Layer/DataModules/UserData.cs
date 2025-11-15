using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Al_Eaida_Domin.Modules;

namespace AL_Eaida_Infrastructure__Layer.DataModules
{
    public static class UserData
    {
        public static void SeedUsers(ModelBuilder modelBuilder)
        {
            // إنشاء المستخدمين الأساسيين
            var adminUser = new User
            {
                Id = "14b85371-c6a3-43cc-97ec-585c6e09e623",
                UserName = "admin@al-eaida.com",
                NormalizedUserName = "ADMIN@AL-EAIDA.COM",
                Email = "admin@al-eaida.com",
                NormalizedEmail = "ADMIN@AL-EAIDA.COM",
                EmailConfirmed = true,
                PhoneNumber = "+20 100 000 0000",
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            var doctor1User = new User
            {
                Id = "eeca4a29-b77e-4001-8880-bc962863fbc4",
                UserName = "fatma.ali@al-eaida.com",
                NormalizedUserName = "FATMA.ALI@AL-EAIDA.COM",
                Email = "fatma.ali@al-eaida.com",
                NormalizedEmail = "FATMA.ALI@AL-EAIDA.COM",
                EmailConfirmed = true,
                PhoneNumber = "+20 100 222 2222",
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            var doctor2User = new User
            {
                Id = "f757d17b-6565-47a5-8236-fa1435202704",
                UserName = "mariam.hassan@al-eaida.com",
                NormalizedUserName = "MARIAM.HASSAN@AL-EAIDA.COM",
                Email = "mariam.hassan@al-eaida.com",
                NormalizedEmail = "MARIAM.HASSAN@AL-EAIDA.COM",
                EmailConfirmed = true,
                PhoneNumber = "+20 100 333 3333",
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            var doctor3User = new User
            {
                Id = "fef8f13b-e461-411f-b288-e1a3b536f5e5",
                UserName = "khaled.ahmed@al-eaida.com",
                NormalizedUserName = "KHALED.AHMED@AL-EAIDA.COM",
                Email = "khaled.ahmed@al-eaida.com",
                NormalizedEmail = "KHALED.AHMED@AL-EAIDA.COM",
                EmailConfirmed = true,
                PhoneNumber = "+20 100 444 4444",
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            var doctor4User = new User
            {
                Id = "875631f9-20c3-4306-ab43-a12de3e258e2",
                UserName = "nour.mohamed@al-eaida.com",
                NormalizedUserName = "NOUR.MOHAMED@AL-EAIDA.COM",
                Email = "nour.mohamed@al-eaida.com",
                NormalizedEmail = "NOUR.MOHAMED@AL-EAIDA.COM",
                EmailConfirmed = true,
                PhoneNumber = "+20 100 555 5555",
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            var receptionistUser = new User
            {
                Id = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                UserName = "receptionist@al-eaida.com",
                NormalizedUserName = "RECEPTIONIST@AL-EAIDA.COM",
                Email = "receptionist@al-eaida.com",
                NormalizedEmail = "RECEPTIONIST@AL-EAIDA.COM",
                EmailConfirmed = true,
                PhoneNumber = "+20 100 666 6666",
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            var accountantUser = new User
            {
                Id = "b2c3d4e5-f6g7-8901-bcde-f23456789012",
                UserName = "accountant@al-eaida.com",
                NormalizedUserName = "ACCOUNTANT@AL-EAIDA.COM",
                Email = "accountant@al-eaida.com",
                NormalizedEmail = "ACCOUNTANT@AL-EAIDA.COM",
                EmailConfirmed = true,
                PhoneNumber = "+20 100 777 7777",
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            // إضافة كلمات المرور للمستخدمين (مشفرة)
            var passwordHasher = new PasswordHasher<User>();
            
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Admin123!");
            doctor1User.PasswordHash = passwordHasher.HashPassword(doctor1User, "Doctor123!");
            doctor2User.PasswordHash = passwordHasher.HashPassword(doctor2User, "Doctor123!");
            doctor3User.PasswordHash = passwordHasher.HashPassword(doctor3User, "Doctor123!");
            doctor4User.PasswordHash = passwordHasher.HashPassword(doctor4User, "Doctor123!");
            receptionistUser.PasswordHash = passwordHasher.HashPassword(receptionistUser, "Receptionist123!");
            accountantUser.PasswordHash = passwordHasher.HashPassword(accountantUser, "Accountant123!");

            // إضافة المستخدمين إلى قاعدة البيانات
            modelBuilder.Entity<User>().HasData(
                adminUser,
                doctor1User,
                doctor2User,
                doctor3User,
                doctor4User,
                receptionistUser,
                accountantUser
            );

            // ربط المستخدمين بالأدوار
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = adminUser.Id, RoleId = "f2d14089-a797-4493-be63-4a9c80570235" }, // Admin
                new IdentityUserRole<string> { UserId = doctor1User.Id, RoleId = "4ecb10a6-d9c8-41ec-8577-8256e3d38608" }, // Doctor
                new IdentityUserRole<string> { UserId = doctor2User.Id, RoleId = "4ecb10a6-d9c8-41ec-8577-8256e3d38608" }, // Doctor
                new IdentityUserRole<string> { UserId = doctor3User.Id, RoleId = "4ecb10a6-d9c8-41ec-8577-8256e3d38608" }, // Doctor
                new IdentityUserRole<string> { UserId = doctor4User.Id, RoleId = "4ecb10a6-d9c8-41ec-8577-8256e3d38608" }, // Doctor
                new IdentityUserRole<string> { UserId = receptionistUser.Id, RoleId = "7626c860-20d2-4402-bb4b-c8a0d067201e" }, // Receptionist
                new IdentityUserRole<string> { UserId = accountantUser.Id, RoleId = "f5cea4e7-e825-4663-9586-bfb7a68a58d0" }  // Accountant
            );
        }
    }
}
