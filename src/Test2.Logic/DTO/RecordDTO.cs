using Test2.DAL.models;
using Task = Test2.DAL.models.Task;

namespace Test2.Logic.DTO;

public class RecordDTO
{
    public int Id { get; set; }
    public Language Language { get; set; }
    public Task Task { get; set; }
    public Student Student { get; set; }
    
    public long ExecutionTime { get; set; }
    public DateTime Created { get; set; }
}