using System.ComponentModel.DataAnnotations;
using Task = Test2.DAL.models.Task;

namespace Test2.Logic.DTO;

public class CreateRecordDTO
{
    [Required]
    public int LanguageId { get; set; }
    
    [Required]
    public int StudentId { get; set; }
    
    [Required]
    public int TaskId { get; set; }
    
    
    public TaskDTO Task { get; set; }
    
    [Required]
    public long ExecutionTime { get; set; }
    
    [Required]
    public DateTime CreatedAt { get; set; }
}