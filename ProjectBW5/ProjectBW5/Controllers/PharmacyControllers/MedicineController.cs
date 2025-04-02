using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectBW5.DTOs.Medicine;
using ProjectBW5.Services;

namespace ProjectBW5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicineController : ControllerBase
    {
        private readonly MedicineService _medicineService;

        public MedicineController(MedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MedicineReadDto>>> GetAll()
        {
            var medicines = await _medicineService.GetAllAsync();
            return Ok(medicines);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MedicineReadDto>> GetById(Guid id)
        {
            var medicine = await _medicineService.GetByIdAsync(id);
            if (medicine == null)
                return NotFound("Medicine not found.");

            return Ok(medicine);
        }

        [HttpPost]
        [Authorize(Roles = "Pharmacist,Admin")]
        public async Task<ActionResult> Create([FromBody] MedicineCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _medicineService.AddAsync(dto);
            return Ok("Medicine created successfully.");
        }

        [HttpPut]
        [Authorize(Roles = "Pharmacist,Admin")]
        public async Task<ActionResult> Update([FromBody] MedicineUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _medicineService.UpdateAsync(dto);
            if (!result)
                return NotFound("Medicine not found.");

            return Ok("Medicine updated successfully. (Name, Company and Usage cannot be modified)");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _medicineService.DeleteAsync(id);
            if (!result)
                return NotFound("Medicine not found.");

            return Ok("Medicine deleted successfully.");
        }

        [HttpGet("location/{id:guid}")]
        [Authorize(Roles = "Pharmacist,Admin")]
        public async Task<ActionResult<MedicineLocationDto>> GetLocation(Guid id)
        {
            var result = await _medicineService.GetLocationAsync(id);
            if (result == null)
                return NotFound("Medicine not found.");

            return Ok(result);
        }

        [HttpGet("search")]
        [Authorize(Roles = "Pharmacist,Admin")]
        public async Task<ActionResult<List<MedicineReadDto>>> Search(
            [FromQuery] string? name,
            [FromQuery] string? supplierCompany,
            [FromQuery] string? usageList)
        {
            var results = await _medicineService.SearchAsync(name, supplierCompany, usageList);
            return Ok(results);
        }


    }
}
