using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.ClinicSettingsDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace EL_Eaida_Applcation.Services
{
    public class ClinicSettingsServices : IClinicSettingsServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClinicSettingsServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ClinicSettingsDTO> CreateSettingsAsync(CreateClinicSettingsDTO createDto)
        {
            var settings = _mapper.Map<ClinicSettings>(createDto);
            settings.Id = Guid.NewGuid();
            settings.CreatedAt = DateTime.UtcNow;
            settings.UpdatedAt = DateTime.UtcNow;
            
            await _unitOfWork.Repository<ClinicSettings>().AddAsync(settings);
            await _unitOfWork.CompleteAsync();
            
            return _mapper.Map<ClinicSettingsDTO>(settings);
        }

        public async Task<ClinicSettingsDTO?> GetSettingsByIdAsync(Guid id)
        {
            var settings = await _unitOfWork.Repository<ClinicSettings>().GetByIdAsync(id);
            return settings != null ? _mapper.Map<ClinicSettingsDTO>(settings) : null;
        }

        public async Task<ClinicSettingsDTO?> GetActiveSettingsAsync()
        {
            var activeSettings = await _unitOfWork.ClinicSettingsRepository.GetActiveSettingsAsync();
            return activeSettings != null ? _mapper.Map<ClinicSettingsDTO>(activeSettings) : null;
        }

        public async Task<ClinicSettingsDTO?> UpdateSettingsAsync(UpdateClinicSettingsDTO updateDto)
        {
            var settings = await _unitOfWork.Repository<ClinicSettings>().GetByIdAsync(updateDto.Id);
            if (settings == null)
                return null;

            if (!string.IsNullOrWhiteSpace(updateDto.ClinicName))
                settings.ClinicName = updateDto.ClinicName;
            if (!string.IsNullOrWhiteSpace(updateDto.Address))
                settings.Address = updateDto.Address;
            if (!string.IsNullOrWhiteSpace(updateDto.Phone))
                settings.Phone = updateDto.Phone;
            if (!string.IsNullOrWhiteSpace(updateDto.Email))
                settings.Email = updateDto.Email;
            if (!string.IsNullOrWhiteSpace(updateDto.Website))
                settings.Website = updateDto.Website;
            if (!string.IsNullOrWhiteSpace(updateDto.LicenseNumber))
                settings.LicenseNumber = updateDto.LicenseNumber;
            if (!string.IsNullOrWhiteSpace(updateDto.LogoPath))
                settings.LogoPath = updateDto.LogoPath;
            if (updateDto.WorkingHoursStart.HasValue)
                settings.WorkingHoursStart = updateDto.WorkingHoursStart;
            if (updateDto.WorkingHoursEnd.HasValue)
                settings.WorkingHoursEnd = updateDto.WorkingHoursEnd;
            if (updateDto.DefaultAppointmentDuration.HasValue)
                settings.DefaultAppointmentDuration = updateDto.DefaultAppointmentDuration;
            if (updateDto.MaxAppointmentsPerDay.HasValue)
                settings.MaxAppointmentsPerDay = updateDto.MaxAppointmentsPerDay;
            if (updateDto.AllowOnlineBooking.HasValue)
                settings.AllowOnlineBooking = updateDto.AllowOnlineBooking.Value;
            if (updateDto.RequireAppointmentConfirmation.HasValue)
                settings.RequireAppointmentConfirmation = updateDto.RequireAppointmentConfirmation.Value;

            settings.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.Repository<ClinicSettings>().Update(settings);
            await _unitOfWork.CompleteAsync();
            
            return _mapper.Map<ClinicSettingsDTO>(settings);
        }

        public async Task<bool> DeleteSettingsAsync(Guid id)
        {
            var settings = await _unitOfWork.Repository<ClinicSettings>().GetByIdAsync(id);
            if (settings == null)
                return false;

            await _unitOfWork.Repository<ClinicSettings>().Delete(settings);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
