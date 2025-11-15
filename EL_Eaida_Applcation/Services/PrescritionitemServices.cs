using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.Prescriptionitem;
using EL_Eaida_Applcation.InterFaceServices.IPresciptionitemServices;

namespace EL_Eaida_Applcation.Services
{
    public class PrescritionitemServices : IPresciptionitemServices
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;
        public PrescritionitemServices(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<PrescriptionItemDto> CreatePrescriptionItemAsync(CreatePrescriptionItemDto createPrescriptionItemDto)
        {
            var prescriptionItem = _mapper.Map<PrescriptionItem>(createPrescriptionItemDto);
            await _unitOfWork.Repository<PrescriptionItem>().AddAsync(prescriptionItem);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<PrescriptionItemDto>(prescriptionItem);


        }

        public async Task<bool> DeletePrescriptionItemAsync(Guid id)
        {
            var prescriptionItem = await _unitOfWork.Repository<PrescriptionItem>().GetByIdAsync(id);
            var result = await _unitOfWork.Repository<PrescriptionItem>().Delete(prescriptionItem);
            await _unitOfWork.CompleteAsync();
            return true;

        }

        public async Task<IEnumerable<PrescriptionItemDto>> GetAllPrescriptionItemsAsync(int pageSize, int pageNumber)
        {
            var prescriptionItems = await _unitOfWork.Repository<PrescriptionItem>().GetAllAsync(pageNumber, pageSize);
            var prescriptionItemDtos = _mapper.Map<IEnumerable<PrescriptionItemDto>>(prescriptionItems);
            await _unitOfWork.CompleteAsync();
            return prescriptionItemDtos;
        }

        public async Task<PrescriptionItemDto> GetPrescriptionItemByIdAsync(Guid id)
        {
            var prescriptionItem = await _unitOfWork.Repository<PrescriptionItem>().GetByIdAsync(id);
            var prescriptionItemDto = _mapper.Map<PrescriptionItemDto>(prescriptionItem);
            await _unitOfWork.CompleteAsync();
            return prescriptionItemDto;
        }

        public async Task<List<PrescriptionItemDto>> GetPrescriptionItemsByMedicineIdAsync(Guid MedicineId)
        {
            var prescriptionItems = await _unitOfWork.Repository<PrescriptionItem>().GetAllAsync(1, int.MaxValue);
            var filteredItems = prescriptionItems.Where(pi => pi.MedicineId == MedicineId).ToList();
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<List<PrescriptionItemDto>>(filteredItems);
        }

        public async Task<bool> UpdatePrescriptionItemAsync(UpdatePrescriptionItemDto updatePrescriptionItemDto)
        {
            var prescriptionItem = await _unitOfWork.Repository<PrescriptionItem>().GetByIdAsync(updatePrescriptionItemDto.Id);
            if (prescriptionItem == null) return false;
            if (updatePrescriptionItemDto.PrescriptionId.HasValue)
                prescriptionItem.PrescriptionId = updatePrescriptionItemDto.PrescriptionId.Value;
                
            if (!string.IsNullOrWhiteSpace(updatePrescriptionItemDto.Dosage))
            {
                prescriptionItem.Dosage = updatePrescriptionItemDto.Dosage;
            }
            
            if (updatePrescriptionItemDto.Duration.HasValue)
            {
                prescriptionItem.Duration = updatePrescriptionItemDto.Duration.Value;
            }
            
            if (updatePrescriptionItemDto.MedicineId.HasValue)
            {
                prescriptionItem.MedicineId = updatePrescriptionItemDto.MedicineId.Value;
            }
            await _unitOfWork.Repository<PrescriptionItem>().Update(prescriptionItem);
            await _unitOfWork.CompleteAsync();
            return true;


        }
    }
}
