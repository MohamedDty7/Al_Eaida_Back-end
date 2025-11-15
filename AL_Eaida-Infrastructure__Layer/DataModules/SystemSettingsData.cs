using Al_Eaida_Domin.Modules;
using Microsoft.EntityFrameworkCore;

namespace AL_Eaida_Infrastructure__Layer.DataModules
{
    public static class SystemSettingsData
    {
        public static void SeedSystemSettings(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SystemSettings>().HasData(
                new SystemSettings
                {
                    Id = Guid.NewGuid(),
                    Key = "ClinicName",
                    Value = "عيادة العائدة الطبية",
                    Description = "اسم العيادة",
                    Type = SettingType.String,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new SystemSettings
                {
                    Id = Guid.NewGuid(),
                    Key = "ClinicAddress",
                    Value = "شارع التحرير، القاهرة، مصر",
                    Description = "عنوان العيادة",
                    Type = SettingType.String,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new SystemSettings
                {
                    Id = Guid.NewGuid(),
                    Key = "ClinicPhone",
                    Value = "+20 2 1234 5678",
                    Description = "رقم هاتف العيادة",
                    Type = SettingType.String,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new SystemSettings
                {
                    Id = Guid.NewGuid(),
                    Key = "ClinicEmail",
                    Value = "info@al-eaida-clinic.com",
                    Description = "بريد العيادة الإلكتروني",
                    Type = SettingType.String,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new SystemSettings
                {
                    Id = Guid.NewGuid(),
                    Key = "DefaultAppointmentDuration",
                    Value = "30",
                    Description = "مدة الموعد الافتراضية بالدقائق",
                    Type = SettingType.Integer,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new SystemSettings
                {
                    Id = Guid.NewGuid(),
                    Key = "MaxAppointmentsPerDay",
                    Value = "50",
                    Description = "الحد الأقصى للمواعيد في اليوم",
                    Type = SettingType.Integer,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new SystemSettings
                {
                    Id = Guid.NewGuid(),
                    Key = "DefaultCurrency",
                    Value = "EGP",
                    Description = "العملة الافتراضية",
                    Type = SettingType.String,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new SystemSettings
                {
                    Id = Guid.NewGuid(),
                    Key = "TaxRate",
                    Value = "14",
                    Description = "معدل الضريبة المضافة",
                    Type = SettingType.Decimal,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new SystemSettings
                {
                    Id = Guid.NewGuid(),
                    Key = "DefaultConsultationFee",
                    Value = "200",
                    Description = "رسوم الاستشارة الافتراضية",
                    Type = SettingType.Decimal,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new SystemSettings
                {
                    Id = Guid.NewGuid(),
                    Key = "EnableEmailNotifications",
                    Value = "true",
                    Description = "تفعيل إشعارات البريد الإلكتروني",
                    Type = SettingType.Boolean,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
        }
    }
}

