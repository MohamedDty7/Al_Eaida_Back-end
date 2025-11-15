using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.MedicationCategoryDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace EL_Eaida_Applcation.Services
{
    public class MedicationCategoryServices : IMedicationCategoryServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicationCategoryServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MedicationCategoryDTO> CreateCategoryAsync(CreateMedicationCategoryDTO createDto)
        {
            var category = _mapper.Map<MedicationCategory>(createDto);
            category.Id = Guid.NewGuid();
            category.CreatedAt = DateTime.UtcNow;
            
            await _unitOfWork.Repository<MedicationCategory>().AddAsync(category);
            await _unitOfWork.CompleteAsync();
            
            return _mapper.Map<MedicationCategoryDTO>(category);
        }

        public async Task<MedicationCategoryDTO?> GetCategoryByIdAsync(Guid id)
        {
            var category = await _unitOfWork.Repository<MedicationCategory>().GetByIdAsync(id);
            return category != null ? _mapper.Map<MedicationCategoryDTO>(category) : null;
        }

        public async Task<IEnumerable<MedicationCategoryDTO>> GetAllCategoriesAsync()
        {
            var categories = await _unitOfWork.Repository<MedicationCategory>().GetAllAsync(1, int.MaxValue);
            return _mapper.Map<IEnumerable<MedicationCategoryDTO>>(categories);
        }

        public async Task<IEnumerable<MedicationCategoryDTO>> GetCategoriesByMedicineIdAsync(Guid medicineId)
        {
            var categories = await _unitOfWork.MedicationCategoryRepository.GetCategoriesByMedicineIdAsync(medicineId);
            return _mapper.Map<IEnumerable<MedicationCategoryDTO>>(categories);
        }

        public async Task<IEnumerable<MedicationCategoryDTO>> GetMedicinesByCategoryIdAsync(Guid categoryId)
        {
            var categories = await _unitOfWork.MedicationCategoryRepository.GetMedicinesByCategoryIdAsync(categoryId);
            return _mapper.Map<IEnumerable<MedicationCategoryDTO>>(categories);
        }

        public async Task<MedicationCategoryDTO?> UpdateCategoryAsync(UpdateMedicationCategoryDTO updateDto)
        {
            var category = await _unitOfWork.Repository<MedicationCategory>().GetByIdAsync(updateDto.Id);
            if (category == null)
                return null;

            if (updateDto.MedicationId.HasValue)
                category.MedicationId = updateDto.MedicationId.Value;
            if (updateDto.CategoryId.HasValue)
                category.CategoryId = updateDto.CategoryId.Value;

            await _unitOfWork.Repository<MedicationCategory>().Update(category);
            await _unitOfWork.CompleteAsync();
            
            return _mapper.Map<MedicationCategoryDTO>(category);
        }

        public async Task<bool> DeleteCategoryAsync(Guid id)
        {
            var category = await _unitOfWork.Repository<MedicationCategory>().GetByIdAsync(id);
            if (category == null)
                return false;

            await _unitOfWork.Repository<MedicationCategory>().Delete(category);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
