using Al_Eaida_Domin.Modules;
using Microsoft.EntityFrameworkCore;

namespace AL_Eaida_Infrastructure__Layer.DataModules
{
    public static class InsuranceInfoData
    {
        public static void SeedInsuranceInfos(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InsuranceInfo>().HasData(
                new InsuranceInfo
                {
                    Id = Guid.NewGuid(),
                    Provider = "شركة التأمين الصحي",
                    PolicyNumber = "POL-001-2024",
                    GroupNumber = "GRP-001",
                    ValidUntil = DateTime.UtcNow.AddMonths(6),
                    CreatedAt = DateTime.UtcNow
                },
                new InsuranceInfo
                {
                    Id = Guid.NewGuid(),
                    Provider = "شركة التأمين الوطني",
                    PolicyNumber = "POL-002-2024",
                    GroupNumber = "GRP-002",
                    ValidUntil = DateTime.UtcNow.AddMonths(8),
                    CreatedAt = DateTime.UtcNow
                },
                new InsuranceInfo
                {
                    Id = Guid.NewGuid(),
                    Provider = "شركة التأمين الشامل",
                    PolicyNumber = "POL-003-2024",
                    GroupNumber = "GRP-003",
                    ValidUntil = DateTime.UtcNow.AddMonths(12),
                    CreatedAt = DateTime.UtcNow
                },
                new InsuranceInfo
                {
                    Id = Guid.NewGuid(),
                    Provider = "شركة التأمين الطبي",
                    PolicyNumber = "POL-004-2024",
                    GroupNumber = "GRP-004",
                    ValidUntil = DateTime.UtcNow.AddMonths(10),
                    CreatedAt = DateTime.UtcNow
                },
                new InsuranceInfo
                {
                    Id = Guid.NewGuid(),
                    Provider = "شركة التأمين المتقدم",
                    PolicyNumber = "POL-005-2024",
                    GroupNumber = "GRP-005",
                    ValidUntil = DateTime.UtcNow.AddMonths(4),
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}

