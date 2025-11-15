using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.AuditLogDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace EL_Eaida_Applcation.Services
{
    public class AuditLogServices : IAuditLogServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuditLogServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AuditLogDTO> CreateLogAsync(CreateAuditLogDTO createDto)
        {
            var log = _mapper.Map<AuditLog>(createDto);
            log.Id = Guid.NewGuid();
            log.Timestamp = DateTime.UtcNow;
            
            await _unitOfWork.Repository<AuditLog>().AddAsync(log);
            await _unitOfWork.CompleteAsync();
            
            return _mapper.Map<AuditLogDTO>(log);
        }

        public async Task<AuditLogDTO?> GetLogByIdAsync(Guid id)
        {
            var log = await _unitOfWork.Repository<AuditLog>().GetByIdAsync(id);
            return log != null ? _mapper.Map<AuditLogDTO>(log) : null;
        }

        public async Task<IEnumerable<AuditLogDTO>> GetAllLogsAsync()
        {
            var logs = await _unitOfWork.Repository<AuditLog>().GetAllAsync(1, int.MaxValue);
            return _mapper.Map<IEnumerable<AuditLogDTO>>(logs);
        }

        public async Task<IEnumerable<AuditLogDTO>> GetLogsByTableAsync(string tableName)
        {
            var logs = await _unitOfWork.AuditLogRepository.GetLogsByTableAsync(tableName);
            return _mapper.Map<IEnumerable<AuditLogDTO>>(logs);
        }

        public async Task<IEnumerable<AuditLogDTO>> GetLogsByUserAsync(string userId)
        {
            var logs = await _unitOfWork.AuditLogRepository.GetLogsByUserAsync(userId);
            return _mapper.Map<IEnumerable<AuditLogDTO>>(logs);
        }

        public async Task<IEnumerable<AuditLogDTO>> GetLogsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var logs = await _unitOfWork.AuditLogRepository.GetLogsByDateRangeAsync(startDate, endDate);
            return _mapper.Map<IEnumerable<AuditLogDTO>>(logs);
        }

        public async Task<IEnumerable<AuditLogDTO>> GetLogsByActionAsync(string action)
        {
            var logs = await _unitOfWork.AuditLogRepository.GetLogsByActionAsync(action);
            return _mapper.Map<IEnumerable<AuditLogDTO>>(logs);
        }
    }
}
