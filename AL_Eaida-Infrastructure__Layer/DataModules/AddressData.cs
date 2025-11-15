using Al_Eaida_Domin.Modules;
using Microsoft.EntityFrameworkCore;

namespace AL_Eaida_Infrastructure__Layer.DataModules
{
    public static class AddressData
    {
        public static void SeedAddresses(ModelBuilder modelBuilder)
        {
            // الحصول على معرفات المحافظات والمدن (يجب أن تكون موجودة مسبقاً)
            var cairoId = Guid.NewGuid();
            var gizaId = Guid.NewGuid();
            var alexandriaId = Guid.NewGuid();

            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    Id = Guid.NewGuid(),
                    Street = "شارع التحرير",
                    ZipCode = "11511",
                    Country = "مصر",
                    GovernorateId = cairoId,
                    CityId = Guid.NewGuid(), // معرف مدينة القاهرة
                    CreatedAt = DateTime.UtcNow
                },
                new Address
                {
                    Id = Guid.NewGuid(),
                    Street = "شارع الهرم",
                    ZipCode = "12511",
                    Country = "مصر",
                    GovernorateId = gizaId,
                    CityId = Guid.NewGuid(), // معرف مدينة الجيزة
                    CreatedAt = DateTime.UtcNow
                },
                new Address
                {
                    Id = Guid.NewGuid(),
                    Street = "شارع الكورنيش",
                    ZipCode = "21511",
                    Country = "مصر",
                    GovernorateId = alexandriaId,
                    CityId = Guid.NewGuid(), // معرف مدينة الإسكندرية
                    CreatedAt = DateTime.UtcNow
                },
                new Address
                {
                    Id = Guid.NewGuid(),
                    Street = "شارع النيل",
                    ZipCode = "11512",
                    Country = "مصر",
                    GovernorateId = cairoId,
                    CityId = Guid.NewGuid(), // معرف مدينة القاهرة
                    CreatedAt = DateTime.UtcNow
                },
                new Address
                {
                    Id = Guid.NewGuid(),
                    Street = "شارع المعادي",
                    ZipCode = "11513",
                    Country = "مصر",
                    GovernorateId = cairoId,
                    CityId = Guid.NewGuid(), // معرف مدينة المعادي
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}

