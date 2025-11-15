using Al_Eaida_Domin.Modules;
using Microsoft.EntityFrameworkCore;

namespace AL_Eaida_Infrastructure__Layer.DataModules
{
    public static class MedicineData
    {
        public static void SeedMedicines(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicine>().HasData(
                new Medicine
                {
                    Id = Guid.NewGuid(),
                    Name = "باراسيتامول",
                    GenericName = "Paracetamol",
                    DosageForm = "Tablet",
                    Strength = "500mg",
                    Manufacturer = "شركة الأدوية المصرية",
                    Description = "مسكن للآلام وخافض للحرارة",
                    SideEffects = "نادراً ما يسبب حساسية",
                    Contraindications = "لا يستخدم مع مرضى الكبد",
                    Instructions = "يؤخذ مع الطعام",
                    Price = 5.50m,
                    StockQuantity = 1000,
                    MinStockLevel = 100,
                    ExpiryDate = DateTime.UtcNow.AddYears(2),
                    RequiresPrescription = false,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Medicine
                {
                    Id = Guid.NewGuid(),
                    Name = "أموكسيسيلين",
                    GenericName = "Amoxicillin",
                    DosageForm = "Capsule",
                    Strength = "250mg",
                    Manufacturer = "شركة الأدوية العالمية",
                    Description = "مضاد حيوي واسع الطيف",
                    SideEffects = "قد يسبب اضطراب في المعدة",
                    Contraindications = "حساسية من البنسلين",
                    Instructions = "يؤخذ قبل الطعام",
                    Price = 15.75m,
                    StockQuantity = 500,
                    MinStockLevel = 50,
                    ExpiryDate = DateTime.UtcNow.AddYears(3),
                    RequiresPrescription = true,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Medicine
                {
                    Id = Guid.NewGuid(),
                    Name = "إيبوبروفين",
                    GenericName = "Ibuprofen",
                    DosageForm = "Tablet",
                    Strength = "400mg",
                    Manufacturer = "شركة الأدوية المتقدمة",
                    Description = "مضاد للالتهاب ومسكن للآلام",
                    SideEffects = "قد يسبب اضطراب في المعدة",
                    Contraindications = "قرحة المعدة",
                    Instructions = "يؤخذ مع الطعام",
                    Price = 8.25m,
                    StockQuantity = 750,
                    MinStockLevel = 75,
                    ExpiryDate = DateTime.UtcNow.AddYears(2),
                    RequiresPrescription = false,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Medicine
                {
                    Id = Guid.NewGuid(),
                    Name = "أوميبرازول",
                    GenericName = "Omeprazole",
                    DosageForm = "Capsule",
                    Strength = "20mg",
                    Manufacturer = "شركة الأدوية الحديثة",
                    Description = "مثبط لمضخة البروتون لعلاج قرحة المعدة",
                    SideEffects = "نادراً ما يسبب صداع",
                    Contraindications = "لا توجد موانع معروفة",
                    Instructions = "يؤخذ على معدة فارغة",
                    Price = 12.00m,
                    StockQuantity = 300,
                    MinStockLevel = 30,
                    ExpiryDate = DateTime.UtcNow.AddYears(3),
                    RequiresPrescription = true,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Medicine
                {
                    Id = Guid.NewGuid(),
                    Name = "ميتفورمين",
                    GenericName = "Metformin",
                    DosageForm = "Tablet",
                    Strength = "500mg",
                    Manufacturer = "شركة الأدوية المتخصصة",
                    Description = "دواء لعلاج مرض السكري من النوع الثاني",
                    SideEffects = "قد يسبب اضطراب في المعدة",
                    Contraindications = "أمراض الكلى",
                    Instructions = "يؤخذ مع الطعام",
                    Price = 18.50m,
                    StockQuantity = 400,
                    MinStockLevel = 40,
                    ExpiryDate = DateTime.UtcNow.AddYears(2),
                    RequiresPrescription = true,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
        }
    }
}