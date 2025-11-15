using System;
using System.Collections.Generic;
using System.Linq;

using Al_Eaida_Domin.Modules;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AL_Eaida_Infrastructure__Layer.DataModules;

namespace AL_Eaida_Infrastructure__Layer
{
    public class AppDBcontext : IdentityDbContext<User, IdentityRole, string>
    {
        public AppDBcontext(DbContextOptions<AppDBcontext> options) : base(options)
        {



        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           

            // Configure Patient entity
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.Phone).IsUnique();
            });

            // Configure Doctor entity
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.Phone).IsUnique();
                entity.HasIndex(e => e.LicenseNumber).IsUnique();
            });

            // Configure Appointment entity
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");
                entity.HasIndex(e => new { e.DoctorId, e.AppointmentDate, e.Time }).IsUnique();
            });

            // Configure Governorate and City relationships
            modelBuilder.Entity<City>()
                .HasOne(c => c.Governorate)
                .WithMany(g => g.Cities)
                .HasForeignKey(c => c.GovernorateId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Address relationships
            modelBuilder.Entity<Address>()
                .HasOne(a => a.Governorate)
                .WithMany()
                .HasForeignKey(a => a.GovernorateId)
                .OnDelete(DeleteBehavior.NoAction);
            // configure Address relationships with City
            modelBuilder.Entity<Address>()
                .HasOne(a => a.City)
                .WithMany()
                .HasForeignKey(a => a.CityId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configure relationships
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.Address)
                .WithOne()
                .HasForeignKey<Patient>(p => p.AddressId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.EmergencyContact)
                .WithOne()
                .HasForeignKey<Patient>(p => p.EmergencyContactId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.InsuranceInfo)
                .WithOne()
                .HasForeignKey<Patient>(p => p.InsuranceInfoId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MedicalRecord>()
                .HasOne(mr => mr.Patient)
                .WithMany(p => p.MedicalHistory)
                .HasForeignKey(mr => mr.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MedicalRecord>()
                .HasOne(mr => mr.Doctor)
                .WithMany(d => d.MedicalRecords)
                .HasForeignKey(mr => mr.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Patient)
                .WithMany()
                .HasForeignKey(p => p.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Doctor)
                .WithMany()
                .HasForeignKey(p => p.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Medication)
                .WithMany(m => m.Prescriptions)
                .HasForeignKey(p => p.MedicationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure many-to-many relationships
          

            modelBuilder.Entity<DoctorSpecialization>()
                .HasKey(ds => ds.Id);
            modelBuilder.Entity<DoctorSpecialization>()
                .HasOne(ds => ds.Doctor)
                .WithMany(d => d.DoctorSpecializations)
                .HasForeignKey(ds => ds.DoctorId);
            modelBuilder.Entity<DoctorSpecialization>()
                .HasOne(ds => ds.Specialization)
                .WithMany(s => s.DoctorSpecializations)
                .HasForeignKey(ds => ds.SpecializationId);

            modelBuilder.Entity<MedicationCategory>()
                .HasKey(mc => mc.Id);
            modelBuilder.Entity<MedicationCategory>()
                .HasOne(mc => mc.Medication)
                .WithMany(m => m.MedicationCategories)
                .HasForeignKey(mc => mc.MedicationId);
            modelBuilder.Entity<MedicationCategory>()
                .HasOne(mc => mc.Category)
                .WithMany(c => c.MedicationCategories)
                .HasForeignKey(mc => mc.CategoryId);

            // Configure enums
           
            modelBuilder.Entity<Patient>()
                .Property(e => e.Gender)
                .HasConversion<string>();

            modelBuilder.Entity<Appointment>()
                .Property(e => e.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Report>()
                .Property(e => e.Type)
                .HasConversion<string>();

            modelBuilder.Entity<SystemSettings>()
                .Property(e => e.Type)
                .HasConversion<string>();

            // Configure audit log
            modelBuilder.Entity<AuditLog>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<AuditLog>()
                .Property(e => e.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<AuditLog>()
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            // Configure MedicalVisit entity
            modelBuilder.Entity<MedicalVisit>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");
                entity.HasIndex(e => e.VisitDate);
            });

            // Configure Invoice entity
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");
                entity.HasIndex(e => e.InvoiceNumber).IsUnique();
                entity.HasIndex(e => e.CreatedAt);
                entity.Property(e => e.TotalAmount).HasPrecision(18, 2);
                entity.Property(e => e.TaxAmount).HasPrecision(18, 2);
                entity.Property(e => e.DiscountAmount).HasPrecision(18, 2);
                entity.Property(e => e.NetAmount).HasPrecision(18, 2);
            });

            // Configure InvoiceItem entity
            modelBuilder.Entity<InvoiceItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");
                entity.Property(e => e.UnitPrice).HasPrecision(18, 2);
                entity.Property(e => e.Amount).HasPrecision(18, 2);
            });

            // Configure PrescriptionItem entity
            modelBuilder.Entity<PrescriptionItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");
            });

            // Configure RefreshToken entity
            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");
                entity.HasIndex(e => e.Token).IsUnique();
            });

            // Configure MedicalVisit relationships
            modelBuilder.Entity<MedicalVisit>()
                .HasOne(mv => mv.Patient)
                .WithMany(p => p.MedicalVisits)
                .HasForeignKey(mv => mv.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MedicalVisit>()
                .HasOne(mv => mv.Doctor)
                .WithMany(d => d.MedicalVisits)
                .HasForeignKey(mv => mv.DoctorID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Invoice relationships
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Patient)
                .WithMany(p => p.Invoices)
                .HasForeignKey(i => i.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.CreatedByUser)
                .WithMany(u => u.CreatedInvoices)
                .HasForeignKey(i => i.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure InvoiceItem relationships
            modelBuilder.Entity<InvoiceItem>()
                .HasOne(ii => ii.Invoice)
                .WithMany(i => i.Items)
                .HasForeignKey(ii => ii.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure PrescriptionItem relationships
            modelBuilder.Entity<PrescriptionItem>()
                .HasOne(pi => pi.Prescription)
                .WithMany(p => p.PrescriptionItems)
                .HasForeignKey(pi => pi.PrescriptionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PrescriptionItem>()
                .HasOne(pi => pi.Medicine)
                .WithMany(m => m.PrescriptionItems)
                .HasForeignKey(pi => pi.MedicineId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure RefreshToken relationships
            modelBuilder.Entity<RefreshToken>()
                .HasOne(rt => rt.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure enums
            modelBuilder.Entity<Invoice>()
                .Property(e => e.Status)
                .HasConversion<string>();

            // Configure decimal precision for existing entities
            modelBuilder.Entity<Medicine>()
                .Property(m => m.Price)
                .HasPrecision(18, 2);

            // Configure indexes
            modelBuilder.Entity<Appointment>()
                .HasIndex(a => a.AppointmentDate);

            modelBuilder.Entity<Invoice>()
                .HasIndex(i => i.CreatedAt);

            // Configure soft delete for entities that have IsDeleted property
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (entityType.FindProperty("IsDeleted") != null)
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property<bool>("IsDeleted")
                        .HasDefaultValue(false);
                }

                if (entityType.FindProperty("CreatedAt") != null)
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property<DateTime>("CreatedAt")
                        .HasDefaultValueSql("GETUTCDATE()");
                }
            }
        


            // Default values and soft delete
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (entityType.FindProperty("IsDeleted") != null)
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property<bool>("IsDeleted")
                        .HasDefaultValue(false);
                }

                if (entityType.FindProperty("CreatedAt") != null)
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property<DateTime>("CreatedAt")
                        .HasDefaultValueSql("GETUTCDATE()");
                }
            }
            // Roles

            modelBuilder.Entity<IdentityRole>()
             .HasData(
                 new IdentityRole
                 {
                     Id = "f2d14089-a797-4493-be63-4a9c80570235",
                     Name = "Admin",
                     NormalizedName = "ADMIN".ToUpper()
                 },
                 new IdentityRole
                 {
                     Id = "4ecb10a6-d9c8-41ec-8577-8256e3d38608",
                     Name = "Doctor",
                     NormalizedName = "DOCTOR".ToUpper()
                 },
                   new IdentityRole
                   {
                       Id = "7626c860-20d2-4402-bb4b-c8a0d067201e",
                       Name = "Receptionist",
                       NormalizedName = "RECEPTIONIST".ToUpper()
                   },
                   new IdentityRole
                   {
                       Id = "f5cea4e7-e825-4663-9586-bfb7a68a58d0",
                       Name = "Accountant ",
                       NormalizedName = "ACCOUNTANT ".ToUpper()
                   }
             );

            // Seed data for Governorates and Cities
            var cairoId = Guid.NewGuid();
            var gizaId = Guid.NewGuid();
            var alexandriaId = Guid.NewGuid();
            var dakahliaId = Guid.NewGuid();
            var redSeaId = Guid.NewGuid();
            var beheiraId = Guid.NewGuid();
            var fayoumId = Guid.NewGuid();
            var gharbiyaId = Guid.NewGuid();
            var ismailiaId = Guid.NewGuid();
            var menofiaId = Guid.NewGuid();
            var minyaId = Guid.NewGuid();
            var qaliubiyaId = Guid.NewGuid();
            var newValleyId = Guid.NewGuid();
            var suezId = Guid.NewGuid();
            var aswanId = Guid.NewGuid();
            var assiutId = Guid.NewGuid();
            var beniSuefId = Guid.NewGuid();
            var portSaidId = Guid.NewGuid();
            var damiettaId = Guid.NewGuid();
            var sharkiaId = Guid.NewGuid();
            var southSinaiId = Guid.NewGuid();
            var kafrSheikhId = Guid.NewGuid();
            var matrouhId = Guid.NewGuid();
            var luxorId = Guid.NewGuid();
            var qenaId = Guid.NewGuid();
            var northSinaiId = Guid.NewGuid();
            var sohagId = Guid.NewGuid();

            modelBuilder.Entity<Governorate>().HasData(
            new Governorate { Id = cairoId, NameAr = "القاهرة", NameEn = "Cairo" },
            new Governorate { Id = gizaId, NameAr = "الجيزة", NameEn = "Giza" },
            new Governorate { Id = alexandriaId, NameAr = "الأسكندرية", NameEn = "Alexandria" },
            new Governorate { Id = dakahliaId, NameAr = "الدقهلية", NameEn = "Dakahlia" },
            new Governorate { Id = redSeaId, NameAr = "البحر الأحمر", NameEn = "Red Sea" },
            new Governorate { Id = beheiraId, NameAr = "البحيرة", NameEn = "Beheira" },
            new Governorate { Id = fayoumId, NameAr = "الفيوم", NameEn = "Fayoum" },
            new Governorate { Id = gharbiyaId, NameAr = "الغربية", NameEn = "Gharbiya" },
            new Governorate { Id = ismailiaId, NameAr = "الإسماعلية", NameEn = "Ismailia" },
            new Governorate { Id = menofiaId, NameAr = "المنوفية", NameEn = "Menofia" },
            new Governorate { Id = minyaId, NameAr = "المنيا", NameEn = "Minya" },
            new Governorate { Id = qaliubiyaId, NameAr = "القليوبية", NameEn = "Qaliubiya" },
            new Governorate { Id = newValleyId, NameAr = "الوادي الجديد", NameEn = "New Valley" },
            new Governorate { Id = suezId, NameAr = "السويس", NameEn = "Suez" },
            new Governorate { Id = aswanId, NameAr = "اسوان", NameEn = "Aswan" },
            new Governorate { Id = assiutId, NameAr = "اسيوط", NameEn = "Assiut" },
            new Governorate { Id = beniSuefId, NameAr = "بني سويف", NameEn = "Beni Suef" },
            new Governorate { Id = portSaidId, NameAr = "بورسعيد", NameEn = "Port Said" },
            new Governorate { Id = damiettaId, NameAr = "دمياط", NameEn = "Damietta" },
            new Governorate { Id = sharkiaId, NameAr = "الشرقية", NameEn = "Sharkia" },
            new Governorate { Id = southSinaiId, NameAr = "جنوب سيناء", NameEn = "South Sinai" },
            new Governorate { Id = kafrSheikhId, NameAr = "كفر الشيخ", NameEn = "Kafr Al sheikh" },
            new Governorate { Id = matrouhId, NameAr = "مطروح", NameEn = "Matrouh" },
            new Governorate { Id = luxorId, NameAr = "الأقصر", NameEn = "Luxor" },
            new Governorate { Id = qenaId, NameAr = "قنا", NameEn = "Qena" },
            new Governorate { Id = northSinaiId, NameAr = "شمال سيناء", NameEn = "North Sinai" },
            new Governorate { Id = sohagId, NameAr = "سوهاج", NameEn = "Sohag" }
        );

        // Sample cities for Cairo (first governorate)
        modelBuilder.Entity<City>().HasData(
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "15 مايو", NameEn = "15 May" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "الازبكية", NameEn = "Al Azbakeyah" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "البساتين", NameEn = "Al Basatin" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "التبين", NameEn = "Tebin" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "الخليفة", NameEn = "El-Khalifa" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "الدراسة", NameEn = "El darrasa" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "الدرب الاحمر", NameEn = "Aldarb Alahmar" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "الزاوية الحمراء", NameEn = "Zawya al-Hamra" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "الزيتون", NameEn = "El-Zaytoun" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "الساحل", NameEn = "Sahel" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "السلام", NameEn = "El Salam" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "السيدة زينب", NameEn = "Sayeda Zeinab" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "الشرابية", NameEn = "El Sharabeya" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "مدينة الشروق", NameEn = "Shorouk" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "الظاهر", NameEn = "El Daher" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "العتبة", NameEn = "Ataba" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "القاهرة الجديدة", NameEn = "New Cairo" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "المرج", NameEn = "El Marg" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "عزبة النخل", NameEn = "Ezbet el Nakhl" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "المطرية", NameEn = "Matareya" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "المعادى", NameEn = "Maadi" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "المعصرة", NameEn = "Maasara" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "المقطم", NameEn = "Mokattam" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "المنيل", NameEn = "Manyal" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "الموسكى", NameEn = "Mosky" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "النزهة", NameEn = "Nozha" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "الوايلى", NameEn = "Waily" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "باب الشعرية", NameEn = "Bab al-Shereia" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "بولاق", NameEn = "Bolaq" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "جاردن سيتى", NameEn = "Garden City" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "حدائق القبة", NameEn = "Hadayek El-Kobba" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "حلوان", NameEn = "Helwan" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "دار السلام", NameEn = "Dar Al Salam" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "شبرا", NameEn = "Shubra" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "طره", NameEn = "Tura" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "عابدين", NameEn = "Abdeen" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "عباسية", NameEn = "Abaseya" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "عين شمس", NameEn = "Ain Shms" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "مدينة نصر", NameEn = "Nasr City" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "مصر الجديدة", NameEn = "New Heliopolis" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "مصر القديمة", NameEn = "Masr Al Qadima" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "منشية ناصر", NameEn = "Mansheya Nasir" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "مدينة بدر", NameEn = "Badr City" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "مدينة العبور", NameEn = "Obour City" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "وسط البلد", NameEn = "Cairo Downtown" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "الزمالك", NameEn = "Zamalek" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "قصر النيل", NameEn = "Kasr El Nile" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "الرحاب", NameEn = "Rehab" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "القطامية", NameEn = "Katameya" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "مدينتي", NameEn = "Madinty" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "روض الفرج", NameEn = "Rod Alfarag" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "شيراتون", NameEn = "Sheraton" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "الجمالية", NameEn = "El-Gamaleya" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "العاشر من رمضان", NameEn = "10th of Ramadan City" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "الحلمية", NameEn = "Helmeyat Alzaytoun" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "النزهة الجديدة", NameEn = "New Nozha" },
            new City { Id = Guid.NewGuid(), GovernorateId = cairoId, NameAr = "العاصمة الإدارية", NameEn = "Capital New" }
        );

        // Sample cities for Giza (second governorate)
        modelBuilder.Entity<City>().HasData(
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "الجيزة", NameEn = "Giza" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "السادس من أكتوبر", NameEn = "Sixth of October" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "الشيخ زايد", NameEn = "Cheikh Zayed" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "الحوامدية", NameEn = "Hawamdiyah" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "البدرشين", NameEn = "Al Badrasheen" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "الصف", NameEn = "Saf" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "أطفيح", NameEn = "Atfih" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "العياط", NameEn = "Al Ayat" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "الباويطي", NameEn = "Al-Bawaiti" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "منشأة القناطر", NameEn = "ManshiyetAl Qanater" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "أوسيم", NameEn = "Oaseem" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "كرداسة", NameEn = "Kerdasa" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "أبو النمرس", NameEn = "Abu Nomros" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "كفر غطاطي", NameEn = "Kafr Ghati" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "منشأة البكاري", NameEn = "Manshiyet Al Bakari" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "الدقى", NameEn = "Dokki" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "العجوزة", NameEn = "Agouza" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "الهرم", NameEn = "Haram" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "الوراق", NameEn = "Warraq" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "امبابة", NameEn = "Imbaba" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "بولاق الدكرور", NameEn = "Boulaq Dakrour" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "الواحات البحرية", NameEn = "Al Wahat Al Baharia" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "العمرانية", NameEn = "Omraneya" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "المنيب", NameEn = "Moneeb" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "بين السرايات", NameEn = "Bin Alsarayat" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "الكيت كات", NameEn = "Kit Kat" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "المهندسين", NameEn = "Mohandessin" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "فيصل", NameEn = "Faisal" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "أبو رواش", NameEn = "Abu Rawash" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "حدائق الأهرام", NameEn = "Hadayek Alahram" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "الحرانية", NameEn = "Haraneya" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "حدائق اكتوبر", NameEn = "Hadayek October" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "صفط اللبن", NameEn = "Saft Allaban" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "القرية الذكية", NameEn = "Smart Village" },
            new City { Id = Guid.NewGuid(), GovernorateId = gizaId, NameAr = "ارض اللواء", NameEn = "Ard Ellwaa" }
            );

        // Sample cities for Alexandria
        modelBuilder.Entity<City>().HasData(
            new City { Id = Guid.NewGuid(), GovernorateId = alexandriaId, NameAr = "الإسكندرية", NameEn = "Alexandria" },
            new City { Id = Guid.NewGuid(), GovernorateId = alexandriaId, NameAr = "برج العرب", NameEn = "Borg El Arab" },
            new City { Id = Guid.NewGuid(), GovernorateId = alexandriaId, NameAr = "برج العرب الجديدة", NameEn = "New Borg El Arab" },
            new City { Id = Guid.NewGuid(), GovernorateId = alexandriaId, NameAr = "العامرية", NameEn = "Amreya" },
            new City { Id = Guid.NewGuid(), GovernorateId = alexandriaId, NameAr = "الأنفوشي", NameEn = "Anfoushi" },
            new City { Id = Guid.NewGuid(), GovernorateId = alexandriaId, NameAr = "العصافرة", NameEn = "Asafra" },
            new City { Id = Guid.NewGuid(), GovernorateId = alexandriaId, NameAr = "العطارين", NameEn = "Attarin" },
            new City { Id = Guid.NewGuid(), GovernorateId = alexandriaId, NameAr = "أبو قير", NameEn = "Abu Qir" },
            new City { Id = Guid.NewGuid(), GovernorateId = alexandriaId, NameAr = "باكوس", NameEn = "Bakos" },
            new City { Id = Guid.NewGuid(), GovernorateId = alexandriaId, NameAr = "بولكلي", NameEn = "Bolkly" },
            new City { Id = Guid.NewGuid(), GovernorateId = alexandriaId, NameAr = "كليوباترا", NameEn = "Cleopatra" },
            new City { Id = Guid.NewGuid(), GovernorateId = alexandriaId, NameAr = "الدخيلة", NameEn = "Dekheila" },
            new City { Id = Guid.NewGuid(), GovernorateId = alexandriaId, NameAr = "الرمل", NameEn = "El Raml" },
            new City { Id = Guid.NewGuid(), GovernorateId = alexandriaId, NameAr = "فلمنج", NameEn = "Fleming" },
            new City { Id = Guid.NewGuid(), GovernorateId = alexandriaId, NameAr = "جناكليس", NameEn = "Gianaclis" },
            new City { Id = Guid.NewGuid(), GovernorateId = alexandriaId, NameAr = "جليم", NameEn = "Gleem" },
            new City { Id = Guid.NewGuid(), GovernorateId = alexandriaId, NameAr = "المنتزه", NameEn = "Montaza" },
            new City { Id = Guid.NewGuid(), GovernorateId = alexandriaId, NameAr = "المكس", NameEn = "Maks" },
            new City { Id = Guid.NewGuid(), GovernorateId = alexandriaId, NameAr = "المندرة", NameEn = "Mandara" },
            new City { Id = Guid.NewGuid(), GovernorateId = alexandriaId, NameAr = "محرم بك", NameEn = "Moharam Bek" },
            new City { Id = Guid.NewGuid(), GovernorateId = alexandriaId, NameAr = "الورديان", NameEn = "Wardian" },
            new City { Id = Guid.NewGuid(), GovernorateId = alexandriaId, NameAr = "سيدي بشر", NameEn = "Sidi Bishr" },
            new City { Id = Guid.NewGuid(), GovernorateId = alexandriaId, NameAr = "سيدي جابر", NameEn = "Sidi Gaber" },
            new City { Id = Guid.NewGuid(), GovernorateId = alexandriaId, NameAr = "سموحة", NameEn = "Smouha" },
            new City { Id = Guid.NewGuid(), GovernorateId = alexandriaId, NameAr = "ستانلي", NameEn = "Stanley" },
            new City { Id = Guid.NewGuid(), GovernorateId = alexandriaId, NameAr = "سيدي كرير", NameEn = "Sidi Kerir" },
            new City { Id = Guid.NewGuid(), GovernorateId = alexandriaId, NameAr = "سيدي كرير الجديدة", NameEn = "New Sidi Kerir" },
            new City { Id = Guid.NewGuid(), GovernorateId = alexandriaId, NameAr = "الزيتون", NameEn = "Zaytoun" }
            );

        // Sample cities for Dakahlia
        modelBuilder.Entity<City>().HasData(
            new City { Id = Guid.NewGuid(), GovernorateId = dakahliaId, NameAr = "المنصورة", NameEn = "Mansoura" },
            new City { Id = Guid.NewGuid(), GovernorateId = dakahliaId, NameAr = "أجا", NameEn = "Aga" },
            new City { Id = Guid.NewGuid(), GovernorateId = dakahliaId, NameAr = "السنبلاوين", NameEn = "Sinbillawin" },
            new City { Id = Guid.NewGuid(), GovernorateId = dakahliaId, NameAr = "المنزلة", NameEn = "Manzala" },
            new City { Id = Guid.NewGuid(), GovernorateId = dakahliaId, NameAr = "ميت غمر", NameEn = "Mit Ghamr" },
            new City { Id = Guid.NewGuid(), GovernorateId = dakahliaId, NameAr = "دكرنس", NameEn = "Dekernes" },
            new City { Id = Guid.NewGuid(), GovernorateId = dakahliaId, NameAr = "المنصورة الجديدة", NameEn = "New Mansoura" },
            new City { Id = Guid.NewGuid(), GovernorateId = dakahliaId, NameAr = "طلخا", NameEn = "Talkha" },
            new City { Id = Guid.NewGuid(), GovernorateId = dakahliaId, NameAr = "ميت سلسيل", NameEn = "Mit Salsil" },
            new City { Id = Guid.NewGuid(), GovernorateId = dakahliaId, NameAr = "المنصورة القديمة", NameEn = "Old Mansoura" }
            );

        // Sample cities for Red Sea
        modelBuilder.Entity<City>().HasData(
            new City { Id = Guid.NewGuid(), GovernorateId = redSeaId, NameAr = "الغردقة", NameEn = "Hurghada" },
            new City { Id = Guid.NewGuid(), GovernorateId = redSeaId, NameAr = "رأس غارب", NameEn = "Ras Gharib" },
            new City { Id = Guid.NewGuid(), GovernorateId = redSeaId, NameAr = "سفاجا", NameEn = "Safaga" },
            new City { Id = Guid.NewGuid(), GovernorateId = redSeaId, NameAr = "القصير", NameEn = "Quseir" },
            new City { Id = Guid.NewGuid(), GovernorateId = redSeaId, NameAr = "مرسى علم", NameEn = "Marsa Alam" },
            new City { Id = Guid.NewGuid(), GovernorateId = redSeaId, NameAr = "شلاتين", NameEn = "Shalateen" },
            new City { Id = Guid.NewGuid(), GovernorateId = redSeaId, NameAr = "حلايب", NameEn = "Halayeb" }
            );

        // Sample cities for Beheira
        modelBuilder.Entity<City>().HasData(
            new City { Id = Guid.NewGuid(), GovernorateId = beheiraId, NameAr = "دمنهور", NameEn = "Damanhur" },
            new City { Id = Guid.NewGuid(), GovernorateId = beheiraId, NameAr = "رشيد", NameEn = "Rashid" },
            new City { Id = Guid.NewGuid(), GovernorateId = beheiraId, NameAr = "كفر الدوار", NameEn = "Kafr El Dawwar" },
            new City { Id = Guid.NewGuid(), GovernorateId = beheiraId, NameAr = "إدكو", NameEn = "Edku" },
            new City { Id = Guid.NewGuid(), GovernorateId = beheiraId, NameAr = "أبو المطامير", NameEn = "Abu El Matamir" },
            new City { Id = Guid.NewGuid(), GovernorateId = beheiraId, NameAr = "النوبارية الجديدة", NameEn = "New Nubaria" },
            new City { Id = Guid.NewGuid(), GovernorateId = beheiraId, NameAr = "وادي النطرون", NameEn = "Wadi El Natrun" },
            new City { Id = Guid.NewGuid(), GovernorateId = beheiraId, NameAr = "الحمام", NameEn = "El Hamam" },
            new City { Id = Guid.NewGuid(), GovernorateId = beheiraId, NameAr = "كوم حمادة", NameEn = "Kom Hamada" },
            new City { Id = Guid.NewGuid(), GovernorateId = beheiraId, NameAr = "الدلنجات", NameEn = "Delengat" }
            );

        // Sample cities for other governorates
        modelBuilder.Entity<City>().HasData(
            // Fayoum
            new City { Id = Guid.NewGuid(), GovernorateId = fayoumId, NameAr = "الفيوم", NameEn = "Fayoum" },
            new City { Id = Guid.NewGuid(), GovernorateId = fayoumId, NameAr = "طامية", NameEn = "Tamiya" },
            new City { Id = Guid.NewGuid(), GovernorateId = fayoumId, NameAr = "سنورس", NameEn = "Senuors" },
            new City { Id = Guid.NewGuid(), GovernorateId = fayoumId, NameAr = "إطسا", NameEn = "Itsa" },
            new City { Id = Guid.NewGuid(), GovernorateId = fayoumId, NameAr = "إبشواي", NameEn = "Ibshway" },
            new City { Id = Guid.NewGuid(), GovernorateId = fayoumId, NameAr = "يوسف الصديق", NameEn = "Yusuf El Sadiq" },
            
            // Gharbiya
            new City { Id = Guid.NewGuid(), GovernorateId = gharbiyaId, NameAr = "طنطا", NameEn = "Tanta" },
            new City { Id = Guid.NewGuid(), GovernorateId = gharbiyaId, NameAr = "المحلة الكبرى", NameEn = "Mahalla El Kubra" },
            new City { Id = Guid.NewGuid(), GovernorateId = gharbiyaId, NameAr = "كفر الزيات", NameEn = "Kafr El Zayat" },
            new City { Id = Guid.NewGuid(), GovernorateId = gharbiyaId, NameAr = "زفتى", NameEn = "Zefta" },
            new City { Id = Guid.NewGuid(), GovernorateId = gharbiyaId, NameAr = "السنطة", NameEn = "Santan" },
            new City { Id = Guid.NewGuid(), GovernorateId = gharbiyaId, NameAr = "قطور", NameEn = "Qutur" },
            new City { Id = Guid.NewGuid(), GovernorateId = gharbiyaId, NameAr = "بسيون", NameEn = "Basyoun" },
            new City { Id = Guid.NewGuid(), GovernorateId = gharbiyaId, NameAr = "سمنود", NameEn = "Samannoud" },
            
            // Ismailia
            new City { Id = Guid.NewGuid(), GovernorateId = ismailiaId, NameAr = "الإسماعيلية", NameEn = "Ismailia" },
            new City { Id = Guid.NewGuid(), GovernorateId = ismailiaId, NameAr = "فايد", NameEn = "Fayed" },
            new City { Id = Guid.NewGuid(), GovernorateId = ismailiaId, NameAr = "القنطرة شرق", NameEn = "Qantara East" },
            new City { Id = Guid.NewGuid(), GovernorateId = ismailiaId, NameAr = "القنطرة غرب", NameEn = "Qantara West" },
            new City { Id = Guid.NewGuid(), GovernorateId = ismailiaId, NameAr = "التل الكبير", NameEn = "El Tal El Kabir" },
            new City { Id = Guid.NewGuid(), GovernorateId = ismailiaId, NameAr = "أبو صوير", NameEn = "Abu Suwir" },
            new City { Id = Guid.NewGuid(), GovernorateId = ismailiaId, NameAr = "القصاصين", NameEn = "Qassasin" },
            
            // Menofia
            new City { Id = Guid.NewGuid(), GovernorateId = menofiaId, NameAr = "شبين الكوم", NameEn = "Shibin El Kom" },
            new City { Id = Guid.NewGuid(), GovernorateId = menofiaId, NameAr = "منوف", NameEn = "Menouf" },
            new City { Id = Guid.NewGuid(), GovernorateId = menofiaId, NameAr = "سرس الليان", NameEn = "Sers El Layan" },
            new City { Id = Guid.NewGuid(), GovernorateId = menofiaId, NameAr = "أشمون", NameEn = "Ashmun" },
            new City { Id = Guid.NewGuid(), GovernorateId = menofiaId, NameAr = "الباجور", NameEn = "El Bagour" },
            new City { Id = Guid.NewGuid(), GovernorateId = menofiaId, NameAr = "قويسنا", NameEn = "Quesna" },
            new City { Id = Guid.NewGuid(), GovernorateId = menofiaId, NameAr = "بركة السبع", NameEn = "Berkat El Saba" },
            new City { Id = Guid.NewGuid(), GovernorateId = menofiaId, NameAr = "تلا", NameEn = "Tala" },
            new City { Id = Guid.NewGuid(), GovernorateId = menofiaId, NameAr = "الشهداء", NameEn = "El Shohada" },
            
            // Minya
            new City { Id = Guid.NewGuid(), GovernorateId = minyaId, NameAr = "المنيا", NameEn = "Minya" },
            new City { Id = Guid.NewGuid(), GovernorateId = minyaId, NameAr = "المنيا الجديدة", NameEn = "New Minya" },
            new City { Id = Guid.NewGuid(), GovernorateId = minyaId, NameAr = "العدوة", NameEn = "El Adwa" },
            new City { Id = Guid.NewGuid(), GovernorateId = minyaId, NameAr = "مغاغة", NameEn = "Maghagha" },
            new City { Id = Guid.NewGuid(), GovernorateId = minyaId, NameAr = "بني مزار", NameEn = "Bani Mazar" },
            new City { Id = Guid.NewGuid(), GovernorateId = minyaId, NameAr = "مطاي", NameEn = "Matai" },
            new City { Id = Guid.NewGuid(), GovernorateId = minyaId, NameAr = "سمالوط", NameEn = "Samalut" },
            new City { Id = Guid.NewGuid(), GovernorateId = minyaId, NameAr = "ملوي", NameEn = "Mallawi" },
            new City { Id = Guid.NewGuid(), GovernorateId = minyaId, NameAr = "أبو قرقاص", NameEn = "Abu Qurqas" },
            
            // Qaliubiya
            new City { Id = Guid.NewGuid(), GovernorateId = qaliubiyaId, NameAr = "بنها", NameEn = "Benha" },
            new City { Id = Guid.NewGuid(), GovernorateId = qaliubiyaId, NameAr = "قليوب", NameEn = "Qalyub" },
            new City { Id = Guid.NewGuid(), GovernorateId = qaliubiyaId, NameAr = "شبرا الخيمة", NameEn = "Shubra El Kheima" },
            new City { Id = Guid.NewGuid(), GovernorateId = qaliubiyaId, NameAr = "الخانكة", NameEn = "El Khanka" },
            new City { Id = Guid.NewGuid(), GovernorateId = qaliubiyaId, NameAr = "كفر شكر", NameEn = "Kafr Shukr" },
            new City { Id = Guid.NewGuid(), GovernorateId = qaliubiyaId, NameAr = "طوخ", NameEn = "Toukh" },
            new City { Id = Guid.NewGuid(), GovernorateId = qaliubiyaId, NameAr = "القناطر الخيرية", NameEn = "Qanater El Khayreya" },
            new City { Id = Guid.NewGuid(), GovernorateId = qaliubiyaId, NameAr = "العبور", NameEn = "El Obour" },
            
            // Suez
            new City { Id = Guid.NewGuid(), GovernorateId = suezId, NameAr = "السويس", NameEn = "Suez" },
            new City { Id = Guid.NewGuid(), GovernorateId = suezId, NameAr = "الأربعين", NameEn = "El Arba'in" },
            new City { Id = Guid.NewGuid(), GovernorateId = suezId, NameAr = "فايد", NameEn = "Fayed" },
            new City { Id = Guid.NewGuid(), GovernorateId = suezId, NameAr = "الجناين", NameEn = "El Ganayen" },
            new City { Id = Guid.NewGuid(), GovernorateId = suezId, NameAr = "عتاقة", NameEn = "Ataka" },
            
            // Aswan
            new City { Id = Guid.NewGuid(), GovernorateId = aswanId, NameAr = "أسوان", NameEn = "Aswan" },
            new City { Id = Guid.NewGuid(), GovernorateId = aswanId, NameAr = "كوم أمبو", NameEn = "Kom Ombo" },
            new City { Id = Guid.NewGuid(), GovernorateId = aswanId, NameAr = "دراو", NameEn = "Daraw" },
            new City { Id = Guid.NewGuid(), GovernorateId = aswanId, NameAr = "إدفو", NameEn = "Edfu" },
            new City { Id = Guid.NewGuid(), GovernorateId = aswanId, NameAr = "نصر النوبة", NameEn = "Nasr El Nuba" },
            new City { Id = Guid.NewGuid(), GovernorateId = aswanId, NameAr = "كلابشة", NameEn = "Kalabsha" },
            
            // Assiut
            new City { Id = Guid.NewGuid(), GovernorateId = assiutId, NameAr = "أسيوط", NameEn = "Assiut" },
            new City { Id = Guid.NewGuid(), GovernorateId = assiutId, NameAr = "أسيوط الجديدة", NameEn = "New Assiut" },
            new City { Id = Guid.NewGuid(), GovernorateId = assiutId, NameAr = "ديروط", NameEn = "Deirout" },
            new City { Id = Guid.NewGuid(), GovernorateId = assiutId, NameAr = "منفلوط", NameEn = "Manfalut" },
            new City { Id = Guid.NewGuid(), GovernorateId = assiutId, NameAr = "القوصية", NameEn = "El Qusiya" },
            new City { Id = Guid.NewGuid(), GovernorateId = assiutId, NameAr = "أبو تيج", NameEn = "Abu Tig" },
            new City { Id = Guid.NewGuid(), GovernorateId = assiutId, NameAr = "الغنايم", NameEn = "El Ghanaim" },
            new City { Id = Guid.NewGuid(), GovernorateId = assiutId, NameAr = "ساحل سليم", NameEn = "Sahil Selim" },
            new City { Id = Guid.NewGuid(), GovernorateId = assiutId, NameAr = "البداري", NameEn = "El Badari" },
            new City { Id = Guid.NewGuid(), GovernorateId = assiutId, NameAr = "صدفا", NameEn = "Sidfa" },
            
            // Beni Suef
            new City { Id = Guid.NewGuid(), GovernorateId = beniSuefId, NameAr = "بني سويف", NameEn = "Beni Suef" },
            new City { Id = Guid.NewGuid(), GovernorateId = beniSuefId, NameAr = "بني سويف الجديدة", NameEn = "New Beni Suef" },
            new City { Id = Guid.NewGuid(), GovernorateId = beniSuefId, NameAr = "الواسطى", NameEn = "El Wasta" },
            new City { Id = Guid.NewGuid(), GovernorateId = beniSuefId, NameAr = "ناصر", NameEn = "Naser" },
            new City { Id = Guid.NewGuid(), GovernorateId = beniSuefId, NameAr = "إهناسيا", NameEn = "Ehnasia" },
            new City { Id = Guid.NewGuid(), GovernorateId = beniSuefId, NameAr = "ببا", NameEn = "Biba" },
            new City { Id = Guid.NewGuid(), GovernorateId = beniSuefId, NameAr = "الفشن", NameEn = "El Fashn" },
            new City { Id = Guid.NewGuid(), GovernorateId = beniSuefId, NameAr = "سمسطا", NameEn = "Somasta" },
            
            // Port Said
            new City { Id = Guid.NewGuid(), GovernorateId = portSaidId, NameAr = "بورسعيد", NameEn = "Port Said" },
            new City { Id = Guid.NewGuid(), GovernorateId = portSaidId, NameAr = "بورفؤاد", NameEn = "Port Fuad" },
            new City { Id = Guid.NewGuid(), GovernorateId = portSaidId, NameAr = "الضاحية", NameEn = "El Dahiya" },
            new City { Id = Guid.NewGuid(), GovernorateId = portSaidId, NameAr = "المناخ", NameEn = "El Manakh" },
            new City { Id = Guid.NewGuid(), GovernorateId = portSaidId, NameAr = "الزهور", NameEn = "El Zohour" },
            new City { Id = Guid.NewGuid(), GovernorateId = portSaidId, NameAr = "الشرقية", NameEn = "El Sharqiya" },
            new City { Id = Guid.NewGuid(), GovernorateId = portSaidId, NameAr = "الغربية", NameEn = "El Gharbiya" },
            
            // Damietta
            new City { Id = Guid.NewGuid(), GovernorateId = damiettaId, NameAr = "دمياط", NameEn = "Damietta" },
            new City { Id = Guid.NewGuid(), GovernorateId = damiettaId, NameAr = "دمياط الجديدة", NameEn = "New Damietta" },
            new City { Id = Guid.NewGuid(), GovernorateId = damiettaId, NameAr = "الروضة", NameEn = "El Rawda" },
            new City { Id = Guid.NewGuid(), GovernorateId = damiettaId, NameAr = "كفر سعد", NameEn = "Kafr Saad" },
            new City { Id = Guid.NewGuid(), GovernorateId = damiettaId, NameAr = "زرقون", NameEn = "Zarqoun" },
            new City { Id = Guid.NewGuid(), GovernorateId = damiettaId, NameAr = "السرو", NameEn = "El Sarou" },
            new City { Id = Guid.NewGuid(), GovernorateId = damiettaId, NameAr = "الرحمانية", NameEn = "El Rahmaniya" },
            new City { Id = Guid.NewGuid(), GovernorateId = damiettaId, NameAr = "فارسكور", NameEn = "Fareskour" },
            new City { Id = Guid.NewGuid(), GovernorateId = damiettaId, NameAr = "الزرقا", NameEn = "El Zarqa" },
            
            // Sharkia
            new City { Id = Guid.NewGuid(), GovernorateId = sharkiaId, NameAr = "الزقازيق", NameEn = "Zagazig" },
            new City { Id = Guid.NewGuid(), GovernorateId = sharkiaId, NameAr = "الزقازيق الجديدة", NameEn = "New Zagazig" },
            new City { Id = Guid.NewGuid(), GovernorateId = sharkiaId, NameAr = "العاشر من رمضان", NameEn = "10th of Ramadan" },
            new City { Id = Guid.NewGuid(), GovernorateId = sharkiaId, NameAr = "بلبيس", NameEn = "Belbeis" },
            new City { Id = Guid.NewGuid(), GovernorateId = sharkiaId, NameAr = "أبو كبير", NameEn = "Abu Kabir" },
            new City { Id = Guid.NewGuid(), GovernorateId = sharkiaId, NameAr = "فاقوس", NameEn = "Faqous" },
            new City { Id = Guid.NewGuid(), GovernorateId = sharkiaId, NameAr = "الإبراهيمية", NameEn = "El Ibrahimiya" },
            new City { Id = Guid.NewGuid(), GovernorateId = sharkiaId, NameAr = "ديرب نجم", NameEn = "Deirb Negm" },
            new City { Id = Guid.NewGuid(), GovernorateId = sharkiaId, NameAr = "كفر صقر", NameEn = "Kafr Saqr" },
            new City { Id = Guid.NewGuid(), GovernorateId = sharkiaId, NameAr = "أولاد صقر", NameEn = "Awlad Saqr" },
            new City { Id = Guid.NewGuid(), GovernorateId = sharkiaId, NameAr = "ههيا", NameEn = "Hihya" },
            new City { Id = Guid.NewGuid(), GovernorateId = sharkiaId, NameAr = "أبو حماد", NameEn = "Abu Hammad" },
            new City { Id = Guid.NewGuid(), GovernorateId = sharkiaId, NameAr = "القرين", NameEn = "El Qurein" },
            new City { Id = Guid.NewGuid(), GovernorateId = sharkiaId, NameAr = "هيئة قناة السويس", NameEn = "Suez Canal Authority" },
            
            // South Sinai
            new City { Id = Guid.NewGuid(), GovernorateId = southSinaiId, NameAr = "الطور", NameEn = "El Tor" },
            new City { Id = Guid.NewGuid(), GovernorateId = southSinaiId, NameAr = "شرم الشيخ", NameEn = "Sharm El Sheikh" },
            new City { Id = Guid.NewGuid(), GovernorateId = southSinaiId, NameAr = "دهب", NameEn = "Dahab" },
            new City { Id = Guid.NewGuid(), GovernorateId = southSinaiId, NameAr = "نويبع", NameEn = "Nuweiba" },
            new City { Id = Guid.NewGuid(), GovernorateId = southSinaiId, NameAr = "طابا", NameEn = "Taba" },
            new City { Id = Guid.NewGuid(), GovernorateId = southSinaiId, NameAr = "سانت كاترين", NameEn = "Saint Catherine" },
            new City { Id = Guid.NewGuid(), GovernorateId = southSinaiId, NameAr = "أبو رديس", NameEn = "Abu Redis" },
            new City { Id = Guid.NewGuid(), GovernorateId = southSinaiId, NameAr = "أبو زنيمة", NameEn = "Abu Zenima" },
            
            // Kafr Sheikh
            new City { Id = Guid.NewGuid(), GovernorateId = kafrSheikhId, NameAr = "كفر الشيخ", NameEn = "Kafr El Sheikh" },
            new City { Id = Guid.NewGuid(), GovernorateId = kafrSheikhId, NameAr = "كفر الشيخ الجديدة", NameEn = "New Kafr El Sheikh" },
            new City { Id = Guid.NewGuid(), GovernorateId = kafrSheikhId, NameAr = "دسوق", NameEn = "Desouk" },
            new City { Id = Guid.NewGuid(), GovernorateId = kafrSheikhId, NameAr = "فوه", NameEn = "Fuwa" },
            new City { Id = Guid.NewGuid(), GovernorateId = kafrSheikhId, NameAr = "مطوبس", NameEn = "Metoubes" },
            new City { Id = Guid.NewGuid(), GovernorateId = kafrSheikhId, NameAr = "البرلس", NameEn = "El Borollos" },
            new City { Id = Guid.NewGuid(), GovernorateId = kafrSheikhId, NameAr = "الحامول", NameEn = "El Hamool" },
            new City { Id = Guid.NewGuid(), GovernorateId = kafrSheikhId, NameAr = "بيلا", NameEn = "Bella" },
            new City { Id = Guid.NewGuid(), GovernorateId = kafrSheikhId, NameAr = "الرياض", NameEn = "El Riyad" },
            new City { Id = Guid.NewGuid(), GovernorateId = kafrSheikhId, NameAr = "سيدي سالم", NameEn = "Sidi Salem" },
            new City { Id = Guid.NewGuid(), GovernorateId = kafrSheikhId, NameAr = "قلين", NameEn = "Qallin" },
            
            // Matrouh
            new City { Id = Guid.NewGuid(), GovernorateId = matrouhId, NameAr = "مرسى مطروح", NameEn = "Marsa Matrouh" },
            new City { Id = Guid.NewGuid(), GovernorateId = matrouhId, NameAr = "الحمام", NameEn = "El Hamam" },
            new City { Id = Guid.NewGuid(), GovernorateId = matrouhId, NameAr = "العلمين", NameEn = "El Alamein" },
            new City { Id = Guid.NewGuid(), GovernorateId = matrouhId, NameAr = "الضبعة", NameEn = "El Dabaa" },
            new City { Id = Guid.NewGuid(), GovernorateId = matrouhId, NameAr = "النجيلة", NameEn = "El Negila" },
            new City { Id = Guid.NewGuid(), GovernorateId = matrouhId, NameAr = "سيدي براني", NameEn = "Sidi Barrani" },
            new City { Id = Guid.NewGuid(), GovernorateId = matrouhId, NameAr = "السلوم", NameEn = "El Salloum" },
            new City { Id = Guid.NewGuid(), GovernorateId = matrouhId, NameAr = "سيوة", NameEn = "Siwa" },
            
            // Luxor
            new City { Id = Guid.NewGuid(), GovernorateId = luxorId, NameAr = "الأقصر", NameEn = "Luxor" },
            new City { Id = Guid.NewGuid(), GovernorateId = luxorId, NameAr = "الأقصر الجديدة", NameEn = "New Luxor" },
            new City { Id = Guid.NewGuid(), GovernorateId = luxorId, NameAr = "القرنة", NameEn = "El Qurna" },
            new City { Id = Guid.NewGuid(), GovernorateId = luxorId, NameAr = "الزينية", NameEn = "El Ziniya" },
            new City { Id = Guid.NewGuid(), GovernorateId = luxorId, NameAr = "بياضة", NameEn = "Bayada" },
            new City { Id = Guid.NewGuid(), GovernorateId = luxorId, NameAr = "الطود", NameEn = "El Tod" },
            new City { Id = Guid.NewGuid(), GovernorateId = luxorId, NameAr = "إسنا", NameEn = "Esna" },
            new City { Id = Guid.NewGuid(), GovernorateId = luxorId, NameAr = "أرمنت", NameEn = "Armant" },
            
            // Qena
            new City { Id = Guid.NewGuid(), GovernorateId = qenaId, NameAr = "قنا", NameEn = "Qena" },
            new City { Id = Guid.NewGuid(), GovernorateId = qenaId, NameAr = "قنا الجديدة", NameEn = "New Qena" },
            new City { Id = Guid.NewGuid(), GovernorateId = qenaId, NameAr = "أبو تشت", NameEn = "Abu Tesht" },
            new City { Id = Guid.NewGuid(), GovernorateId = qenaId, NameAr = "نجع حمادي", NameEn = "Nag Hammadi" },
            new City { Id = Guid.NewGuid(), GovernorateId = qenaId, NameAr = "دشنا", NameEn = "Deshna" },
            new City { Id = Guid.NewGuid(), GovernorateId = qenaId, NameAr = "الوقف", NameEn = "El Waqf" },
            new City { Id = Guid.NewGuid(), GovernorateId = qenaId, NameAr = "قفط", NameEn = "Qift" },
            new City { Id = Guid.NewGuid(), GovernorateId = qenaId, NameAr = "نقادة", NameEn = "Naqada" },
            new City { Id = Guid.NewGuid(), GovernorateId = qenaId, NameAr = "فرشوط", NameEn = "Farshout" },
            new City { Id = Guid.NewGuid(), GovernorateId = qenaId, NameAr = "قوص", NameEn = "Qus" },
            
            // North Sinai
            new City { Id = Guid.NewGuid(), GovernorateId = northSinaiId, NameAr = "العريش", NameEn = "El Arish" },
            new City { Id = Guid.NewGuid(), GovernorateId = northSinaiId, NameAr = "الشيخ زويد", NameEn = "Sheikh Zuweid" },
            new City { Id = Guid.NewGuid(), GovernorateId = northSinaiId, NameAr = "نخل", NameEn = "Nakhl" },
            new City { Id = Guid.NewGuid(), GovernorateId = northSinaiId, NameAr = "رفح", NameEn = "Rafah" },
            new City { Id = Guid.NewGuid(), GovernorateId = northSinaiId, NameAr = "بئر العبد", NameEn = "Bir El Abd" },
            new City { Id = Guid.NewGuid(), GovernorateId = northSinaiId, NameAr = "الحسنة", NameEn = "El Hasana" },
            new City { Id = Guid.NewGuid(), GovernorateId = northSinaiId, NameAr = "الطور", NameEn = "El Tor" },
            
            // Sohag
            new City { Id = Guid.NewGuid(), GovernorateId = sohagId, NameAr = "سوهاج", NameEn = "Sohag" },
            new City { Id = Guid.NewGuid(), GovernorateId = sohagId, NameAr = "سوهاج الجديدة", NameEn = "New Sohag" },
            new City { Id = Guid.NewGuid(), GovernorateId = sohagId, NameAr = "أخميم", NameEn = "Akhmeem" },
            new City { Id = Guid.NewGuid(), GovernorateId = sohagId, NameAr = "أخميم الجديدة", NameEn = "New Akhmeem" },
            new City { Id = Guid.NewGuid(), GovernorateId = sohagId, NameAr = "البلينا", NameEn = "El Balina" },
            new City { Id = Guid.NewGuid(), GovernorateId = sohagId, NameAr = "المراغة", NameEn = "El Maragha" },
            new City { Id = Guid.NewGuid(), GovernorateId = sohagId, NameAr = "المنشأة", NameEn = "El Mansha" },
            new City { Id = Guid.NewGuid(), GovernorateId = sohagId, NameAr = "جرجا", NameEn = "Gerga" },
            new City { Id = Guid.NewGuid(), GovernorateId = sohagId, NameAr = "جهينة", NameEn = "Jahina" },
            new City { Id = Guid.NewGuid(), GovernorateId = sohagId, NameAr = "ساقلتة", NameEn = "Saqilta" },
            new City { Id = Guid.NewGuid(), GovernorateId = sohagId, NameAr = "طما", NameEn = "Tama" },
            new City { Id = Guid.NewGuid(), GovernorateId = sohagId, NameAr = "طهطا", NameEn = "Tahta" },
            new City { Id = Guid.NewGuid(), GovernorateId = sohagId, NameAr = "الكوثر", NameEn = "El Kawther" },
            
            // New Valley
            new City { Id = Guid.NewGuid(), GovernorateId = newValleyId, NameAr = "الخارجة", NameEn = "El Kharga" },
            new City { Id = Guid.NewGuid(), GovernorateId = newValleyId, NameAr = "الخارجة الجديدة", NameEn = "New El Kharga" },
            new City { Id = Guid.NewGuid(), GovernorateId = newValleyId, NameAr = "باريس", NameEn = "Paris" },
            new City { Id = Guid.NewGuid(), GovernorateId = newValleyId, NameAr = "الفرافرة", NameEn = "El Farafra" },
            new City { Id = Guid.NewGuid(), GovernorateId = newValleyId, NameAr = "بلاط", NameEn = "Balat" },
            new City { Id = Guid.NewGuid(), GovernorateId = newValleyId, NameAr = "الداخلة", NameEn = "El Dakhla" },
            new City { Id = Guid.NewGuid(), GovernorateId = newValleyId, NameAr = "موط", NameEn = "Mut" },
            new City { Id = Guid.NewGuid(), GovernorateId = newValleyId, NameAr = "الواحات البحرية", NameEn = "El Wahat El Bahariya" }
            );

            // Configure Notification entity
            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Message).IsRequired().HasMaxLength(1000);
                entity.Property(e => e.Type).IsRequired();
                entity.Property(e => e.Data).HasMaxLength(2000);
                
                // Foreign key relationships
                entity.HasOne(n => n.User)
                    .WithMany()
                    .HasForeignKey(n => n.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
                    
                entity.HasOne(n => n.Doctor)
                    .WithMany()
                    .HasForeignKey(n => n.DoctorId)
                    .OnDelete(DeleteBehavior.Restrict);
                    
                entity.HasOne(n => n.Patient)
                    .WithMany()
                    .HasForeignKey(n => n.PatientId)
                    .OnDelete(DeleteBehavior.Restrict);
                    
                entity.HasOne(n => n.Appointment)
                    .WithMany()
                    .HasForeignKey(n => n.AppointmentId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // إضافة البيانات الأولية من DataModules
            DataSeeder.SeedAllData(modelBuilder);

        }

        // Patient related tables
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }
        public DbSet<InsuranceInfo> InsuranceInfos { get; set; }
        public DbSet<MedicalRecord> MedicalRecords {  get; set; }
        
        // Location tables
        public DbSet<Governorate> Governorates { get; set; }
        public DbSet<City> Cities { get; set; }
        // Doctor related tables
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<DoctorSpecialization> DoctorSpecializations { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        // Receptionist table
        public DbSet<Receptionist> Receptionists { get; set; }
        // Report related tables
        public DbSet<Report> Reports { get; set; }
        public DbSet<FinancialReport> FinancialReports { get; set; }

        // Settings tables
        public DbSet<SystemSettings> SystemSettings { get; set; }
        public DbSet<ClinicSettings> ClinicSettings { get; set; }

        // Audit log table
        public DbSet<AuditLog> AuditLogs { get; set; }


        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalVisit> MedicalVisits { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionItem> PrescriptionItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}

