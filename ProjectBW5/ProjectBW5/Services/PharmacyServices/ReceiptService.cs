using Microsoft.EntityFrameworkCore;
using ProjectBW5.Data;
using ProjectBW5.DTOs.Receipt;
using ProjectBW5.Models;

namespace ProjectBW5.Services
{
    public class ReceiptService
    {
        private readonly BW5DbContext _context;

        public ReceiptService(BW5DbContext context)
        {
            _context = context;
        }

        public async Task<List<ReceiptReadDto>> GetAllAsync()
        {
            return await _context.Receipts
                .Include(r => r.Medicine)
                .Include(r => r.Sale)
                .Include(r => r.User)
                .Select(r => new ReceiptReadDto
                {
                    MedicineId = r.MedicineId,
                    MedicineName = r.Medicine.Name,
                    SaleId = r.SaleId,
                    CustomerFiscalCode = r.Sale.CustomerFiscalCode,
                    UserId = r.UserId,
                    UserEmail = r.User.Email,
                    Quantity = r.Quantity,
                    Timestamp = r.Timestamp
                })
                .ToListAsync();
        }

        public async Task<ReceiptReadDto?> GetAsync(Guid medicineId, Guid saleId)
        {
            var receipt = await _context.Receipts
                .Include(r => r.Medicine)
                .Include(r => r.Sale)
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.MedicineId == medicineId && r.SaleId == saleId);

            if (receipt == null)
                return null;

            return new ReceiptReadDto
            {
                MedicineId = receipt.MedicineId,
                MedicineName = receipt.Medicine.Name,
                SaleId = receipt.SaleId,
                CustomerFiscalCode = receipt.Sale.CustomerFiscalCode,
                UserId = receipt.UserId,
                UserEmail = receipt.User.Email,
                Quantity = receipt.Quantity,
                Timestamp = receipt.Timestamp
            };
        }

        public async Task<bool> AddAsync(ReceiptCreateDto dto)
        {
            var medicine = await _context.Medicines.FindAsync(dto.MedicineId);
            var sale = await _context.Sales.FindAsync(dto.SaleId);

            if (medicine == null || sale == null)
                return false;

            if (!medicine.IsAvailable)
                return false;

            if (medicine.RequiresPrescription && string.IsNullOrWhiteSpace(sale.PrescriptionNumber))
                return false;

            var exists = await _context.Receipts.AnyAsync(r =>
                r.MedicineId == dto.MedicineId && r.SaleId == dto.SaleId);

            if (exists)
                return false;

            var receipt = new Receipt
            {
                MedicineId = dto.MedicineId,
                SaleId = dto.SaleId,
                Quantity = dto.Quantity,
                UserId = dto.UserId
            };

            _context.Receipts.Add(receipt);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(Guid medicineId, Guid saleId)
        {
            var receipt = await _context.Receipts
                .FirstOrDefaultAsync(r => r.MedicineId == medicineId && r.SaleId == saleId);

            if (receipt == null)
                return false;

            _context.Receipts.Remove(receipt);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(ReceiptDeleteDto dto)
        {
            return await DeleteAsync(dto.MedicineId, dto.SaleId);
        }

        public async Task<decimal> CalculateTotalSaleAmountAsync(Guid saleId)
        {
            var receipts = await _context.Receipts
                .Include(r => r.Medicine)
                .Where(r => r.SaleId == saleId)
                .ToListAsync();

            decimal totalAmount = 0;

            foreach (var receipt in receipts)
            {
                totalAmount += receipt.Medicine.Price * receipt.Quantity;
            }

            return totalAmount;
        }

        public async Task<List<MedicineSoldDto>> GetMedicinesSoldOnDateAsync(DateTime date)
        {
            var startDate = date.Date;
            var endDate = startDate.AddDays(1);

            return await _context.Receipts
                .Include(r => r.Medicine)
                .Where(r => r.Timestamp >= startDate && r.Timestamp < endDate)
                .Select(r => new MedicineSoldDto
                {
                    MedicineId = r.MedicineId,
                    MedicineName = r.Medicine.Name,
                    Quantity = r.Quantity,
                    Timestamp = r.Timestamp
                })
                .ToListAsync();
        }

        public async Task<List<MedicineSoldDto>> GetMedicinesSoldByCustomerAsync(string fiscalCode)
        {
            return await _context.Receipts
                .Include(r => r.Medicine)
                .Include(r => r.Sale)
                .Where(r => r.Sale.CustomerFiscalCode == fiscalCode)
                .Select(r => new MedicineSoldDto
                {
                    MedicineId = r.MedicineId,
                    MedicineName = r.Medicine.Name,
                    Quantity = r.Quantity,
                    Timestamp = r.Timestamp,
                    CustomerFiscalCode = r.Sale.CustomerFiscalCode
                })
                .ToListAsync();
        }

        public async Task<List<MedicineSoldDto>> GetMedicinesSoldByUserAsync(string userId)
        {
            return await _context.Receipts
                .Include(r => r.Medicine)
                .Include(r => r.Sale)
                .Include(r => r.User)
                .Where(r => r.UserId == userId)
                .Select(r => new MedicineSoldDto
                {
                    MedicineId = r.MedicineId,
                    MedicineName = r.Medicine.Name,
                    Quantity = r.Quantity,
                    Timestamp = r.Timestamp,
                    CustomerFiscalCode = r.Sale.CustomerFiscalCode,
                    UserId = r.UserId,
                    UserEmail = r.User.Email
                })
                .ToListAsync();
        }

    }
}
