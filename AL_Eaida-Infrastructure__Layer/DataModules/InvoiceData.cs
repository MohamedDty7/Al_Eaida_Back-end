using Al_Eaida_Domin.Modules;
using Microsoft.EntityFrameworkCore;

namespace AL_Eaida_Infrastructure__Layer.DataModules
{
    public static class InvoiceData
    {
        public static void SeedInvoices(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>().HasData(
                new Invoice
                {
                    Id = Guid.NewGuid(),
                    PatientId = Guid.NewGuid(), // معرف المريض
                    CreatedBy = Guid.NewGuid().ToString(), // معرف المستخدم الذي أنشأ الفاتورة
                    InvoiceNumber = "INV-001-2024",
                    InvoiceDate = DateTime.UtcNow.AddDays(-5),
                    DueDate = DateTime.UtcNow.AddDays(25),
                    TotalAmount = 500.00m,
                    TaxAmount = 70.00m,
                    DiscountAmount = 50.00m,
                    NetAmount = 520.00m,
                    Status = InvoiceStatus.Pending,
                    Notes = "فاتورة استشارة طبية",
                    PaymentNotes = "لم يتم الدفع بعد",
                    IsDeleted = false,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Invoice
                {
                    Id = Guid.NewGuid(),
                    PatientId = Guid.NewGuid(), // معرف المريض
                    CreatedBy = Guid.NewGuid().ToString(), // معرف المستخدم الذي أنشأ الفاتورة
                    InvoiceNumber = "INV-002-2024",
                    InvoiceDate = DateTime.UtcNow.AddDays(-3),
                    DueDate = DateTime.UtcNow.AddDays(27),
                    TotalAmount = 750.00m,
                    TaxAmount = 105.00m,
                    DiscountAmount = 0.00m,
                    NetAmount = 855.00m,
                    Status = InvoiceStatus.Paid,
                    Notes = "فاتورة فحص شامل",
                    PaymentNotes = "تم الدفع نقداً",
                    PaidDate = DateTime.UtcNow.AddDays(-1),
                    PaymentMethod = "نقد",
                    IsDeleted = false,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Invoice
                {
                    Id = Guid.NewGuid(),
                    PatientId = Guid.NewGuid(), // معرف المريض
                    CreatedBy = Guid.NewGuid().ToString(), // معرف المستخدم الذي أنشأ الفاتورة
                    InvoiceNumber = "INV-003-2024",
                    InvoiceDate = DateTime.UtcNow.AddDays(-1),
                    DueDate = DateTime.UtcNow.AddDays(29),
                    TotalAmount = 300.00m,
                    TaxAmount = 42.00m,
                    DiscountAmount = 30.00m,
                    NetAmount = 312.00m,
                    Status = InvoiceStatus.Pending,
                    Notes = "فاتورة دواء",
                    PaymentNotes = "لم يتم الدفع بعد",
                    IsDeleted = false,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Invoice
                {
                    Id = Guid.NewGuid(),
                    PatientId = Guid.NewGuid(), // معرف المريض
                    CreatedBy = Guid.NewGuid().ToString(), // معرف المستخدم الذي أنشأ الفاتورة
                    InvoiceNumber = "INV-004-2024",
                    InvoiceDate = DateTime.UtcNow.AddDays(-7),
                    DueDate = DateTime.UtcNow.AddDays(23),
                    TotalAmount = 1000.00m,
                    TaxAmount = 140.00m,
                    DiscountAmount = 100.00m,
                    NetAmount = 1040.00m,
                    Status = InvoiceStatus.Overdue,
                    Notes = "فاتورة جراحة",
                    PaymentNotes = "فاتورة متأخرة",
                    IsDeleted = false,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Invoice
                {
                    Id = Guid.NewGuid(),
                    PatientId = Guid.NewGuid(), // معرف المريض
                    CreatedBy = Guid.NewGuid().ToString(), // معرف المستخدم الذي أنشأ الفاتورة
                    InvoiceNumber = "INV-005-2024",
                    InvoiceDate = DateTime.UtcNow.AddDays(-10),
                    DueDate = DateTime.UtcNow.AddDays(20),
                    TotalAmount = 200.00m,
                    TaxAmount = 28.00m,
                    DiscountAmount = 0.00m,
                    NetAmount = 228.00m,
                    Status = InvoiceStatus.Paid,
                    Notes = "فاتورة متابعة",
                    PaymentNotes = "تم الدفع ببطاقة الائتمان",
                    PaidDate = DateTime.UtcNow.AddDays(-5),
                    PaymentMethod = "بطاقة ائتمان",
                    IsDeleted = false,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
        }
    }
}

