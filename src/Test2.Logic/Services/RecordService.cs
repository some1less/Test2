using Microsoft.EntityFrameworkCore;
using Test2.DAL.context;
using Test2.DAL.models;
using Test2.Logic.DTO;

namespace Test2.Logic.Services;

public class RecordService : IRecordService
{
    private readonly RecordManiaContext _context;

    public RecordService(RecordManiaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RecordDTO?>> GetAllRecordsAsync()
    {
        var records = await _context.Records
            .Include(r => r.Student)
            .Include(r => r.Task).Include(record => record.Language)
            .ToListAsync();

        if (records.Count == 0) return null;
        
        var dtos = new List<RecordDTO>();
        // mapping :>
        foreach (var record in records)
        {
            dtos.Add(new RecordDTO()
            {
                Id = record.Id,
                Language = record.Language,
                Task = record.Task,
                Student = record.Student,
                ExecutionTime = record.ExecutionTime,
                Created = record.CreatedAt
            });
        }
        
        return dtos.OrderByDescending(r => r.Created).ThenBy(r => r.Student.LastName);
    }

    public async Task<Record> CreateRecordAsync(CreateRecordDTO dto)
    {
        var language = await _context.Languages.FirstOrDefaultAsync(l => l.Id == dto.LanguageId);
        if (language == null) throw new KeyNotFoundException($"Language with id={dto.LanguageId} not found");
        
        var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == dto.StudentId);
        if (student == null) throw new KeyNotFoundException($"Student with id={dto.StudentId} not found");

        var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == dto.TaskId);
        if (task == null)
        {

            var taskName = dto.Task.Name;
            var taskDesc = dto.Task.Description;
            
            var Task = await _context.Tasks.FirstOrDefaultAsync(t => t.Name == taskName && t.Description == taskDesc);
            if (Task == null) throw new KeyNotFoundException($"Task with name={taskName} and desc={taskDesc} not found");
        }
        else
        {
            throw new KeyNotFoundException($"Task with id={dto.TaskId} not found");
        }

        Record record = new Record()
        {
            LanguageId = dto.LanguageId,
            TaskId = dto.TaskId,
            StudentId = dto.StudentId,
            Task = task,
            ExecutionTime = dto.ExecutionTime,
            CreatedAt = dto.CreatedAt,
        };
        
        _context.Records.Add(record);
        await _context.SaveChangesAsync();
        
        return record;
    }
}