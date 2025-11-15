using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.FinancialReportDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace EL_Eaida_Applcation.Services
{
    public class FinancialReportServices : IFinancialReportServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FinancialReportServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<FinancialReportDTO> CreateReportAsync(CreateFinancialReportDTO createDto)
        {
            var report = _mapper.Map<FinancialReport>(createDto);
            report.Id = Guid.NewGuid();
            report.CreatedAt = DateTime.UtcNow;
            
            await _unitOfWork.Repository<FinancialReport>().AddAsync(report);
            await _unitOfWork.CompleteAsync();
            
            return _mapper.Map<FinancialReportDTO>(report);
        }

        public async Task<FinancialReportDTO?> GetReportByIdAsync(Guid id)
        {
            var report = await _unitOfWork.Repository<FinancialReport>().GetByIdAsync(id);
            return report != null ? _mapper.Map<FinancialReportDTO>(report) : null;
        }

        public async Task<IEnumerable<FinancialReportDTO>> GetAllReportsAsync()
        {
            var reports = await _unitOfWork.Repository<FinancialReport>().GetAllAsync(1, int.MaxValue);
            return _mapper.Map<IEnumerable<FinancialReportDTO>>(reports);
        }

        public async Task<IEnumerable<FinancialReportDTO>> GetReportsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var reports = await _unitOfWork.FinancialReportRepository.GetReportsByDateRangeAsync(startDate, endDate);
            return _mapper.Map<IEnumerable<FinancialReportDTO>>(reports);
        }

        public async Task<FinancialReportDTO?> GetLatestReportAsync()
        {
            var latestReport = await _unitOfWork.FinancialReportRepository.GetLatestReportAsync();
            return latestReport != null ? _mapper.Map<FinancialReportDTO>(latestReport) : null;
        }

        public async Task<IEnumerable<FinancialReportDTO>> GetReportsByYearAsync(int year)
        {
            var reports = await _unitOfWork.FinancialReportRepository.GetReportsByYearAsync(year);
            return _mapper.Map<IEnumerable<FinancialReportDTO>>(reports);
        }

        public async Task<FinancialReportDTO?> UpdateReportAsync(UpdateFinancialReportDTO updateDto)
        {
            var report = await _unitOfWork.Repository<FinancialReport>().GetByIdAsync(updateDto.Id);
            if (report == null)
                return null;

            if (updateDto.ReportDate.HasValue)
                report.ReportDate = updateDto.ReportDate.Value;
            if (updateDto.TotalRevenue.HasValue)
                report.TotalRevenue = updateDto.TotalRevenue.Value;
            if (updateDto.ConsultationFees.HasValue)
                report.ConsultationFees = updateDto.ConsultationFees;
            if (updateDto.MedicationSales.HasValue)
                report.MedicationSales = updateDto.MedicationSales;
            if (updateDto.OtherServices.HasValue)
                report.OtherServices = updateDto.OtherServices;
            if (updateDto.TotalExpenses.HasValue)
                report.TotalExpenses = updateDto.TotalExpenses;
            if (updateDto.NetProfit.HasValue)
                report.NetProfit = updateDto.NetProfit;
            if (updateDto.TotalAppointments.HasValue)
                report.TotalAppointments = updateDto.TotalAppointments;
            if (updateDto.CompletedAppointments.HasValue)
                report.CompletedAppointments = updateDto.CompletedAppointments;
            if (updateDto.CancelledAppointments.HasValue)
                report.CancelledAppointments = updateDto.CancelledAppointments;

            await _unitOfWork.Repository<FinancialReport>().Update(report);
            await _unitOfWork.CompleteAsync();
            
            return _mapper.Map<FinancialReportDTO>(report);
        }

        public async Task<bool> DeleteReportAsync(Guid id)
        {
            var report = await _unitOfWork.Repository<FinancialReport>().GetByIdAsync(id);
            if (report == null)
                return false;

            await _unitOfWork.Repository<FinancialReport>().Delete(report);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
