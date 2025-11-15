using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.MedicineDTO;
using EL_Eaida_Applcation.DTO.PatientsDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace EL_Eaida_Applcation.Services
{
    public  class MedicineServices : IMedicineServices
    {
         protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        public MedicineServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<MedicineDTO> CreateMedicineAsync(CreateMedicineDTO value)
        {
             var medicine = _mapper.Map<Medicine>(value);
             await _unitOfWork.Repository<Medicine>().AddAsync(medicine);
            await _unitOfWork.CompleteAsync();
            var medicineDto = _mapper.Map<MedicineDTO>(medicine);
            return medicineDto;
        }

        public async Task<bool> DeleteMedicineAsync(Guid id)
        {
            var medicine = await  _unitOfWork.Repository<Medicine>().GetByIdAsync(id);
            var result = await _unitOfWork.Repository<Medicine>().Delete(medicine);
            await _unitOfWork.CompleteAsync();
            return true;

        }

        public async Task<IEnumerable<MedicineDTO>> GetAllMedicinesAsync(int pageSize, int pageNumber)
        {
           var medicines =  await _unitOfWork.Repository<Medicine>().GetAllAsync(pageNumber, pageSize);
            var medicineDtos = _mapper.Map<IEnumerable<MedicineDTO>>(medicines);
            await _unitOfWork.CompleteAsync();
            return medicineDtos;
        }

        public async Task<MedicineDTO> GetMedicineByIdAsync(Guid id)
        {
            var medicine = await _unitOfWork.Repository<Medicine>().GetByIdAsync(id);
              var result = await _unitOfWork.CompleteAsync();
            var medicineDto = _mapper.Map<MedicineDTO>(medicine);
            return medicineDto;
        }

        public async Task<MedicineDTO?> UpdateMedicineAsync(UpDateMedicineDTO dto)
        {
            var medicine = await _unitOfWork.Repository<Medicine>().GetByIdAsync(dto.Id);
            if (medicine == null) return null;

            if (!string.IsNullOrWhiteSpace(dto.Name))
                medicine.Name = dto.Name;

            if (dto.Quantity > 0)
                medicine.StockQuantity = dto.Quantity;

            if (dto.ExpirationDate.HasValue)
                //medicine.ExpirationD = dto.ExpirationDate.Value;

            if (dto.Price > 0)
                medicine.Price = dto.Price;

            await _unitOfWork.Repository<Medicine>().Update(medicine);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<MedicineDTO>(medicine);

        }
    }
}
