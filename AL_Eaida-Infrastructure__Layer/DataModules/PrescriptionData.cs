using Al_Eaida_Domin.Modules;
using Microsoft.EntityFrameworkCore;

namespace AL_Eaida_Infrastructure__Layer.DataModules
{
    public static class PrescriptionData
    {
        public static void SeedPrescriptions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prescription>().HasData(
                new Prescription
                {
                    Id = Guid.NewGuid(),
                    PatientId = Guid.NewGuid(), // معرف المريض
                    DoctorId = Guid.NewGuid(), // معرف الطبيب
                    MedicationId = Guid.NewGuid(), // معرف الدواء
                    Dosage = "500mg",
                    Frequency = "مرتين يومياً",
                    Duration = 7,
                    Instructions = "يؤخذ مع الطعام",
                    PrescribedDate = DateTime.UtcNow.AddDays(-5),
                    StartDate = DateTime.UtcNow.AddDays(-5),
                    EndDate = DateTime.UtcNow.AddDays(2),
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                },
                new Prescription
                {
                    Id = Guid.NewGuid(),
                    PatientId = Guid.NewGuid(), // معرف المريض
                    DoctorId = Guid.NewGuid(), // معرف الطبيب
                    MedicationId = Guid.NewGuid(), // معرف الدواء
                    Dosage = "200mg",
                    Frequency = "مرة يومياً",
                    Duration = 30,
                    Instructions = "يؤخذ في الصباح",
                    PrescribedDate = DateTime.UtcNow.AddDays(-3),
                    StartDate = DateTime.UtcNow.AddDays(-3),
                    EndDate = DateTime.UtcNow.AddDays(27),
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                },
                new Prescription
                {
                    Id = Guid.NewGuid(),
                    PatientId = Guid.NewGuid(), // معرف المريض
                    DoctorId = Guid.NewGuid(), // معرف الطبيب
                    MedicationId = Guid.NewGuid(), // معرف الدواء
                    Dosage = "100mg",
                    Frequency = "ثلاث مرات يومياً",
                    Duration = 10,
                    Instructions = "يؤخذ قبل الوجبات",
                    PrescribedDate = DateTime.UtcNow.AddDays(-1),
                    StartDate = DateTime.UtcNow.AddDays(-1),
                    EndDate = DateTime.UtcNow.AddDays(9),
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                },
                new Prescription
                {
                    Id = Guid.NewGuid(),
                    PatientId = Guid.NewGuid(), // معرف المريض
                    DoctorId = Guid.NewGuid(), // معرف الطبيب
                    MedicationId = Guid.NewGuid(), // معرف الدواء
                    Dosage = "50mg",
                    Frequency = "مرة يومياً",
                    Duration = 90,
                    Instructions = "يؤخذ في المساء",
                    PrescribedDate = DateTime.UtcNow.AddDays(-7),
                    StartDate = DateTime.UtcNow.AddDays(-7),
                    EndDate = DateTime.UtcNow.AddDays(83),
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                },
                new Prescription
                {
                    Id = Guid.NewGuid(),
                    PatientId = Guid.NewGuid(), // معرف المريض
                    DoctorId = Guid.NewGuid(), // معرف الطبيب
                    MedicationId = Guid.NewGuid(), // معرف الدواء
                    Dosage = "25mg",
                    Frequency = "مرتين يومياً",
                    Duration = 14,
                    Instructions = "يؤخذ مع كوب من الماء",
                    PrescribedDate = DateTime.UtcNow.AddDays(-10),
                    StartDate = DateTime.UtcNow.AddDays(-10),
                    EndDate = DateTime.UtcNow.AddDays(4),
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                }
            );
        }
    }
}
