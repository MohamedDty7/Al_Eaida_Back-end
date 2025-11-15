using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.MedicalRecordDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace EL_Eaida_Applcation.Services
{
    public class MedicalRecordServices : IMedicalRecordServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicalRecordServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MedicalRecordDTO> CreateMedicalRecordAsync(CreateMedicalRecordDTO createMedicalRecordDTO)
        {
            var medicalRecord = _mapper.Map<MedicalRecord>(createMedicalRecordDTO);
            medicalRecord.Id = Guid.NewGuid();
            medicalRecord.CreatedAt = DateTime.UtcNow;
            
            await _unitOfWork.Repository<MedicalRecord>().AddAsync(medicalRecord);
            await _unitOfWork.CompleteAsync();
            
            return _mapper.Map<MedicalRecordDTO>(medicalRecord);
        }

        public async Task<MedicalRecordDTO?> GetMedicalRecordByIdAsync(Guid id)
        {
            var medicalRecord = await _unitOfWork.Repository<MedicalRecord>().GetByIdAsync(id);
            return medicalRecord != null ? _mapper.Map<MedicalRecordDTO>(medicalRecord) : null;
        }

        public async Task<IEnumerable<MedicalRecordDTO>> GetAllMedicalRecordsAsync()
        {
            var medicalRecords = await _unitOfWork.Repository<MedicalRecord>().GetAllAsync(1, int.MaxValue);
            return _mapper.Map<IEnumerable<MedicalRecordDTO>>(medicalRecords);
        }

        public async Task<MedicalRecordDTO?> UpdateMedicalRecordAsync(UpdateMedicalRecordDTO updateMedicalRecordDTO)
        {
            var medicalRecord = await _unitOfWork.Repository<MedicalRecord>().GetByIdAsync(updateMedicalRecordDTO.Id);
            if (medicalRecord == null)
                return null;

            if (updateMedicalRecordDTO.PatientId.HasValue)
                medicalRecord.PatientId = updateMedicalRecordDTO.PatientId.Value;
            if (updateMedicalRecordDTO.DoctorId.HasValue)
                medicalRecord.DoctorId = updateMedicalRecordDTO.DoctorId.Value;
            if (updateMedicalRecordDTO.Date.HasValue)
                medicalRecord.Date = updateMedicalRecordDTO.Date.Value;
            if (!string.IsNullOrWhiteSpace(updateMedicalRecordDTO.Diagnosis))
                medicalRecord.Diagnosis = updateMedicalRecordDTO.Diagnosis;
            if (!string.IsNullOrWhiteSpace(updateMedicalRecordDTO.Treatment))
                medicalRecord.Treatment = updateMedicalRecordDTO.Treatment;
            if (!string.IsNullOrWhiteSpace(updateMedicalRecordDTO.Notes))
                medicalRecord.Notes = updateMedicalRecordDTO.Notes;

            await _unitOfWork.Repository<MedicalRecord>().Update(medicalRecord);
            await _unitOfWork.CompleteAsync();
            
            return _mapper.Map<MedicalRecordDTO>(medicalRecord);
        }

        public async Task<bool> DeleteMedicalRecordAsync(Guid id)
        {
            var medicalRecord = await _unitOfWork.Repository<MedicalRecord>().GetByIdAsync(id);
            if (medicalRecord == null)
                return false;

            await _unitOfWork.Repository<MedicalRecord>().Delete(medicalRecord);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<IEnumerable<MedicalRecordDTO>> GetMedicalRecordsByPatientIdAsync(Guid patientId)
        {
            var allMedicalRecords = await _unitOfWork.Repository<MedicalRecord>().GetAllAsync(1, int.MaxValue);
            var filteredRecords = allMedicalRecords.Where(mr => mr.PatientId == patientId);
            return _mapper.Map<IEnumerable<MedicalRecordDTO>>(filteredRecords);
        }

        public async Task<IEnumerable<MedicalRecordDTO>> GetMedicalRecordsByDoctorIdAsync(Guid doctorId)
        {
            var allMedicalRecords = await _unitOfWork.Repository<MedicalRecord>().GetAllAsync(1, int.MaxValue);
            var filteredRecords = allMedicalRecords.Where(mr => mr.DoctorId == doctorId);
            return _mapper.Map<IEnumerable<MedicalRecordDTO>>(filteredRecords);
        }
    }
}
