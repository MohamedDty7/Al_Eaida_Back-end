using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.PatientsDTO
{
    /// <summary>
    /// نتيجة صفحة المرضى مع معلومات الصفحات
    /// </summary>
    public class PagedPatientResultDTO
    {
        /// <summary>
        /// قائمة المرضى في الصفحة الحالية
        /// </summary>
        public IEnumerable<PatientDTO> Patients { get; set; } = new List<PatientDTO>();

        /// <summary>
        /// رقم الصفحة الحالية
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// حجم الصفحة (عدد المرضى في كل صفحة)
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// إجمالي عدد المرضى
        /// </summary>
        public int TotalPatients { get; set; }

        /// <summary>
        /// إجمالي عدد الصفحات
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// هل هناك صفحة سابقة
        /// </summary>
        public bool HasPreviousPage => CurrentPage > 1;

        /// <summary>
        /// هل هناك صفحة تالية
        /// </summary>
        public bool HasNextPage => CurrentPage < TotalPages;

        /// <summary>
        /// عدد المرضى في الصفحة الحالية
        /// </summary>
        public int PatientsInCurrentPage => Patients.Count();
    }
}

