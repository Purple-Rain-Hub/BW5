using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectBW5.DTOs.Animal;
using ProjectBW5.DTOs.Registry;
using ProjectBW5.Services.VetServices;

namespace ProjectBW5.Controllers.VeterinaryControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin, Veterinary")]
    public class RegistryController : ControllerBase
    {
        private readonly RegistryService _registryService;
        public RegistryController(RegistryService registryService)
        {
            _registryService = registryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnimal([FromBody] CreateAnimalDto createAnimalDto)
        {
            try
            {
                var success = await _registryService.CreateAnimalAsync(createAnimalDto);
                if (success)
                {
                    return Ok(new { message = "Animal successfully registered!" });
                }
                else
                {
                    return BadRequest(new { message = "Animal is already registered or something went wrong." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAnimal([FromQuery] Guid id, [FromBody] CreateAnimalDto updateAnimal)
        {
            try
            {
                var result = await _registryService.UpdateAnimalAsync(id, updateAnimal);

                return result ? Ok(new UpdateAnimalResponseDto() { Message = "Animal info updated" })
                    : BadRequest(new UpdateAnimalResponseDto() { Message = "Something went wrong" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAnimal(Guid id)
        {
            try
            {
                var result = await _registryService.DeleteAnimalAsync(id);

                return result ? Ok(new UpdateAnimalResponseDto() { Message = "Animal info deleted" })
                    : BadRequest(new UpdateAnimalResponseDto() { Message = "Something went wrong" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAnimals()
        {
            try
            {
                var animals = await _registryService.GetAnimalsAsync();

                if (animals == null)
                {
                    return BadRequest(new
                    {
                        message = "Something went wrong"
                    });
                }

                var count = animals.Count();

                var text = count == 1 ? $"{count} animal found" : $"{count} animals found";

                return Ok(new
                GetAnimalResponseDto()
                {
                    Message = text,
                    Animals = animals
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAnimalById(Guid id)
        {
            try
            {
                var result = await _registryService.GetAnimalByIdAsync(id);

                return result != null ? Ok(new { message = "Animal found", Animal = result })
                    : BadRequest(new { message = "Something went wrong" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
