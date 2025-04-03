using Microsoft.EntityFrameworkCore;
using ProjectBW5.Data;
using ProjectBW5.DTOs.StrayHospital;
using ProjectBW5.Models;

namespace ProjectBW5.Services.VetServices
{
    public class StrayHospitalService
    {
        private readonly BW5DbContext _context;

        public StrayHospitalService(BW5DbContext context)
        {
            _context = context;
        }
        public async Task<bool> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> CreateStrayHospitalAsync(CreateStrayHospitalDto createStrayHospital)
        {
            try
            {
                var strayHospital = new StrayHospital()
                {
                    StartDate = createStrayHospital.StartDate,
                    EndDate = createStrayHospital.EndDate,
                    AnimalId = createStrayHospital.AnimalId,
                    VetId = createStrayHospital.VetId
                };

                _context.StrayHospitals.Add(strayHospital);
                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> UpdateStrayHospitalAsync(Guid id, CreateStrayHospitalDto updateStrayHospital)
        {
            try
            {
                var existingStrayHospital = await _context.StrayHospitals.FirstOrDefaultAsync(s => s.Id == id);

                if (existingStrayHospital == null)
                {
                    return false;
                }

                existingStrayHospital.StartDate = updateStrayHospital.StartDate;
                existingStrayHospital.EndDate = updateStrayHospital.EndDate;
                existingStrayHospital.AnimalId = updateStrayHospital.AnimalId;
                existingStrayHospital.VetId = updateStrayHospital.VetId;

                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> DeleteStrayHospitalAsync(Guid id)
        {
            try
            {
                var strayHospital = await _context.StrayHospitals.FirstOrDefaultAsync(s => s.Id == id);

                if (strayHospital == null)
                {
                    return false;
                }

                _context.StrayHospitals.Remove(strayHospital);

                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }
        public async Task<List<GetStrayHospitalRequestDto>?> GetStrayHospitalsAsync()
        {
            try
            {
                var strayHospitals = await _context.StrayHospitals.Include(s=> s.Animal).Include(s=> s.User).OrderByDescending(s => s.EndDate).ToListAsync();
                if (strayHospitals == null)
                {
                    return null;
                }
                var strayHospitalsRequest = new List<GetStrayHospitalRequestDto>();

                foreach (var strayHospital in strayHospitals)
                {
                    var request = new GetStrayHospitalRequestDto()
                    {
                        Id = strayHospital.Id,
                        RegistrationDate = strayHospital.Animal.RegistrationDate,
                        Type = strayHospital.Animal.Type,
                        StartDate = strayHospital.StartDate,
                        EndDate = strayHospital.EndDate,
                        CoatColor = strayHospital.Animal.CoatColor,
                        HasMicrochip = strayHospital.Animal.HasMicrochip,
                        MicrochipNumber = strayHospital.Animal.MicrochipNumber,
                        AnimalId = strayHospital.AnimalId,
                        VetId = strayHospital.VetId,
                        VetName = strayHospital.User.Email
                    };

                    strayHospitalsRequest.Add(request);
                }

                return strayHospitalsRequest;
            }
            catch
            {
                return null;
            }
        }
        public async Task<GetStrayHospitalRequestDto?> GetStrayHospitalByIdAsync(Guid id)
        {
            try
            {
                var existingStrayHospital = await _context.StrayHospitals.Include(s => s.Animal).Include(s=> s.User).FirstOrDefaultAsync(s => s.Id == id);

                if (existingStrayHospital == null)
                {
                    return null;
                }

                var strayHospital = new GetStrayHospitalRequestDto()
                {
                    Id = existingStrayHospital.Id,
                    RegistrationDate = existingStrayHospital.Animal.RegistrationDate,
                    Type = existingStrayHospital.Animal.Type,
                    StartDate = existingStrayHospital.StartDate,
                    EndDate = existingStrayHospital.EndDate,
                    CoatColor = existingStrayHospital.Animal.CoatColor,
                    HasMicrochip = existingStrayHospital.Animal.HasMicrochip,
                    MicrochipNumber = existingStrayHospital.Animal.MicrochipNumber,
                    AnimalId = existingStrayHospital.AnimalId,
                    VetId = existingStrayHospital.VetId,
                    VetName = existingStrayHospital.User.Email
                };

                return strayHospital;
            }
            catch
            {
                return null;
            }
        }
        public async Task<List<GetStrayHospitalRequestDto>?> GetActiveStrayHospitalsAsync()
        {
            try
            {
                var strayHospitals = await _context.StrayHospitals.Where(s=> s.EndDate == null).Include(s=> s.Animal).Include(s=> s.User).OrderByDescending(s=> s.StartDate).ToListAsync();
                if (strayHospitals == null)
                {
                    return null;
                }
                var strayHospitalsRequest = new List<GetStrayHospitalRequestDto>();

                foreach (var strayHospital in strayHospitals)
                {
                    var request = new GetStrayHospitalRequestDto()
                    {
                        Id = strayHospital.Id,
                        RegistrationDate = strayHospital.Animal.RegistrationDate,
                        Type = strayHospital.Animal.Type,
                        StartDate = strayHospital.StartDate,
                        EndDate = strayHospital.EndDate,
                        CoatColor = strayHospital.Animal.CoatColor,
                        HasMicrochip = strayHospital.Animal.HasMicrochip,
                        MicrochipNumber = strayHospital.Animal.MicrochipNumber,
                        AnimalId = strayHospital.AnimalId,
                        VetId = strayHospital.VetId,
                        VetName = strayHospital.User.Email
                    };

                    strayHospitalsRequest.Add(request);
                }

                return strayHospitalsRequest;
            }
            catch
            {
                return null;
            }
        }
        public async Task<GetStrayHospitalByMicrochipRequestDto?> GetStrayHospitalByMicrochipAsync(int microchipNumber)
        {
            try
            {
                var existingStrayHospital = await _context.StrayHospitals.Where(s=> s.EndDate == null).Include(s=> s.Animal).Include(s=> s.User).FirstOrDefaultAsync(s => s.Animal.MicrochipNumber == microchipNumber);

                if (existingStrayHospital == null)
                {
                    return null;
                }

                var strayHospital = new GetStrayHospitalByMicrochipRequestDto()
                {
                    Type = existingStrayHospital.Animal.Type,
                    StartDate = existingStrayHospital.StartDate,
                    CoatColor = existingStrayHospital.Animal.CoatColor,
                    VetName = existingStrayHospital.User.Email
                };

                return strayHospital;
            }
            catch
            {
                return null;
            }
        }
        public async Task<bool> EndStrayHospitalAsync(Guid id, DateTime EndStrayHospital)
        {
            try
            {
                var existingStrayHospital = await _context.StrayHospitals.Where(h => h.EndDate == null).FirstOrDefaultAsync(a => a.Id == id);

                if (existingStrayHospital == null)
                {
                    return false;
                }
                if (EndStrayHospital <= existingStrayHospital.StartDate)
                {
                    return false;
                }

                existingStrayHospital.EndDate = EndStrayHospital;

                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }
    }
}
