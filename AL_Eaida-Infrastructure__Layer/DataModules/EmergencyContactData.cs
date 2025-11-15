using Al_Eaida_Domin.Modules;
using Microsoft.EntityFrameworkCore;

namespace AL_Eaida_Infrastructure__Layer.DataModules
{
    public static class EmergencyContactData
    {
        public static void SeedEmergencyContacts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmergencyContact>().HasData(
                new EmergencyContact
                {
                    Id = Guid.NewGuid(),
                    Name = "فاطمة محمد",
                    Relationship = "زوجة",
                    Phone = "+20 100 222 2222",
                    Email = "fatma.mohamed@email.com",
                    CreatedAt = DateTime.UtcNow
                },
                new EmergencyContact
                {
                    Id = Guid.NewGuid(),
                    Name = "خالد علي",
                    Relationship = "أخ",
                    Phone = "+20 100 444 4444",
                    Email = "khaled.ali@email.com",
                    CreatedAt = DateTime.UtcNow
                },
                new EmergencyContact
                {
                    Id = Guid.NewGuid(),
                    Name = "نورا حسن",
                    Relationship = "زوجة",
                    Phone = "+20 100 666 6666",
                    Email = "nour.hassan@email.com",
                    CreatedAt = DateTime.UtcNow
                },
                new EmergencyContact
                {
                    Id = Guid.NewGuid(),
                    Name = "محمد أحمد",
                    Relationship = "أب",
                    Phone = "+20 100 888 8888",
                    Email = "mohamed.ahmed@email.com",
                    CreatedAt = DateTime.UtcNow
                },
                new EmergencyContact
                {
                    Id = Guid.NewGuid(),
                    Name = "أميرة محمد",
                    Relationship = "زوجة",
                    Phone = "+20 100 000 0000",
                    Email = "amira.mohamed@email.com",
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}

