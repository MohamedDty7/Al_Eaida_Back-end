using Al_Eaida_Domin.Modules;
using Microsoft.EntityFrameworkCore;

namespace AL_Eaida_Infrastructure__Layer.DataModules
{
    public static class MedicalRecordData
    {
        public static void SeedMedicalRecords(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalRecord>().HasData(
                new MedicalRecord
                {
                    Id = Guid.NewGuid(),
                    PatientId = Guid.NewGuid(), // معرف المريض
                    DoctorId = Guid.NewGuid(), // معرف الطبيب
                    Date = DateTime.UtcNow.AddDays(-5),
                    Diagnosis = "التهاب الزائدة الدودية",
                    Treatment = "جراحة إزالة الزائدة",
                    Notes = "مريض يحتاج جراحة عاجلة",
                    CreatedAt = DateTime.UtcNow
                },
                new MedicalRecord
                {
                    Id = Guid.NewGuid(),
                    PatientId = Guid.NewGuid(), // معرف المريض
                    DoctorId = Guid.NewGuid(), // معرف الطبيب
                    Date = DateTime.UtcNow.AddDays(-3),
                    Diagnosis = "صحة جيدة",
                    Treatment = "لا حاجة للعلاج",
                    Notes = "مريض بصحة جيدة",
                    CreatedAt = DateTime.UtcNow
                },
                new MedicalRecord
                {
                    Id = Guid.NewGuid(),
                    PatientId = Guid.NewGuid(), // معرف المريض
                    DoctorId = Guid.NewGuid(), // معرف الطبيب
                    Date = DateTime.UtcNow.AddDays(-1),
                    Diagnosis = "ذبحة صدرية",
                    Treatment = "أدوية القلب والراحة",
                    Notes = "مريض يحتاج مراقبة دقيقة",
                    CreatedAt = DateTime.UtcNow
                },
                new MedicalRecord
                {
                    Id = Guid.NewGuid(),
                    PatientId = Guid.NewGuid(), // معرف المريض
                    DoctorId = Guid.NewGuid(), // معرف الطبيب
                    Date = DateTime.UtcNow.AddDays(-7),
                    Diagnosis = "استجابة جيدة للعلاج",
                    Treatment = "متابعة الدواء الحالي",
                    Notes = "العلاج يعمل بشكل جيد",
                    CreatedAt = DateTime.UtcNow
                },
                new MedicalRecord
                {
                    Id = Guid.NewGuid(),
                    PatientId = Guid.NewGuid(), // معرف المريض
                    DoctorId = Guid.NewGuid(), // معرف الطبيب
                    Date = DateTime.UtcNow.AddDays(-10),
                    Diagnosis = "قصر نظر",
                    Treatment = "نظارات طبية",
                    Notes = "مريض يحتاج نظارات طبية",
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}

