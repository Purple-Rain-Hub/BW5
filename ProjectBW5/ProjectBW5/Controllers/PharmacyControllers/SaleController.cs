using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectBW5.DTOs.Sale;
using ProjectBW5.Services;

namespace ProjectBW5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly SaleService _saleService;

        public SaleController(SaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        [Authorize(Roles = "Pharmacist,Admin")]
        public async Task<ActionResult<List<SaleReadDto>>> GetAll()
        {
            var sales = await _saleService.GetAllAsync();
            return Ok(sales);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Pharmacist,Admin")]
        public async Task<ActionResult<SaleReadDto>> GetById(Guid id)
        {
            var sale = await _saleService.GetByIdAsync(id);
            if (sale == null)
                return NotFound("Sale not found.");

            return Ok(sale);
        }

        [HttpPost]
        [Authorize(Roles = "Pharmacist,Admin")]
        public async Task<ActionResult> Create([FromBody] SaleCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var saleId = await _saleService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = saleId }, null);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Update([FromBody] SaleUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _saleService.UpdateAsync(dto);
            if (!result)
                return NotFound("Sale not found.");

            return Ok("Sale updated successfully.");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _saleService.DeleteAsync(id);
            if (!result)
                return NotFound("Sale not found.");

            return Ok("Sale deleted successfully.");
        }
    }
}
