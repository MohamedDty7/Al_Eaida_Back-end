using Al_Eaida_Domin.Modules;
using Microsoft.EntityFrameworkCore;

namespace AL_Eaida_Infrastructure__Layer.DataModules
{
    public static class DoctorData
    {
        public static void SeedDoctors(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = Guid.NewGuid(),
                    UserId = "14b85371-c6a3-43cc-97ec-585c6e09e623", // Admin User
                    FirstName = "أحمد",
                    LastName = "محمد",
                    Email = "ahmed.mohamed@al-eaida.com",
                    Phone = "+20 100 111 1111",
                    Specialization = "Cardiology",
                    LicenseNumber = "MED-2024-001",
                    MedicalSchool = "جامعة القاهرة",
                    YearsOfExperience = 15,
                    Bio = "طبيب قلب متخصص في جراحة القلب المفتوح والقسطرة القلبية",
                    StartTime = TimeSpan.FromHours(9),
                    EndTime = TimeSpan.FromHours(17),
                    MaxPatientsPerDay = 20,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
               
                new Doctor
                {
                    Id = Guid.NewGuid(),
                    UserId = "f757d17b-6565-47a5-8236-fa1435202704", // Doctor 2 User
                    FirstName = "مريم",
                    LastName = "حسن",
                    Email = "mariam.hassan@al-eaida.com",
                    Phone = "+20 100 333 3333",
                    Specialization = "Obstetrics and Gynecology",
                    LicenseNumber = "MED-2024-003",
                    MedicalSchool = "جامعة الإسكندرية",
                    YearsOfExperience = 18,
                    Bio = "طبيبة نساء وولادة متخصصة في الولادة الطبيعية والقيصرية",
                    StartTime = TimeSpan.FromHours(9),
                    EndTime = TimeSpan.FromHours(17),
                    MaxPatientsPerDay = 15,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Doctor
                {
                    Id = Guid.NewGuid(),
                    UserId = "fef8f13b-e461-411f-b288-e1a3b536f5e5", // Doctor 3 User
                    FirstName = "خالد",
                    LastName = "أحمد",
                    Email = "khaled.ahmed@al-eaida.com",
                    Phone = "+20 100 444 4444",
                    Specialization = "Orthopedics",
                    LicenseNumber = "MED-2024-004",
                    MedicalSchool = "جامعة القاهرة",
                    YearsOfExperience = 20,
                    Bio = "طبيب عظام متخصص في جراحة المفاصل والكسور المعقدة",
                    StartTime = TimeSpan.FromHours(8),
                    EndTime = TimeSpan.FromHours(18),
                    MaxPatientsPerDay = 18,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Doctor
                {
                    Id = Guid.NewGuid(),
                    UserId = "875631f9-20c3-4306-ab43-a12de3e258e2", // Doctor 4 User
                    FirstName = "نورا",
                    LastName = "محمد",
                    Email = "nour.mohamed@al-eaida.com",
                    Phone = "+20 100 555 5555",
                    Specialization = "Ophthalmology",
                    LicenseNumber = "MED-2024-005",
                    MedicalSchool = "جامعة الأزهر",
                    YearsOfExperience = 10,
                    Bio = "طبيبة عيون متخصصة في جراحة الشبكية والليزر",
                    StartTime = TimeSpan.FromHours(9),
                    EndTime = TimeSpan.FromHours(16),
                    MaxPatientsPerDay = 22,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
        }
    }
}