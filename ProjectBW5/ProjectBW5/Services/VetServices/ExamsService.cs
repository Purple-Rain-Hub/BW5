using Microsoft.EntityFrameworkCore;
using ProjectBW5.Data;
using ProjectBW5.DTOs.Examination;
using ProjectBW5.Models;

namespace ProjectBW5.Services.VetServices
{
    public class ExamsService
    {
        private readonly BW5DbContext _context;

        public ExamsService(BW5DbContext context)
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

        public async Task<bool> CreateExamAsync(Guid id, CreateExamDto createExam)
        {
            try
            {
                var exam = new Examination()
                {
                    ExamDate = createExam.ExamDate,
                    ExamObjective = createExam.ExamObjective,
                    ExamTreatment = createExam.ExamTreatment,
                    AnimalId = id,
                    VetId = createExam.VetId
                };

                _context.Examinations.Add(exam);
                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> UpdateExamAsync(Guid id, CreateExamDto updateExam)
        {
            try
            {
                var existingExam = await _context.Examinations.FirstOrDefaultAsync(a => a.Id == id);

                if (existingExam == null)
                {
                    return false;
                }

                existingExam.ExamDate = updateExam.ExamDate;
                existingExam.ExamObjective = updateExam.ExamObjective;
                existingExam.ExamTreatment = updateExam.ExamTreatment;
                existingExam.AnimalId = id;
                existingExam.VetId = updateExam.VetId;

                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> DeleteExamAsync(Guid id)
        {
            try
            {
                var exam = await _context.Examinations.FirstOrDefaultAsync(a => a.Id == id);

                if (exam == null)
                {
                    return false;
                }

                _context.Examinations.Remove(exam);

                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }
        public async Task<List<GetExamRequestDto>?> GetExamsAsync()
        {
            try
            {
                var exams = await _context.Examinations.Include(e=> e.Animal).Include(e=> e.User).ToListAsync();

                var examsRequest = new List<GetExamRequestDto>();

                foreach (var exam in exams)
                {
                    var request = new GetExamRequestDto()
                    {
                        Id = exam.Id,
                        ExamDate = exam.ExamDate,
                        ExamObjective = exam.ExamObjective,
                        ExamTreatment = exam.ExamTreatment,
                        AnimalId = exam.AnimalId,
                        AnimalName = exam.Animal.Name,
                        OwnerName = exam.Animal.OwnerName,
                        OwnerSurname = exam.Animal.OwnerSurname,
                        VetId = exam.VetId,
                        VetName = exam.User.Email
                    };

                    examsRequest.Add(request);
                }

                return examsRequest;
            }
            catch
            {
                return null;
            }
        }
        public async Task<GetExamRequestDto?> GetExamByIdAsync(Guid id)
        {
            try
            {
                var existingExam = await _context.Examinations.Include(e => e.Animal).Include(e => e.User).FirstOrDefaultAsync(s => s.Id == id);

                if (existingExam == null)
                {
                    return null;
                }

                var exam = new GetExamRequestDto()
                {
                    Id = existingExam.Id,
                    ExamDate = existingExam.ExamDate,
                    ExamObjective = existingExam.ExamObjective,
                    ExamTreatment = existingExam.ExamTreatment,
                    AnimalId = existingExam.AnimalId,
                    AnimalName = existingExam.Animal.Name,
                    OwnerName = existingExam.Animal.OwnerName,
                    OwnerSurname = existingExam.Animal.OwnerSurname,
                    VetId = existingExam.VetId,
                    VetName = existingExam.User.Email
                };

                return exam;
            }
            catch
            {
                return null;
            }
        }
    }
}
