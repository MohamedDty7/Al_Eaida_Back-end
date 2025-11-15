using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.DoctorScheduleDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace EL_Eaida_Applcation.Services
{
    public class DoctorScheduleServices : IDoctorScheduleServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DoctorScheduleServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DoctorScheduleDTO> CreateScheduleAsync(CreateDoctorScheduleDTO createDto)
        {
            var schedule = _mapper.Map<DoctorSchedule>(createDto);
            schedule.Id = Guid.NewGuid();
            schedule.CreatedAt = DateTime.UtcNow;
            
            await _unitOfWork.Repository<DoctorSchedule>().AddAsync(schedule);
            await _unitOfWork.CompleteAsync();
            
            return _mapper.Map<DoctorScheduleDTO>(schedule);
        }

        public async Task<DoctorScheduleDTO?> GetScheduleByIdAsync(Guid id)
        {
            var schedule = await _unitOfWork.Repository<DoctorSchedule>().GetByIdAsync(id);
            return schedule != null ? _mapper.Map<DoctorScheduleDTO>(schedule) : null;
        }

        public async Task<IEnumerable<DoctorScheduleDTO>> GetAllSchedulesAsync()
        {
            var schedules = await _unitOfWork.Repository<DoctorSchedule>().GetAllAsync(1, int.MaxValue);
            return _mapper.Map<IEnumerable<DoctorScheduleDTO>>(schedules);
        }

        public async Task<IEnumerable<DoctorScheduleDTO>> GetSchedulesByDoctorIdAsync(Guid doctorId)
        {
            var schedules = await _unitOfWork.DoctorScheduleRepository.GetSchedulesByDoctorIdAsync(doctorId);
            return _mapper.Map<IEnumerable<DoctorScheduleDTO>>(schedules);
        }

        public async Task<IEnumerable<DoctorScheduleDTO>> GetSchedulesByDayAsync(DayOfWeek dayOfWeek)
        {
            var schedules = await _unitOfWork.DoctorScheduleRepository.GetSchedulesByDayAsync(dayOfWeek);
            return _mapper.Map<IEnumerable<DoctorScheduleDTO>>(schedules);
        }

        public async Task<DoctorScheduleDTO?> UpdateScheduleAsync(UpdateDoctorScheduleDTO updateDto)
        {
            var schedule = await _unitOfWork.Repository<DoctorSchedule>().GetByIdAsync(updateDto.Id);
            if (schedule == null)
                return null;

            if (updateDto.DoctorId.HasValue)
                schedule.DoctorId = updateDto.DoctorId.Value;
            if (updateDto.DayOfWeek.HasValue)
                schedule.DayOfWeek = updateDto.DayOfWeek.Value;
            if (updateDto.StartTime.HasValue)
                schedule.StartTime = updateDto.StartTime.Value;
            if (updateDto.EndTime.HasValue)
                schedule.EndTime = updateDto.EndTime.Value;
            if (updateDto.IsActive.HasValue)
                schedule.IsActive = updateDto.IsActive.Value;

            await _unitOfWork.Repository<DoctorSchedule>().Update(schedule);
            await _unitOfWork.CompleteAsync();
            
            return _mapper.Map<DoctorScheduleDTO>(schedule);
        }

        public async Task<bool> DeleteScheduleAsync(Guid id)
        {
            var schedule = await _unitOfWork.Repository<DoctorSchedule>().GetByIdAsync(id);
            if (schedule == null)
                return false;

            await _unitOfWork.Repository<DoctorSchedule>().Delete(schedule);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
