using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectBW5.DTOs.StrayHospital;
using ProjectBW5.Services.VetServices;

namespace ProjectBW5.Controllers.VetControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StrayHospitalController : ControllerBase
    {
        private readonly StrayHospitalService _strayHospitalService;
        public StrayHospitalController(StrayHospitalService strayHospitalService)
        {
            _strayHospitalService = strayHospitalService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Veterinary")]
        public async Task<IActionResult> CreateStrayHospital([FromBody] CreateStrayHospitalDto createStrayHospitalDto)
        {
            try
            {
                if (createStrayHospitalDto.EndDate != null && createStrayHospitalDto.EndDate <= createStrayHospitalDto.StartDate)
                {
                    return BadRequest(new { Message = "End date invalid" });
                }
                var success = await _strayHospitalService.CreateStrayHospitalAsync(createStrayHospitalDto);
                if (success)
                {
                    return Ok(new { message = "Stray successfully registered!" });
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
        [Authorize(Roles = "Admin, Veterinary")]
        public async Task<IActionResult> UpdateStrayHospital([FromQuery] Guid id, [FromBody] CreateStrayHospitalDto updateStrayHospital)
        {
            try
            {
                if (updateStrayHospital.EndDate != null && updateStrayHospital.EndDate <= updateStrayHospital.StartDate)
                {
                    return BadRequest(new UpdateStrayHospitalResponseDto() { Message = "End date invalid" });
                }
                var result = await _strayHospitalService.UpdateStrayHospitalAsync(id, updateStrayHospital);

                return result ? Ok(new UpdateStrayHospitalResponseDto() { Message = "Stray animal info updated" })
                    : BadRequest(new UpdateStrayHospitalResponseDto() { Message = "Something went wrong" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Admin, Veterinary")]
        public async Task<IActionResult> DeleteStrayHospital(Guid id)
        {
            try
            {
                var result = await _strayHospitalService.DeleteStrayHospitalAsync(id);

                return result ? Ok(new UpdateStrayHospitalResponseDto() { Message = "Stray animal info deleted" })
                    : BadRequest(new UpdateStrayHospitalResponseDto() { Message = "Something went wrong" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Veterinary")]
        public async Task<IActionResult> GetStrayHospitals()
        {
            try
            {
                var strayHospitals = await _strayHospitalService.GetStrayHospitalsAsync();

                if (strayHospitals == null)
                {
                    return BadRequest(new
                    {
                        message = "Something went wrong"
                    });
                }

                var count = strayHospitals.Count();

                var text = count == 1 ? $"{count} stray hospital found" : $"{count} stray hospitals found";

                return Ok(new
                GetStrayHospitalResponseDto()
                {
                    Message = text,
                    StrayHospitals = strayHospitals
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        [Authorize(Roles = "Admin, Veterinary")]
        public async Task<IActionResult> GetStrayHospitalById(Guid id)
        {
            try
            {
                var result = await _strayHospitalService.GetStrayHospitalByIdAsync(id);

                return result != null ? Ok(new { message = "stray hospital found", StrayHospital = result })
                    : BadRequest(new { message = "Something went wrong" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("EndDate/{id:guid}")]
        [Authorize(Roles = "Admin, Veterinary")]
        public async Task<IActionResult> EndStrayHospital(Guid id, [FromBody] DateTime endDate)
        {
            try
            {
                var result = await _strayHospitalService.EndStrayHospitalAsync(id, endDate);

                return result ? Ok(new UpdateStrayHospitalResponseDto() { Message = "Stray hospital info updated" })
                    : BadRequest(new UpdateStrayHospitalResponseDto() { Message = "Something went wrong or end date is invalid" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("Active")]
        [Authorize(Roles = "Admin, Veterinary")]
        public async Task<IActionResult> GetActiveStrayHospitals()
        {
            try
            {
                var strayHospitals = await _strayHospitalService.GetActiveStrayHospitalsAsync();

                if (strayHospitals == null)
                {
                    return BadRequest(new
                    {
                        message = "Something went wrong"
                    });
                }

                var count = strayHospitals.Count();

                var text = count == 1 ? $"{count} active stray hospital found" : $"{count} active stray hospitals found";

                return Ok(new
                GetStrayHospitalResponseDto()
                {
                    Message = text,
                    StrayHospitals = strayHospitals
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("Microchip")]
        public async Task<IActionResult> GetStrayHospitalByMicrochip([FromQuery]int microchipNumber)
        {
            try
            {
                var result = await _strayHospitalService.GetStrayHospitalByMicrochipAsync(microchipNumber);

                return result != null ? Ok(new { message = "stray hospital found", StrayHospital = result })
                    : BadRequest(new { message = "Something went wrong or there's no animal with that number" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
