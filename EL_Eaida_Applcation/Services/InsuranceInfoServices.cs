using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.InsuranceInfoDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace EL_Eaida_Applcation.Services
{
    public class InsuranceInfoServices : IInsuranceInfoServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InsuranceInfoServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<InsuranceInfoDTO> CreateInsuranceInfoAsync(CreateInsuranceInfoDTO createInsuranceInfoDTO)
        {
            var insuranceInfo = _mapper.Map<InsuranceInfo>(createInsuranceInfoDTO);
            insuranceInfo.Id = Guid.NewGuid();
            insuranceInfo.CreatedAt = DateTime.UtcNow;
            
            await _unitOfWork.Repository<InsuranceInfo>().AddAsync(insuranceInfo);
            await _unitOfWork.CompleteAsync();
            
            return _mapper.Map<InsuranceInfoDTO>(insuranceInfo);
        }

        public async Task<InsuranceInfoDTO?> GetInsuranceInfoByIdAsync(Guid id)
        {
            var insuranceInfo = await _unitOfWork.Repository<InsuranceInfo>().GetByIdAsync(id);
            return insuranceInfo != null ? _mapper.Map<InsuranceInfoDTO>(insuranceInfo) : null;
        }

        public async Task<IEnumerable<InsuranceInfoDTO>> GetAllInsuranceInfosAsync()
        {
            var insuranceInfos = await _unitOfWork.Repository<InsuranceInfo>().GetAllAsync(1, int.MaxValue);
            return _mapper.Map<IEnumerable<InsuranceInfoDTO>>(insuranceInfos);
        }

        public async Task<InsuranceInfoDTO?> UpdateInsuranceInfoAsync(UpdateInsuranceInfoDTO updateInsuranceInfoDTO)
        {
            var insuranceInfo = await _unitOfWork.Repository<InsuranceInfo>().GetByIdAsync(updateInsuranceInfoDTO.Id);
            if (insuranceInfo == null)
                return null;

            if (!string.IsNullOrWhiteSpace(updateInsuranceInfoDTO.Provider))
                insuranceInfo.Provider = updateInsuranceInfoDTO.Provider;
            if (!string.IsNullOrWhiteSpace(updateInsuranceInfoDTO.PolicyNumber))
                insuranceInfo.PolicyNumber = updateInsuranceInfoDTO.PolicyNumber;
            if (!string.IsNullOrWhiteSpace(updateInsuranceInfoDTO.GroupNumber))
                insuranceInfo.GroupNumber = updateInsuranceInfoDTO.GroupNumber;
            if (updateInsuranceInfoDTO.ValidUntil.HasValue)
                insuranceInfo.ValidUntil = updateInsuranceInfoDTO.ValidUntil.Value;

            await _unitOfWork.Repository<InsuranceInfo>().Update(insuranceInfo);
            await _unitOfWork.CompleteAsync();
            
            return _mapper.Map<InsuranceInfoDTO>(insuranceInfo);
        }

        public async Task<bool> DeleteInsuranceInfoAsync(Guid id)
        {
            var insuranceInfo = await _unitOfWork.Repository<InsuranceInfo>().GetByIdAsync(id);
            if (insuranceInfo == null)
                return false;

            await _unitOfWork.Repository<InsuranceInfo>().Delete(insuranceInfo);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
























