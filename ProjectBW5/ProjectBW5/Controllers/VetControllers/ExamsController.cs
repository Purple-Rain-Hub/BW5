using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectBW5.DTOs.Examination;
using ProjectBW5.DTOs.Registry;
using ProjectBW5.Services.VetServices;

namespace ProjectBW5.Controllers.VetControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Veterinary")]
    public class ExamsController : ControllerBase
    {
        private readonly ExamsService _examsService;
        public ExamsController(ExamsService examsService)
        {
            _examsService = examsService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateExam([FromQuery] Guid id, [FromBody] CreateExamDto createExamDto)
        {
            try
            {
                var success = await _examsService.CreateExamAsync(id, createExamDto);
                if (success)
                {
                    return Ok(new { message = "Exam successfully registered!" });
                }
                else
                {
                    return BadRequest(new { message = "Exam is already registered or something went wrong." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateExam([FromQuery] Guid id, [FromBody] CreateExamDto updateExam)
        {
            try
            {
                var result = await _examsService.UpdateExamAsync(id, updateExam);

                return result ? Ok(new UpdateExamResponseDto() { Message = "Exam info updated" })
                    : BadRequest(new UpdateExamResponseDto() { Message = "Something went wrong" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteExam(Guid id)
        {
            try
            {
                var result = await _examsService.DeleteExamAsync(id);

                return result ? Ok(new UpdateExamResponseDto() { Message = "Exam info deleted" })
                    : BadRequest(new UpdateExamResponseDto() { Message = "Something went wrong" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetExams()
        {
            try
            {
                var exams = await _examsService.GetExamsAsync();

                if (exams == null)
                {
                    return BadRequest(new
                    {
                        message = "Something went wrong"
                    });
                }

                var count = exams.Count();

                var text = count == 1 ? $"{count} exam found" : $"{count} exams found";

                return Ok(new
                GetExamResponseDto()
                {
                    Message = text,
                    Exams = exams
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetExamById(Guid id)
        {
            try
            {
                var result = await _examsService.GetExamByIdAsync(id);

                return result != null ? Ok(new { message = "Exam found", Exam = result })
                    : BadRequest(new { message = "Something went wrong" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("Animal/Exams/{id:guid}")]
        public async Task<IActionResult> GetAnimalExams(Guid id)
        {
            try
            {
                var exams = await _examsService.GetAnimalExamsAsync(id);

                if (exams == null)
                {
                    return BadRequest(new
                    {
                        message = "Something went wrong"
                    });
                }

                var count = exams.Count();

                var text = count == 1 ? $"{count} exam found" : $"{count} exams found";

                return Ok(new
                GetExamResponseDto()
                {
                    Message = text,
                    Exams = exams
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
