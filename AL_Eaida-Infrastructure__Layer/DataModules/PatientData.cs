using Al_Eaida_Domin.Modules;
using Microsoft.EntityFrameworkCore;

namespace AL_Eaida_Infrastructure__Layer.DataModules
{
    public static class PatientData
    {
        public static void SeedPatients(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    Id = Guid.NewGuid(),
                    FirstName = "أحمد",
                    LastName = "محمد",
                    FullName = "أحمد محمد",
                    Email = "ahmed.mohamed@email.com",
                    Phone = "+20 100 111 1111",
                    DateOfBirth = new DateTime(1985, 5, 15),
                    Gender = Gender.Male,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Patient
                {
                    Id = Guid.NewGuid(),
                    FirstName = "مريم",
                    LastName = "علي",
                    FullName = "مريم علي",
                    Email = "mariam.ali@email.com",
                    Phone = "+20 100 333 3333",
                    DateOfBirth = new DateTime(1990, 8, 22),
                    Gender = Gender.Female,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Patient
                {
                    Id = Guid.NewGuid(),
                    FirstName = "يوسف",
                    LastName = "حسن",
                    FullName = "يوسف حسن",
                    Email = "youssef.hassan@email.com",
                    Phone = "+20 100 555 5555",
                    DateOfBirth = new DateTime(1978, 12, 3),
                    Gender = Gender.Male,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Patient
                {
                    Id = Guid.NewGuid(),
                    FirstName = "سارة",
                    LastName = "أحمد",
                    FullName = "سارة أحمد",
                    Email = "sara.ahmed@email.com",
                    Phone = "+20 100 777 7777",
                    DateOfBirth = new DateTime(1995, 3, 18),
                    Gender = Gender.Female,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Patient
                {
                    Id = Guid.NewGuid(),
                    FirstName = "عبدالله",
                    LastName = "محمد",
                    FullName = "عبدالله محمد",
                    Email = "abdullah.mohamed@email.com",
                    Phone = "+20 100 999 9999",
                    DateOfBirth = new DateTime(1982, 7, 25),
                    Gender = Gender.Male,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
        }
    }
}