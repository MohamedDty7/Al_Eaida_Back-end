using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.EmergencyContactDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace EL_Eaida_Applcation.Services
{
    public class EmergencyContactServices : IEmergencyContactServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmergencyContactServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EmergencyContactDTO> CreateEmergencyContactAsync(CreateEmergencyContactDTO createEmergencyContactDTO)
        {
            var emergencyContact = _mapper.Map<EmergencyContact>(createEmergencyContactDTO);
            emergencyContact.Id = Guid.NewGuid();
            emergencyContact.CreatedAt = DateTime.UtcNow;
            
            await _unitOfWork.Repository<EmergencyContact>().AddAsync(emergencyContact);
            await _unitOfWork.CompleteAsync();
            
            return _mapper.Map<EmergencyContactDTO>(emergencyContact);
        }

        public async Task<EmergencyContactDTO?> GetEmergencyContactByIdAsync(Guid id)
        {
            var emergencyContact = await _unitOfWork.Repository<EmergencyContact>().GetByIdAsync(id);
            return emergencyContact != null ? _mapper.Map<EmergencyContactDTO>(emergencyContact) : null;
        }

        public async Task<IEnumerable<EmergencyContactDTO>> GetAllEmergencyContactsAsync()
        {
            var emergencyContacts = await _unitOfWork.Repository<EmergencyContact>().GetAllAsync(1, int.MaxValue);
            return _mapper.Map<IEnumerable<EmergencyContactDTO>>(emergencyContacts);
        }

        public async Task<EmergencyContactDTO?> UpdateEmergencyContactAsync(UpdateEmergencyContactDTO updateEmergencyContactDTO)
        {
            var emergencyContact = await _unitOfWork.Repository<EmergencyContact>().GetByIdAsync(updateEmergencyContactDTO.Id);
            if (emergencyContact == null)
                return null;

            if (!string.IsNullOrWhiteSpace(updateEmergencyContactDTO.Name))
                emergencyContact.Name = updateEmergencyContactDTO.Name;
            if (!string.IsNullOrWhiteSpace(updateEmergencyContactDTO.Relationship))
                emergencyContact.Relationship = updateEmergencyContactDTO.Relationship;
            if (!string.IsNullOrWhiteSpace(updateEmergencyContactDTO.Phone))
                emergencyContact.Phone = updateEmergencyContactDTO.Phone;
            if (!string.IsNullOrWhiteSpace(updateEmergencyContactDTO.Email))
                emergencyContact.Email = updateEmergencyContactDTO.Email;

            await _unitOfWork.Repository<EmergencyContact>().Update(emergencyContact);
            await _unitOfWork.CompleteAsync();
            
            return _mapper.Map<EmergencyContactDTO>(emergencyContact);
        }

        public async Task<bool> DeleteEmergencyContactAsync(Guid id)
        {
            var emergencyContact = await _unitOfWork.Repository<EmergencyContact>().GetByIdAsync(id);
            if (emergencyContact == null)
                return false;

            await _unitOfWork.Repository<EmergencyContact>().Delete(emergencyContact);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
























