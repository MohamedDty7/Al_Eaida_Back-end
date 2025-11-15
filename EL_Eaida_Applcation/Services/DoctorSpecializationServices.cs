using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.DoctorSpecializationDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace EL_Eaida_Applcation.Services
{
    public class DoctorSpecializationServices : IDoctorSpecializationServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DoctorSpecializationServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DoctorSpecializationDTO> CreateSpecializationAsync(CreateDoctorSpecializationDTO createDto)
        {
            var specialization = _mapper.Map<DoctorSpecialization>(createDto);
            specialization.Id = Guid.NewGuid();
            specialization.CreatedAt = DateTime.UtcNow;
            
            await _unitOfWork.Repository<DoctorSpecialization>().AddAsync(specialization);
            await _unitOfWork.CompleteAsync();
            
            return _mapper.Map<DoctorSpecializationDTO>(specialization);
        }

        public async Task<DoctorSpecializationDTO?> GetSpecializationByIdAsync(Guid id)
        {
            var specialization = await _unitOfWork.Repository<DoctorSpecialization>().GetByIdAsync(id);
            return specialization != null ? _mapper.Map<DoctorSpecializationDTO>(specialization) : null;
        }

        public async Task<IEnumerable<DoctorSpecializationDTO>> GetAllSpecializationsAsync()
        {
            var specializations = await _unitOfWork.Repository<DoctorSpecialization>().GetAllAsync(1, int.MaxValue);
            return _mapper.Map<IEnumerable<DoctorSpecializationDTO>>(specializations);
        }

        public async Task<IEnumerable<DoctorSpecializationDTO>> GetSpecializationsByDoctorIdAsync(Guid doctorId)
        {
            var specializations = await _unitOfWork.DoctorSpecializationRepository.GetSpecializationsByDoctorIdAsync(doctorId);
            return _mapper.Map<IEnumerable<DoctorSpecializationDTO>>(specializations);
        }

        public async Task<IEnumerable<DoctorSpecializationDTO>> GetDoctorsBySpecializationIdAsync(Guid specializationId)
        {
            var specializations = await _unitOfWork.DoctorSpecializationRepository.GetDoctorsBySpecializationIdAsync(specializationId);
            return _mapper.Map<IEnumerable<DoctorSpecializationDTO>>(specializations);
        }

        public async Task<bool> DeleteSpecializationAsync(Guid id)
        {
            var specialization = await _unitOfWork.Repository<DoctorSpecialization>().GetByIdAsync(id);
            if (specialization == null)
                return false;

            await _unitOfWork.Repository<DoctorSpecialization>().Delete(specialization);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
