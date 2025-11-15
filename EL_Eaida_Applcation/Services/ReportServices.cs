using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.ReportDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace EL_Eaida_Applcation.Services
{
    public class ReportServices : IReportServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReportServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ReportDTO> CreateReportAsync(CreateReportDTO createDto)
        {
            var report = _mapper.Map<Report>(createDto);
            report.Id = Guid.NewGuid();
            report.GeneratedAt = DateTime.UtcNow;
            
            await _unitOfWork.Repository<Report>().AddAsync(report);
            await _unitOfWork.CompleteAsync();
            
            return _mapper.Map<ReportDTO>(report);
        }

        public async Task<ReportDTO?> GetReportByIdAsync(Guid id)
        {
            var report = await _unitOfWork.Repository<Report>().GetByIdAsync(id);
            return report != null ? _mapper.Map<ReportDTO>(report) : null;
        }

        public async Task<IEnumerable<ReportDTO>> GetAllReportsAsync()
        {
            var reports = await _unitOfWork.Repository<Report>().GetAllAsync(1, int.MaxValue);
            return _mapper.Map<IEnumerable<ReportDTO>>(reports);
        }

        public async Task<IEnumerable<ReportDTO>> GetReportsByTypeAsync(ReportType type)
        {
            var reports = await _unitOfWork.ReportRepository.GetReportsByTypeAsync(type);
            return _mapper.Map<IEnumerable<ReportDTO>>(reports);
        }

        public async Task<IEnumerable<ReportDTO>> GetReportsByUserAsync(string userId)
        {
            var reports = await _unitOfWork.ReportRepository.GetReportsByUserAsync(userId);
            return _mapper.Map<IEnumerable<ReportDTO>>(reports);
        }

        public async Task<IEnumerable<ReportDTO>> GetReportsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var reports = await _unitOfWork.ReportRepository.GetReportsByDateRangeAsync(startDate, endDate);
            return _mapper.Map<IEnumerable<ReportDTO>>(reports);
        }

        public async Task<ReportDTO?> UpdateReportAsync(UpdateReportDTO updateDto)
        {
            var report = await _unitOfWork.Repository<Report>().GetByIdAsync(updateDto.Id);
            if (report == null)
                return null;

            if (!string.IsNullOrWhiteSpace(updateDto.Title))
                report.Title = updateDto.Title;
            if (updateDto.Type.HasValue)
                report.Type = updateDto.Type.Value;
            if (!string.IsNullOrWhiteSpace(updateDto.Description))
                report.Description = updateDto.Description;
            if (updateDto.StartDate.HasValue)
                report.StartDate = updateDto.StartDate;
            if (updateDto.EndDate.HasValue)
                report.EndDate = updateDto.EndDate;
            if (!string.IsNullOrWhiteSpace(updateDto.FilePath))
                report.FilePath = updateDto.FilePath;
            if (!string.IsNullOrWhiteSpace(updateDto.Data))
                report.Data = updateDto.Data;
            if (updateDto.IsActive.HasValue)
                report.IsActive = updateDto.IsActive.Value;

            await _unitOfWork.Repository<Report>().Update(report);
            await _unitOfWork.CompleteAsync();
            
            return _mapper.Map<ReportDTO>(report);
        }

        public async Task<bool> DeleteReportAsync(Guid id)
        {
            var report = await _unitOfWork.Repository<Report>().GetByIdAsync(id);
            if (report == null)
                return false;

            await _unitOfWork.Repository<Report>().Delete(report);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
