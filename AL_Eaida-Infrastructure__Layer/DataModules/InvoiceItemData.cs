using Al_Eaida_Domin.Modules;
using Microsoft.EntityFrameworkCore;

namespace AL_Eaida_Infrastructure__Layer.DataModules
{
    public static class InvoiceItemData
    {
        public static void SeedInvoiceItems(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceItem>().HasData(
                new InvoiceItem
                {
                    Id = Guid.NewGuid(),
                    InvoiceId = Guid.NewGuid(), // معرف الفاتورة
                    Description = "استشارة طبية",
                    Quantity = 1,
                    UnitPrice = 200.00m,
                    Amount = 200.00m,
                    ItemType = "Service",
                    ItemId = Guid.NewGuid().ToString(),
                    Notes = "استشارة طبية عامة",
                    CreatedAt = DateTime.UtcNow
                },
                new InvoiceItem
                {
                    Id = Guid.NewGuid(),
                    InvoiceId = Guid.NewGuid(), // معرف الفاتورة
                    Description = "فحص شامل",
                    Quantity = 1,
                    UnitPrice = 500.00m,
                    Amount = 500.00m,
                    ItemType = "Service",
                    ItemId = Guid.NewGuid().ToString(),
                    Notes = "فحص شامل للجسم",
                    CreatedAt = DateTime.UtcNow
                },
                new InvoiceItem
                {
                    Id = Guid.NewGuid(),
                    InvoiceId = Guid.NewGuid(), // معرف الفاتورة
                    Description = "باراسيتامول",
                    Quantity = 2,
                    UnitPrice = 15.00m,
                    Amount = 30.00m,
                    ItemType = "Medication",
                    ItemId = Guid.NewGuid().ToString(),
                    Notes = "مسكن للآلام",
                    CreatedAt = DateTime.UtcNow
                },
                new InvoiceItem
                {
                    Id = Guid.NewGuid(),
                    InvoiceId = Guid.NewGuid(), // معرف الفاتورة
                    Description = "أموكسيسيلين",
                    Quantity = 1,
                    UnitPrice = 25.00m,
                    Amount = 25.00m,
                    ItemType = "Medication",
                    ItemId = Guid.NewGuid().ToString(),
                    Notes = "مضاد حيوي",
                    CreatedAt = DateTime.UtcNow
                },
                new InvoiceItem
                {
                    Id = Guid.NewGuid(),
                    InvoiceId = Guid.NewGuid(), // معرف الفاتورة
                    Description = "جراحة بسيطة",
                    Quantity = 1,
                    UnitPrice = 1000.00m,
                    Amount = 1000.00m,
                    ItemType = "Service",
                    ItemId = Guid.NewGuid().ToString(),
                    Notes = "جراحة بسيطة",
                    CreatedAt = DateTime.UtcNow
                },
                new InvoiceItem
                {
                    Id = Guid.NewGuid(),
                    InvoiceId = Guid.NewGuid(), // معرف الفاتورة
                    Description = "إيبوبروفين",
                    Quantity = 3,
                    UnitPrice = 20.00m,
                    Amount = 60.00m,
                    ItemType = "Medication",
                    ItemId = Guid.NewGuid().ToString(),
                    Notes = "مضاد للالتهاب",
                    CreatedAt = DateTime.UtcNow
                },
                new InvoiceItem
                {
                    Id = Guid.NewGuid(),
                    InvoiceId = Guid.NewGuid(), // معرف الفاتورة
                    Description = "متابعة طبية",
                    Quantity = 1,
                    UnitPrice = 150.00m,
                    Amount = 150.00m,
                    ItemType = "Service",
                    ItemId = Guid.NewGuid().ToString(),
                    Notes = "متابعة حالة المريض",
                    CreatedAt = DateTime.UtcNow
                },
                new InvoiceItem
                {
                    Id = Guid.NewGuid(),
                    InvoiceId = Guid.NewGuid(), // معرف الفاتورة
                    Description = "أوميبرازول",
                    Quantity = 1,
                    UnitPrice = 30.00m,
                    Amount = 30.00m,
                    ItemType = "Medication",
                    ItemId = Guid.NewGuid().ToString(),
                    Notes = "علاج قرحة المعدة",
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}

