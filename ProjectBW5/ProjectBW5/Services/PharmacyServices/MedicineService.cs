using Microsoft.EntityFrameworkCore;
using ProjectBW5.Data;
using ProjectBW5.DTOs.Medicine;
using ProjectBW5.Models;

namespace ProjectBW5.Services
{
    public class MedicineService
    {
        private readonly BW5DbContext _context;

        public MedicineService(BW5DbContext context)
        {
            _context = context;
        }

        public async Task<List<MedicineReadDto>> GetAllAsync()
        {
            return await _context.Medicines
                .Select(m => new MedicineReadDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    SupplierCompany = m.SupplierCompany,
                    UsageList = m.UsageList,
                    StorageLocationId = m.StorageLocationId,
                    RequiresPrescription = m.RequiresPrescription,
                    Price = m.Price,
                    IsAvailable = m.IsAvailable
                })
                .ToListAsync();
        }

        public async Task<MedicineReadDto?> GetByIdAsync(Guid id)
        {
            var medicine = await _context.Medicines.FindAsync(id);
            if (medicine == null) return null;

            return new MedicineReadDto
            {
                Id = medicine.Id,
                Name = medicine.Name,
                SupplierCompany = medicine.SupplierCompany,
                UsageList = medicine.UsageList,
                StorageLocationId = medicine.StorageLocationId,
                RequiresPrescription = medicine.RequiresPrescription,
                Price = medicine.Price,
                IsAvailable = medicine.IsAvailable
            };
        }

        public async Task AddAsync(MedicineCreateDto dto)
        {
            var medicine = new Medicine
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                SupplierCompany = dto.SupplierCompany,
                UsageList = dto.UsageList,
                StorageLocationId = dto.StorageLocationId,
                RequiresPrescription = dto.RequiresPrescription,
                Price = dto.Price,
                IsAvailable = dto.IsAvailable
            };

            _context.Medicines.Add(medicine);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(MedicineUpdateDto dto)
        {
            var medicine = await _context.Medicines.FindAsync(dto.Id);
            if (medicine == null) return false;

            medicine.StorageLocationId = dto.StorageLocationId;
            medicine.RequiresPrescription = dto.RequiresPrescription;
            medicine.Price = dto.Price;
            medicine.IsAvailable = dto.IsAvailable;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var medicine = await _context.Medicines.FindAsync(id);
            if (medicine == null) return false;

            _context.Medicines.Remove(medicine);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
