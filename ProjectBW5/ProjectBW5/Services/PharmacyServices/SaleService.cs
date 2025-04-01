using Microsoft.EntityFrameworkCore;
using ProjectBW5.Data;
using ProjectBW5.DTOs.Sale;
using ProjectBW5.Models;

namespace ProjectBW5.Services
{
    public class SaleService
    {
        private readonly BW5DbContext _context;

        public SaleService(BW5DbContext context)
        {
            _context = context;
        }

        public async Task<List<SaleReadDto>> GetAllAsync()
        {
            return await _context.Sales
                .Select(s => new SaleReadDto
                {
                    Id = s.Id,
                    CustomerFiscalCode = s.CustomerFiscalCode,
                    SaleDate = s.SaleDate,
                    PrescriptionNumber = s.PrescriptionNumber
                })
                .ToListAsync();
        }

        public async Task<SaleReadDto?> GetByIdAsync(Guid id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale == null) return null;

            return new SaleReadDto
            {
                Id = sale.Id,
                CustomerFiscalCode = sale.CustomerFiscalCode,
                SaleDate = sale.SaleDate,
                PrescriptionNumber = sale.PrescriptionNumber
            };
        }

        public async Task<Guid> AddAsync(SaleCreateDto dto)
        {
            var sale = new Sale
            {
                Id = Guid.NewGuid(),
                CustomerFiscalCode = dto.CustomerFiscalCode,
                PrescriptionNumber = dto.PrescriptionNumber
            };

            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();

            return sale.Id;
        }

        public async Task<bool> UpdateAsync(SaleUpdateDto dto)
        {
            var sale = await _context.Sales.FindAsync(dto.Id);
            if (sale == null) return false;

            sale.CustomerFiscalCode = dto.CustomerFiscalCode;
            sale.PrescriptionNumber = dto.PrescriptionNumber;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale == null) return false;

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
