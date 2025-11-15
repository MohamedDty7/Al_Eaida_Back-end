using Al_Eaida_Domin.Modules;
using Microsoft.EntityFrameworkCore;

namespace AL_Eaida_Infrastructure__Layer.DataModules
{
    public static class PrescriptionItemData
    {
        public static void SeedPrescriptionItems(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrescriptionItem>().HasData(
                new PrescriptionItem
                {
                    Id = Guid.NewGuid(),
                    PrescriptionId = Guid.NewGuid(), // معرف الوصفة الطبية
                    MedicineId = Guid.NewGuid(), // معرف الدواء
                    Dosage = "500mg",
                    Frequency = "مرتين يومياً",
                    Duration = 7,
                    Quantity = 14,
                    Instructions = "يؤخذ مع الطعام",
                    Notes = "لا توجد ملاحظات خاصة",
                    StartDate = DateTime.UtcNow.AddDays(-5),
                    EndDate = DateTime.UtcNow.AddDays(2),
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                },
                new PrescriptionItem
                {
                    Id = Guid.NewGuid(),
                    PrescriptionId = Guid.NewGuid(), // معرف الوصفة الطبية
                    MedicineId = Guid.NewGuid(), // معرف الدواء
                    Dosage = "200mg",
                    Frequency = "مرة يومياً",
                    Duration = 30,
                    Quantity = 30,
                    Instructions = "يؤخذ في الصباح",
                    Notes = "يؤخذ على معدة فارغة",
                    StartDate = DateTime.UtcNow.AddDays(-3),
                    EndDate = DateTime.UtcNow.AddDays(27),
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                },
                new PrescriptionItem
                {
                    Id = Guid.NewGuid(),
                    PrescriptionId = Guid.NewGuid(), // معرف الوصفة الطبية
                    MedicineId = Guid.NewGuid(), // معرف الدواء
                    Dosage = "100mg",
                    Frequency = "ثلاث مرات يومياً",
                    Duration = 10,
                    Quantity = 30,
                    Instructions = "يؤخذ قبل الوجبات",
                    Notes = "تجنب الأطعمة الدهنية",
                    StartDate = DateTime.UtcNow.AddDays(-1),
                    EndDate = DateTime.UtcNow.AddDays(9),
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                },
                new PrescriptionItem
                {
                    Id = Guid.NewGuid(),
                    PrescriptionId = Guid.NewGuid(), // معرف الوصفة الطبية
                    MedicineId = Guid.NewGuid(), // معرف الدواء
                    Dosage = "50mg",
                    Frequency = "مرة يومياً",
                    Duration = 90,
                    Quantity = 90,
                    Instructions = "يؤخذ في المساء",
                    Notes = "مراقبة الآثار الجانبية",
                    StartDate = DateTime.UtcNow.AddDays(-7),
                    EndDate = DateTime.UtcNow.AddDays(83),
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                },
                new PrescriptionItem
                {
                    Id = Guid.NewGuid(),
                    PrescriptionId = Guid.NewGuid(), // معرف الوصفة الطبية
                    MedicineId = Guid.NewGuid(), // معرف الدواء
                    Dosage = "25mg",
                    Frequency = "مرتين يومياً",
                    Duration = 14,
                    Quantity = 28,
                    Instructions = "يؤخذ مع كوب من الماء",
                    Notes = "تجنب الكحول",
                    StartDate = DateTime.UtcNow.AddDays(-10),
                    EndDate = DateTime.UtcNow.AddDays(4),
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                }
            );
        }
    }
}
