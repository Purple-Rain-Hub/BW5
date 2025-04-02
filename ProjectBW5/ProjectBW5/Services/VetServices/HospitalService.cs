using Microsoft.EntityFrameworkCore;
using ProjectBW5.Data;
using ProjectBW5.DTOs.Hospitalization;
using ProjectBW5.Models;

namespace ProjectBW5.Services.VetServices
{
    public class HospitalService
    {
        private readonly BW5DbContext _context;

        public HospitalService(BW5DbContext context)
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
        
        public async Task<bool> CheckDate(Guid id, DateTime startDate)
        {
            try
            {
                var animal = await _context.Animals.FirstOrDefaultAsync(s => s.Id == id);
                if (animal == null || animal.BirthDate > startDate)
                {
                    return false ;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> CreateHospitalAsync(Guid id, CreateHospitalDto createHospital)
        {
            try
            {
                var IsValid = await CheckDate(id, createHospital.StartDate);
                if (!IsValid)
                {
                    return false;
                }
                var hospital = new Hospitalization()
                {
                    AnimalId = id,
                    StartDate = createHospital.StartDate,
                    EndDate = createHospital.EndDate,
                    HospitalObjective = createHospital.HospitalObjective,
                    HospitalTreatment = createHospital.HospitalTreatment,
                    VetId = createHospital.VetId
                };

                _context.Hospitalizations.Add(hospital);
                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> UpdateHospitalAsync(Guid id, CreateHospitalDto updateHospital)
        {
            try
            {
                var existingHospital = await _context.Hospitalizations.FirstOrDefaultAsync(a => a.Id == id);

                if (existingHospital == null)
                {
                    return false;
                }
                var IsValid = await CheckDate(existingHospital.AnimalId, updateHospital.StartDate);
                if (!IsValid)
                {
                    return false;
                }

                existingHospital.StartDate = updateHospital.StartDate;
                existingHospital.EndDate = updateHospital.EndDate;
                existingHospital.HospitalObjective = updateHospital.HospitalObjective;
                existingHospital.HospitalTreatment = updateHospital.HospitalTreatment;
                existingHospital.VetId = updateHospital.VetId;

                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> DeleteHospitalAsync(Guid id)
        {
            try
            {
                var hospital = await _context.Hospitalizations.FirstOrDefaultAsync(a => a.Id == id);

                if (hospital == null)
                {
                    return false;
                }

                _context.Hospitalizations.Remove(hospital);

                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }
        public async Task<List<GetHospitalRequestDto>?> GetHospitalsAsync()
        {
            try
            {
                var hospitals = await _context.Hospitalizations.Include(h=> h.Animal).Include(h=> h.User).OrderByDescending(h=> h.EndDate).ToListAsync();
                if (hospitals == null)
                {
                    return null;
                }
                var hospitalsRequest = new List<GetHospitalRequestDto>();

                foreach (var hospital in hospitals)
                {
                    var request = new GetHospitalRequestDto()
                    {
                        Id = hospital.Id,
                        AnimalId = hospital.AnimalId,
                        AnimalName = hospital.Animal.Name,
                        StartDate = hospital.StartDate,
                        EndDate = hospital.EndDate,
                        HospitalObjective = hospital.HospitalObjective,
                        HospitalTreatment = hospital.HospitalTreatment,
                        OwnerName = hospital.Animal.OwnerName,
                        OwnerSurname = hospital.Animal.OwnerSurname,
                        VetId = hospital.VetId,
                        VetName = hospital.User.Email
                    };

                    hospitalsRequest.Add(request);
                }

                return hospitalsRequest;
            }
            catch
            {
                return null;
            }
        }
        public async Task<GetHospitalRequestDto?> GetHospitalByIdAsync(Guid id)
        {
            try
            {
                var existingHospital = await _context.Hospitalizations.FirstOrDefaultAsync(e => e.Id == id);

                if (existingHospital == null)
                {
                    return null;
                }

                var hospital = new GetHospitalRequestDto()
                {
                    Id = existingHospital.Id,
                    AnimalId = existingHospital.AnimalId,
                    AnimalName = existingHospital.Animal.Name,
                    StartDate = existingHospital.StartDate,
                    EndDate = existingHospital.EndDate,
                    HospitalObjective = existingHospital.HospitalObjective,
                    HospitalTreatment = existingHospital.HospitalTreatment,
                    OwnerName = existingHospital.Animal.OwnerName,
                    OwnerSurname = existingHospital.Animal.OwnerSurname,
                    VetId = existingHospital.VetId,
                    VetName = existingHospital.User.Email
                };

                return hospital;
            }
            catch
            {
                return null;
            }
        }
        public async Task<bool> EndHospitalAsync(Guid id, DateTime EndHospital)
        {
            try
            {
                var existingHospital = await _context.Hospitalizations.Where(h=> h.EndDate == null).FirstOrDefaultAsync(a => a.Id == id);

                if (existingHospital == null)
                {
                    return false;
                }
                if (EndHospital <= existingHospital.StartDate)
                {
                    return false;
                }

                existingHospital.EndDate = EndHospital;

                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }
        public async Task<List<GetHospitalRequestDto>?> GetAnimalHospitalsAsync(Guid id)
        {
            try
            {
                var hospitals = await _context.Hospitalizations.Where(h=> h.AnimalId == id).Include(h => h.Animal).Include(h => h.User).OrderByDescending(h => h.EndDate).ToListAsync();
                if (hospitals == null)
                {
                    return null;
                }
                var hospitalsRequest = new List<GetHospitalRequestDto>();

                foreach (var hospital in hospitals)
                {
                    var request = new GetHospitalRequestDto()
                    {
                        Id = hospital.Id,
                        AnimalId = hospital.AnimalId,
                        AnimalName = hospital.Animal.Name,
                        StartDate = hospital.StartDate,
                        EndDate = hospital.EndDate,
                        HospitalObjective = hospital.HospitalObjective,
                        HospitalTreatment = hospital.HospitalTreatment,
                        OwnerName = hospital.Animal.OwnerName,
                        OwnerSurname = hospital.Animal.OwnerSurname,
                        VetId = hospital.VetId,
                        VetName = hospital.User.Email
                    };

                    hospitalsRequest.Add(request);
                }

                return hospitalsRequest;
            }
            catch
            {
                return null;
            }
        }
    }
}
