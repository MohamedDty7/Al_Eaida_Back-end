using Microsoft.EntityFrameworkCore;

namespace AL_Eaida_Infrastructure__Layer.DataModules
{
    public static class DataSeeder
    {
        public static void SeedAllData(ModelBuilder modelBuilder)
        {
            // ترتيب إضافة البيانات حسب التبعيات
            
            // المستخدمين والأدوار أولاً
            UserData.SeedUsers(modelBuilder);
            
            // البيانات الأساسية
            SpecializationData.SeedSpecializations(modelBuilder);
            SystemSettingsData.SeedSystemSettings(modelBuilder);
            ClinicSettingsData.SeedClinicSettings(modelBuilder);
            MedicineData.SeedMedicines(modelBuilder);
            
            // بيانات الأطباء والمرضى
            DoctorData.SeedDoctors(modelBuilder);
            PatientData.SeedPatients(modelBuilder);
            
            // بيانات الجهات الطارئة والتأمين
            EmergencyContactData.SeedEmergencyContacts(modelBuilder);
            InsuranceInfoData.SeedInsuranceInfos(modelBuilder);
            
        }
    }
}

