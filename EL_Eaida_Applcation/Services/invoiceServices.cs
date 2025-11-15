using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.IncoiceDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace EL_Eaida_Applcation.Services
{
    public class invoiceServices : IinvoiceServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public invoiceServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<InvoiceDto> Createinvoice(CreateInvoiceDto createInvoiceDto)
        {
            var invoice = _mapper.Map<Invoice>(createInvoiceDto);

            invoice.Id = Guid.NewGuid();
            invoice.CreatedAt = DateTime.UtcNow;

            // إضافة العناصر
            invoice.Items = new List<InvoiceItem>();
            foreach (var itemDto in createInvoiceDto.Items)
            {
                var item = _mapper.Map<InvoiceItem>(itemDto);
                item.Id = Guid.NewGuid();
                item.InvoiceId = invoice.Id;
                invoice.Items.Add(item);
            }

            await _unitOfWork.Repository<Invoice>().AddAsync(invoice);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<InvoiceDto>(invoice);
        }

        public async Task<bool> DeleteInvoice(Guid id)
        {
            var invoice = await _unitOfWork.Repository<Invoice>().GetByIdAsync(id);
            if (invoice == null)
                return false;

            await _unitOfWork.Repository<Invoice>().Delete(invoice);
            await _unitOfWork.CompleteAsync();

            return true;
        }

        public async Task<IEnumerable<InvoiceDto>> GetAllInvoices(int Pagesize, int pagenumber)
        {
            var invoices = await _unitOfWork.Repository<Invoice>()
                .GetAllAsync(pagenumber, Pagesize);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
        }

        public async Task<InvoiceDto> GetInvoiceById(Guid id)
        {
            var invoice = await _unitOfWork.Repository<Invoice>()
                .GetByIdAsync(id);

            if (invoice == null)
                throw new KeyNotFoundException("Invoice not found");
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<InvoiceDto>(invoice);
        }

        public async Task<InvoiceDto> UpdateInvoice(Guid id, UpdateInvoiceDto updateDto)
        {
            var invoice = await _unitOfWork.Repository<Invoice>().GetByIdAsync(id);
            if (invoice == null)
                throw new KeyNotFoundException("Invoice not found");

            // تحديث بيانات الفاتورة الأساسية فقط
            if (updateDto.TotalAmount > 0)
                invoice.TotalAmount = updateDto.TotalAmount.Value;

            if (!string.IsNullOrWhiteSpace(updateDto.PaymentMethod))
                invoice.PaymentMethod = updateDto.PaymentMethod;

            if (updateDto.PatientId.HasValue)
                invoice.PatientId = updateDto.PatientId.Value;

            if (!string.IsNullOrWhiteSpace(updateDto.CreatedBy))
                invoice.CreatedBy = updateDto.CreatedBy;

            // لا نتعامل مع العناصر هنا إطلاقًا — تبقى كما هي

            await _unitOfWork.Repository<Invoice>().Update(invoice);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<InvoiceDto>(invoice);
        }

    }
}