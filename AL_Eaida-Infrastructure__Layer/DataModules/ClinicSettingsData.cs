using Al_Eaida_Domin.Modules;
using Microsoft.EntityFrameworkCore;

namespace AL_Eaida_Infrastructure__Layer.DataModules
{
    public static class ClinicSettingsData
    {
        public static void SeedClinicSettings(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClinicSettings>().HasData(
                new ClinicSettings
                {
                    Id = Guid.NewGuid(),
                    ClinicName = "عيادة العائدة الطبية",
                    Address = "شارع التحرير، القاهرة، مصر",
                    Phone = "+20 2 1234 5678",
                    Email = "info@al-eaida-clinic.com",
                    Website = "www.al-eaida-clinic.com",
                    LicenseNumber = "MED-2024-001",
                    WorkingHoursStart = TimeSpan.FromHours(9),
                    WorkingHoursEnd = TimeSpan.FromHours(17),
                    DefaultAppointmentDuration = 30,
                    MaxAppointmentsPerDay = 50,
                    AllowOnlineBooking = true,
                    RequireAppointmentConfirmation = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
        }
    }
}

