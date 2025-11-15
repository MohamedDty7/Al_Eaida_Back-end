using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using Microsoft.EntityFrameworkCore;
using AL_Eaida_Infrastructure__Layer.IRepositery;

namespace AL_Eaida_Infrastructure__Layer.Repositery.DoctorSpecializationRepositery
{
    public class DoctorSpecializationRepositery : GenaricRepositery<DoctorSpecialization>, IDoctorSpecializationRepository
    {
        public DoctorSpecializationRepositery(AppDBcontext context) : base(context)
        {
        }

        public async Task<IEnumerable<DoctorSpecialization>> GetSpecializationsByDoctorIdAsync(Guid doctorId)
        {
            return await _context.Set<DoctorSpecialization>()
                .Where(s => s.DoctorId == doctorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<DoctorSpecialization>> GetDoctorsBySpecializationIdAsync(Guid specializationId)
        {
            return await _context.Set<DoctorSpecialization>()
                .Where(s => s.SpecializationId == specializationId)
                .ToListAsync();
        }

        public async Task<bool> DoctorHasSpecializationAsync(Guid doctorId, Guid specializationId)
        {
            return await _context.Set<DoctorSpecialization>()
                .AnyAsync(s => s.DoctorId == doctorId && s.SpecializationId == specializationId);
        }
    }
}
