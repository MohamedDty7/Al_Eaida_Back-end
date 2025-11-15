using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.Prescription;
using EL_Eaida_Applcation.InterFaceServices.IPresciptionitemServices;
using EL_Eaida_Applcation.InterFaceServices.IPrescriptionServices;

namespace EL_Eaida_Applcation.Services
{
    public class PrescriptionServices : IPrescriptionServices
    {  
       protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;
        public PrescriptionServices(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<PrescriptionDto> CreatePrescriptionAsync(CreatePrescriptionDto value)
        {
             var prescription = _mapper.Map<Prescription>(value); 
            await _unitOfWork.Repository<Prescription>().AddAsync(prescription);
            await _unitOfWork. CompleteAsync();
            return _mapper.Map<PrescriptionDto>(prescription);


        }

        public async Task<bool> DeletePrescriptionAsync(Guid id)
        {
            var prescription = _unitOfWork.Repository<Prescription>().GetByIdAsync(id);
        
            await _unitOfWork.Repository<Prescription>().Delete(prescription.Result);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<IEnumerable<PrescriptionDto>> GetAllPrescriptionsAsync(int pageSize, int pageNumber)
        {
           var prescriptions = await _unitOfWork.Repository<Prescription>().GetAllAsync(pageNumber, pageSize);
            var prescriptionDtos = _mapper.Map<IEnumerable<PrescriptionDto>>(prescriptions);
            await _unitOfWork.CompleteAsync();
            return prescriptionDtos;
        }

        public async Task<PrescriptionDto?> GetPrescriptionByIdAsync(Guid id)
        {
            var prescription =     await _unitOfWork.Repository<Prescription>().GetByIdAsync(id);
            var prescriptionDto = _mapper.Map<PrescriptionDto>(prescription);
            await _unitOfWork.CompleteAsync();
            return prescriptionDto;
        }

        public async Task<IEnumerable<PrescriptionDto>> GetPrescriptionsByPatientIdAsync(Guid patientId)
        {
            var allPrescriptions = await _unitOfWork.Repository<Prescription>().GetAllAsync(1, int.MaxValue);
            var filtered = allPrescriptions.Where(p => p.PatientId == patientId).ToList();
            return _mapper.Map<IEnumerable<PrescriptionDto>>(filtered);

        }

        public async Task<PrescriptionDto?> UpdatePrescriptionAsync(UpdatePrescriptionDto dto)
        {
            var prescription = await _unitOfWork.Repository<Prescription>().GetByIdAsync(dto.Id);
            if (prescription == null) return null;

            
            if (dto.PatientId.HasValue)
                prescription.PatientId = dto.PatientId.Value;

            if (dto.DoctorId.HasValue)
                prescription.DoctorId = dto.DoctorId.Value;

            if (dto.MedicationId.HasValue)
                prescription.MedicationId = dto.MedicationId.Value;

           await  _unitOfWork.Repository<Prescription>().Update(prescription);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<PrescriptionDto>(prescription);
        }
    }
}
