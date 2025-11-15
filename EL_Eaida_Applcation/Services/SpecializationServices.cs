using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.SpecializationDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace EL_Eaida_Applcation.Services
{
    public class SpecializationServices : ISpecializationServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SpecializationServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SpecializationDTO> CreateSpecializationAsync(CreateSpecializationDTO createSpecializationDTO)
        {
            var specialization = _mapper.Map<Specialization>(createSpecializationDTO);
            specialization.Id = Guid.NewGuid();
            specialization.CreatedAt = DateTime.UtcNow;
            
            await _unitOfWork.Repository<Specialization>().AddAsync(specialization);
            await _unitOfWork.CompleteAsync();
            
            return _mapper.Map<SpecializationDTO>(specialization);
        }

        public async Task<SpecializationDTO?> GetSpecializationByIdAsync(string id)
        {
            var specialization = await _unitOfWork.Repository<Specialization>().GetByIdAsync(id);
            return specialization != null ? _mapper.Map<SpecializationDTO>(specialization) : null;
        }

        public async Task<IEnumerable<SpecializationDTO>> GetAllSpecializationsAsync()
        {
            var specializations = await _unitOfWork.Repository<Specialization>().GetAllAsync(1, int.MaxValue);
            return _mapper.Map<IEnumerable<SpecializationDTO>>(specializations);
        }

        public async Task<SpecializationDTO?> UpdateSpecializationAsync(UpdateSpecializationDTO updateSpecializationDTO)
        {
            var specialization = await _unitOfWork.Repository<Specialization>().GetByIdAsync(updateSpecializationDTO.Id);
            if (specialization == null)
                return null;

            if (!string.IsNullOrWhiteSpace(updateSpecializationDTO.Name))
                specialization.Name = updateSpecializationDTO.Name;
            if (!string.IsNullOrWhiteSpace(updateSpecializationDTO.Description))
                specialization.Description = updateSpecializationDTO.Description;
            if (updateSpecializationDTO.IsActive.HasValue)
                specialization.IsActive = updateSpecializationDTO.IsActive.Value;

            await _unitOfWork.Repository<Specialization>().Update(specialization);
            await _unitOfWork.CompleteAsync();
            
            return _mapper.Map<SpecializationDTO>(specialization);
        }

        public async Task<bool> DeleteSpecializationAsync(string id)
        {
            var specialization = await _unitOfWork.Repository<Specialization>().GetByIdAsync(id);
            if (specialization == null)
                return false;

            await _unitOfWork.Repository<Specialization>().Delete(specialization);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
