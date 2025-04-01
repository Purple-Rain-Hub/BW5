using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectBW5.DTOs.Hospitalization;
using ProjectBW5.Services.VetServices;

namespace ProjectBW5.Controllers.VetControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Veterinary")]
    public class HospitalController : ControllerBase
    {
        private readonly HospitalService _hospitalService;
        public HospitalController(HospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHospital([FromQuery] Guid id, [FromBody] CreateHospitalDto createHospitalDto)
        {
            try
            {
                if (createHospitalDto.EndDate != null && createHospitalDto.EndDate <= createHospitalDto.StartDate)
                {
                    return BadRequest(new { Message = "End date invalid" });
                }
                var success = await _hospitalService.CreateHospitalAsync(id, createHospitalDto);
                if (success)
                {
                    return Ok(new { message = "Hospital successfully registered!" });
                }
                else
                {
                    return BadRequest(new { message = "Hospital is already registered or something went wrong." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHospital([FromQuery] Guid id, [FromBody] CreateHospitalDto updateHospital)
        {
            try
            {
                if(updateHospital.EndDate != null && updateHospital.EndDate <= updateHospital.StartDate)
                {
                    return BadRequest(new UpdateHospitalResponseDto() { Message = "End date invalid" });
                }
                var result = await _hospitalService.UpdateHospitalAsync(id, updateHospital);

                return result ? Ok(new UpdateHospitalResponseDto() { Message = "Hospital info updated" })
                    : BadRequest(new UpdateHospitalResponseDto() { Message = "Something went wrong" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteHospital(Guid id)
        {
            try
            {
                var result = await _hospitalService.DeleteHospitalAsync(id);

                return result ? Ok(new UpdateHospitalResponseDto() { Message = "Hospital info deleted" })
                    : BadRequest(new UpdateHospitalResponseDto() { Message = "Something went wrong" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetHospitals()
        {
            try
            {
                var hospitals = await _hospitalService.GetHospitalsAsync();

                if (hospitals == null)
                {
                    return BadRequest(new
                    {
                        message = "Something went wrong"
                    });
                }

                var count = hospitals.Count();

                var text = count == 1 ? $"{count} animal found" : $"{count} animals found";

                return Ok(new
                GetHospitalResponseDto()
                {
                    Message = text,
                    Hospitals = hospitals
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetHospitalById(Guid id)
        {
            try
            {
                var result = await _hospitalService.GetHospitalByIdAsync(id);

                return result != null ? Ok(new { message = "animal found", Hospital = result })
                    : BadRequest(new { message = "Something went wrong" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("EndDate/{id:guid}")]
        public async Task<IActionResult> EndHospital(Guid id, [FromBody] DateTime endDate)
        {
            try
            {
                var result = await _hospitalService.EndHospitalAsync(id, endDate);

                return result ? Ok(new UpdateHospitalResponseDto() { Message = "Hospital info updated" })
                    : BadRequest(new UpdateHospitalResponseDto() { Message = "Something went wrong or end date is invalid" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
