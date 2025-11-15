using Al_Eaida_Domin.Modules;
using Microsoft.EntityFrameworkCore;

namespace AL_Eaida_Infrastructure__Layer.DataModules
{
    public static class MedicalVisitData
    {
        public static void SeedMedicalVisits(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalVisit>().HasData(
                new MedicalVisit
                {
                    Id = Guid.NewGuid(),
                    PatientId = Guid.NewGuid(), // معرف المريض
                    DoctorID = Guid.NewGuid(), // معرف الطبيب
                    VisitDate = DateTime.UtcNow.AddDays(-5),
                    Diagnosis = "التهاب الزائدة الدودية",
                    Notes = "مريض يحتاج جراحة عاجلة",
                    UserID = Guid.NewGuid().ToString(), // معرف المستخدم
                },
                new MedicalVisit
                {
                    Id = Guid.NewGuid(),
                    PatientId = Guid.NewGuid(), // معرف المريض
                    DoctorID = Guid.NewGuid(), // معرف الطبيب
                    VisitDate = DateTime.UtcNow.AddDays(-3),
                    Diagnosis = "صحة جيدة",
                    Notes = "مريض بصحة جيدة",
                    UserID = Guid.NewGuid().ToString(), // معرف المستخدم
                },
                new MedicalVisit
                {
                    Id = Guid.NewGuid(),
                    PatientId = Guid.NewGuid(), // معرف المريض
                    DoctorID = Guid.NewGuid(), // معرف الطبيب
                    VisitDate = DateTime.UtcNow.AddDays(-1),
                    Diagnosis = "ذبحة صدرية",
                    Notes = "مريض يحتاج مراقبة دقيقة",
                    UserID = Guid.NewGuid().ToString(), // معرف المستخدم
                },
                new MedicalVisit
                {
                    Id = Guid.NewGuid(),
                    PatientId = Guid.NewGuid(), // معرف المريض
                    DoctorID = Guid.NewGuid(), // معرف الطبيب
                    VisitDate = DateTime.UtcNow.AddDays(-7),
                    Diagnosis = "استجابة جيدة للعلاج",
                    Notes = "العلاج يعمل بشكل جيد",
                    UserID = Guid.NewGuid().ToString(), // معرف المستخدم
                },
                new MedicalVisit
                {
                    Id = Guid.NewGuid(),
                    PatientId = Guid.NewGuid(), // معرف المريض
                    DoctorID = Guid.NewGuid(), // معرف الطبيب
                    VisitDate = DateTime.UtcNow.AddDays(-10),
                    Diagnosis = "قصر نظر",
                    Notes = "مريض يحتاج نظارات طبية",
                    UserID = Guid.NewGuid().ToString(), // معرف المستخدم
                }
            );
        }
    }
}
