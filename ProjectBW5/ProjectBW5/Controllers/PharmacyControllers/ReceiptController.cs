﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectBW5.DTOs.Receipt;
using ProjectBW5.Services;

namespace ProjectBW5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceiptController : ControllerBase
    {
        private readonly ReceiptService _receiptService;

        public ReceiptController(ReceiptService receiptService)
        {
            _receiptService = receiptService;
        }

        [HttpGet]
        [Authorize(Roles = "Pharmacist,Admin")]
        public async Task<ActionResult<List<ReceiptReadDto>>> GetAll()
        {
            var receipts = await _receiptService.GetAllAsync();
            return Ok(receipts);
        }

        [HttpGet("{medicineId:guid}/{saleId:guid}")]
        [Authorize(Roles = "Pharmacist,Admin")]
        public async Task<ActionResult<ReceiptReadDto>> Get(Guid medicineId, Guid saleId)
        {
            var receipt = await _receiptService.GetAsync(medicineId, saleId);
            if (receipt == null)
                return NotFound("Receipt not found.");

            return Ok(receipt);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create([FromBody] ReceiptCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = await _receiptService.AddAsync(dto);
            if (!success)
            {
                return BadRequest("Cannot complete receipt: either the medicine or sale was not found, " +
                                  "the receipt already exists, the medicine is not available, or a prescription was required but not provided.");
            }

            return Ok("Receipt successfully created.");
        }

        [HttpDelete("{medicineId:guid}/{saleId:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(Guid medicineId, Guid saleId)
        {
            var success = await _receiptService.DeleteAsync(medicineId, saleId);
            if (!success)
                return NotFound("Receipt not found or already deleted.");

            return Ok("Receipt successfully deleted.");
        }

        [HttpGet("total/{saleId:guid}")]
        [Authorize(Roles = "Pharmacist,Admin")]
        public async Task<ActionResult<decimal>> GetTotal(Guid saleId)
        {
            var total = await _receiptService.CalculateTotalSaleAmountAsync(saleId);
            return Ok(total);
        }
    }
}
