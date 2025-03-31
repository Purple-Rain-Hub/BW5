using Microsoft.EntityFrameworkCore;
using ProjectBW5.Data;
using ProjectBW5.DTOs.Artist;
using ProjectBW5.DTOs.Registry;
using ProjectBW5.Models;

namespace ProjectBW5.Services.VetServices
{
    public class RegistryService
    {
        private readonly BW5DbContext _context;

        public RegistryService(BW5DbContext context)
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

        public async Task<bool> CreateAnimalAsync(CreateAnimalDto createAnimal)
        {
            try
            {
                var animal = new Animal()
                {
                    Name = createAnimal.Name,
                    Type = createAnimal.Type,
                    CoatColor = createAnimal.CoatColor,
                    BirthDate = createAnimal.BirthDate,
                    HasMicrochip = createAnimal.HasMicrochip,
                    MicrochipNumber = createAnimal.MicrochipNumber,
                    OwnerName = createAnimal.OwnerName,
                    OwnerSurname = createAnimal.OwnerSurname
                };

                _context.Animals.Add(animal);
                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> UpdateAnimalAsync(Guid id, CreateAnimalDto updateAnimal)
        {
            try
            {
                var existingAnimal = await _context.Animals.FirstOrDefaultAsync(a => a.Id == id);

                if (existingAnimal == null)
                {
                    return false;
                }

                existingAnimal.Name = updateAnimal.Name;
                existingAnimal.Type = updateAnimal.Type;
                existingAnimal.CoatColor = updateAnimal.CoatColor;
                existingAnimal.BirthDate = updateAnimal.BirthDate;
                existingAnimal.HasMicrochip = updateAnimal.HasMicrochip;
                existingAnimal.MicrochipNumber = updateAnimal.MicrochipNumber;
                existingAnimal.OwnerName = updateAnimal.OwnerName;
                existingAnimal.OwnerSurname = updateAnimal.OwnerSurname;

                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> DeleteAnimalAsync(Guid id)
        {
            try
            {
                var animal = await _context.Animals.FirstOrDefaultAsync(a => a.Id == id);

                if (animal == null)
                {
                    return false;
                }

                _context.Animals.Remove(animal);

                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }
        public async Task<List<GetAnimalRequestDto>?> GetAnimalsAsync()
        {
            try
            {
                var animals = await _context.Animals.ToListAsync();

                var animalsRequest = new List<GetAnimalRequestDto>();

                foreach (var animal in animals)
                {
                    var request = new GetAnimalRequestDto()
                    {
                        Id = animal.Id,
                        Name = animal.Name,
                        Type = animal.Type,
                        CoatColor = animal.CoatColor,
                        BirthDate = animal.BirthDate,
                        HasMicrochip = animal.HasMicrochip,
                        MicrochipNumber = animal.MicrochipNumber,
                        OwnerName = animal.OwnerName,
                        OwnerSurname = animal.OwnerSurname
                    };

                    animalsRequest.Add(request);
                }

                return animalsRequest;
            }
            catch
            {
                return null;
            }
        }
        public async Task<GetAnimalRequestDto?> GetAnimalByIdAsync(Guid id)
        {
            try
            {
                var existingAnimal = await _context.Animals.FirstOrDefaultAsync(s => s.Id == id);

                if (existingAnimal == null)
                {
                    return null;
                }

                var animal = new GetAnimalRequestDto()
                {
                    Id = existingAnimal.Id,
                    Name = existingAnimal.Name,
                    Type = existingAnimal.Type,
                    CoatColor = existingAnimal.CoatColor,
                    BirthDate = existingAnimal.BirthDate,
                    HasMicrochip = existingAnimal.HasMicrochip,
                    MicrochipNumber = existingAnimal.MicrochipNumber,
                    OwnerName = existingAnimal.OwnerName,
                    OwnerSurname = existingAnimal.OwnerSurname
                };

                return animal;
            }
            catch
            {
                return null;
            }
        }
    }
}
