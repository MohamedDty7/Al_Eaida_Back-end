using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.SystemSettingsDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace EL_Eaida_Applcation.Services
{
    public class SystemSettingsServices : ISystemSettingsServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SystemSettingsServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SystemSettingsDTO> CreateSettingAsync(CreateSystemSettingsDTO createDto)
        {
            var setting = _mapper.Map<SystemSettings>(createDto);
            setting.Id = Guid.NewGuid();
            setting.CreatedAt = DateTime.UtcNow;
            setting.UpdatedAt = DateTime.UtcNow;
            
            await _unitOfWork.Repository<SystemSettings>().AddAsync(setting);
            await _unitOfWork.CompleteAsync();
            
            return _mapper.Map<SystemSettingsDTO>(setting);
        }

        public async Task<SystemSettingsDTO?> GetSettingByIdAsync(Guid id)
        {
            var setting = await _unitOfWork.Repository<SystemSettings>().GetByIdAsync(id);
            return setting != null ? _mapper.Map<SystemSettingsDTO>(setting) : null;
        }

        public async Task<SystemSettingsDTO?> GetSettingByKeyAsync(string key)
        {
            var setting = await _unitOfWork.SystemSettingsRepository.GetByKeyAsync(key);
            return setting != null ? _mapper.Map<SystemSettingsDTO>(setting) : null;
        }

        public async Task<IEnumerable<SystemSettingsDTO>> GetAllSettingsAsync()
        {
            var settings = await _unitOfWork.Repository<SystemSettings>().GetAllAsync(1, int.MaxValue);
            return _mapper.Map<IEnumerable<SystemSettingsDTO>>(settings);
        }

        public async Task<IEnumerable<SystemSettingsDTO>> GetSettingsByTypeAsync(SettingType type)
        {
            var settings = await _unitOfWork.SystemSettingsRepository.GetByTypeAsync(type);
            return _mapper.Map<IEnumerable<SystemSettingsDTO>>(settings);
        }

        public async Task<SystemSettingsDTO?> UpdateSettingAsync(UpdateSystemSettingsDTO updateDto)
        {
            var setting = await _unitOfWork.Repository<SystemSettings>().GetByIdAsync(updateDto.Id);
            if (setting == null)
                return null;

            if (!string.IsNullOrWhiteSpace(updateDto.Key))
                setting.Key = updateDto.Key;
            if (!string.IsNullOrWhiteSpace(updateDto.Value))
                setting.Value = updateDto.Value;
            if (!string.IsNullOrWhiteSpace(updateDto.Description))
                setting.Description = updateDto.Description;
            if (updateDto.Type.HasValue)
                setting.Type = updateDto.Type.Value;
            if (updateDto.IsActive.HasValue)
                setting.IsActive = updateDto.IsActive.Value;

            setting.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.Repository<SystemSettings>().Update(setting);
            await _unitOfWork.CompleteAsync();
            
            return _mapper.Map<SystemSettingsDTO>(setting);
        }

        public async Task<bool> DeleteSettingAsync(Guid id)
        {
            var setting = await _unitOfWork.Repository<SystemSettings>().GetByIdAsync(id);
            if (setting == null)
                return false;

            await _unitOfWork.Repository<SystemSettings>().Delete(setting);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
