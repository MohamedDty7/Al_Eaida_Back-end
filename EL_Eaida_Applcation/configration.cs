
using System.Reflection;
using EL_Eaida_Applcation.InterFaceServices;
using EL_Eaida_Applcation.InterFaceServices.IAppointmentServices;
using EL_Eaida_Applcation.InterFaceServices.IAutherServices;
using EL_Eaida_Applcation.InterFaceServices.IMedicalvisitServices;
using EL_Eaida_Applcation.InterFaceServices.IPatientServices;
using EL_Eaida_Applcation.InterFaceServices.IPresciptionitemServices;
using EL_Eaida_Applcation.InterFaceServices.IPrescriptionServices;
using EL_Eaida_Applcation.InterFaceServices.IRoleServices;
using EL_Eaida_Applcation.Services;
using EL_Eaida_Applcation.Services.PatientServices;
using EL_Eaida_Applcation.Services.LocationServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EL_Eaida_Applcation
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAppointmentService,AppointmentServices>();
            services.AddScoped<IPrescriptionServices, PrescriptionServices>();
            services.AddScoped<IMedicineServices, MedicineServices>();
            services.AddScoped<IPresciptionitemServices, PrescritionitemServices>();
            services.AddScoped<IMedicalVisitServices, MedicalVisitServices>();
            services.AddScoped<IPatientService, PatientServices>();
            services.AddScoped<IinvoiceServices, invoiceServices>();
            services.AddScoped<IinvoiceitemServices, InvoiceitemServices>();
            services.AddScoped<ISpecializationServices, SpecializationServices>();
            services.AddScoped<IDoctorServices, DoctorServices>();
            
            // Additional Services
            services.AddScoped<ISystemSettingsServices, SystemSettingsServices>();
            services.AddScoped<IAddressServices, AddressServices>();
            services.AddScoped<IMedicalRecordServices, MedicalRecordServices>();
            services.AddScoped<IInsuranceInfoServices, InsuranceInfoServices>();
            services.AddScoped<IEmergencyContactServices, EmergencyContactServices>();
            services.AddScoped<IAuditLogServices, AuditLogServices>();
            services.AddScoped<IFinancialReportServices, FinancialReportServices>();
            services.AddScoped<IClinicSettingsServices, ClinicSettingsServices>();
            services.AddScoped<IReceptionistServices, ReceptionistServices>();
            services.AddScoped<IMedicationCategoryServices, MedicationCategoryServices>();
            services.AddScoped<IDoctorSpecializationServices, DoctorSpecializationServices>();
            services.AddScoped<IDoctorScheduleServices, DoctorScheduleServices>();
            services.AddScoped<IReportServices, ReportServices>();
            services.AddScoped<ILocationService, LocationService>();
            
            // Register AutoMapper (search all mappings in this assembly)
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
