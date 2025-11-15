using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.ReceptionistDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace EL_Eaida_Applcation.Services
{
    public class ReceptionistServices : IReceptionistServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReceptionistServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ReceptionistDTO> CreateReceptionistAsync(CreateReceptionistDTO createDto)
        {
            var receptionist = _mapper.Map<Receptionist>(createDto);
            receptionist.Id = Guid.NewGuid();
            receptionist.CreatedAt = DateTime.UtcNow;
            receptionist.UpdatedAt = DateTime.UtcNow;
            
            await _unitOfWork.Repository<Receptionist>().AddAsync(receptionist);
            await _unitOfWork.CompleteAsync();
            
            return _mapper.Map<ReceptionistDTO>(receptionist);
        }

        public async Task<ReceptionistDTO?> GetReceptionistByIdAsync(Guid id)
        {
            var receptionist = await _unitOfWork.Repository<Receptionist>().GetByIdAsync(id);
            return receptionist != null ? _mapper.Map<ReceptionistDTO>(receptionist) : null;
        }

        public async Task<ReceptionistDTO?> GetReceptionistByUserIdAsync(string userId)
        {
            var receptionist = await _unitOfWork.ReceptionistRepository.GetByUserIdAsync(userId);
            return receptionist != null ? _mapper.Map<ReceptionistDTO>(receptionist) : null;
        }

        public async Task<IEnumerable<ReceptionistDTO>> GetAllReceptionistsAsync()
        {
            var receptionists = await _unitOfWork.Repository<Receptionist>().GetAllAsync(1, int.MaxValue);
            return _mapper.Map<IEnumerable<ReceptionistDTO>>(receptionists);
        }

        public async Task<IEnumerable<ReceptionistDTO>> GetReceptionistsByDepartmentAsync(string department)
        {
            var receptionists = await _unitOfWork.ReceptionistRepository.GetByDepartmentAsync(department);
            return _mapper.Map<IEnumerable<ReceptionistDTO>>(receptionists);
        }

        public async Task<ReceptionistDTO?> UpdateReceptionistAsync(UpdateReceptionistDTO updateDto)
        {
            var receptionist = await _unitOfWork.Repository<Receptionist>().GetByIdAsync(updateDto.Id);
            if (receptionist == null)
                return null;

            if (!string.IsNullOrWhiteSpace(updateDto.FirstName))
                receptionist.FirstName = updateDto.FirstName;
            if (!string.IsNullOrWhiteSpace(updateDto.LastName))
                receptionist.LastName = updateDto.LastName;
            if (!string.IsNullOrWhiteSpace(updateDto.Email))
                receptionist.Email = updateDto.Email;
            if (!string.IsNullOrWhiteSpace(updateDto.Phone))
                receptionist.Phone = updateDto.Phone;
            if (!string.IsNullOrWhiteSpace(updateDto.Department))
                receptionist.Department = updateDto.Department;
            if (!string.IsNullOrWhiteSpace(updateDto.EmployeeId))
                receptionist.EmployeeId = updateDto.EmployeeId;
            if (updateDto.HireDate.HasValue)
                receptionist.HireDate = updateDto.HireDate;
            if (!string.IsNullOrWhiteSpace(updateDto.ProfileImage))
                receptionist.ProfileImage = updateDto.ProfileImage;
            if (updateDto.IsActive.HasValue)
                receptionist.IsActive = updateDto.IsActive.Value;

            receptionist.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.Repository<Receptionist>().Update(receptionist);
            await _unitOfWork.CompleteAsync();
            
            return _mapper.Map<ReceptionistDTO>(receptionist);
        }

        public async Task<bool> DeleteReceptionistAsync(Guid id)
        {
            var receptionist = await _unitOfWork.Repository<Receptionist>().GetByIdAsync(id);
            if (receptionist == null)
                return false;

            await _unitOfWork.Repository<Receptionist>().Delete(receptionist);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
