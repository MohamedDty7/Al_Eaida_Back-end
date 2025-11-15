using Al_Eaida_Domin.Modules;
using Microsoft.EntityFrameworkCore;

namespace AL_Eaida_Infrastructure__Layer.DataModules
{
    public static class SpecializationData
    {
        public static void SeedSpecializations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specialization>().HasData(
                new Specialization
                {
                    Id = Guid.NewGuid(),
                    Name = "طب القلب",
                    Description = "تخصص في أمراض القلب والأوعية الدموية",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Specialization
                {
                    Id = Guid.NewGuid(),
                    Name = "طب الأطفال",
                    Description = "تخصص في علاج الأطفال",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Specialization
                {
                    Id = Guid.NewGuid(),
                    Name = "طب النساء والولادة",
                    Description = "تخصص في صحة المرأة والحمل والولادة",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Specialization
                {
                    Id = Guid.NewGuid(),
                    Name = "طب العظام",
                    Description = "تخصص في علاج العظام والمفاصل",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Specialization
                {
                    Id = Guid.NewGuid(),
                    Name = "طب العيون",
                    Description = "تخصص في علاج أمراض العيون",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Specialization
                {
                    Id = Guid.NewGuid(),
                    Name = "طب الأنف والأذن والحنجرة",
                    Description = "تخصص في علاج أمراض الأنف والأذن والحنجرة",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Specialization
                {
                    Id = Guid.NewGuid(),
                    Name = "طب الجلدية",
                    Description = "تخصص في علاج أمراض الجلد",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Specialization
                {
                    Id = Guid.NewGuid(),
                    Name = "طب الأعصاب",
                    Description = "تخصص في علاج أمراض الجهاز العصبي",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Specialization
                {
                    Id = Guid.NewGuid(),
                    Name = "طب الجهاز الهضمي",
                    Description = "تخصص في علاج أمراض الجهاز الهضمي",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Specialization
                {
                    Id = Guid.NewGuid(),
                    Name = "طب المسالك البولية",
                    Description = "تخصص في علاج أمراض المسالك البولية",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}

