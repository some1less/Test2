using System.Numerics;
using System.Runtime.InteropServices.JavaScript;

namespace Test2.DAL.models;

public class Record
{
    public int Id { get; set; }
    
    public int LanguageId { get; set; }
    public Language Language { get; set; } = null!;
    
    public int TaskId { get; set; }
    public Task Task { get; set; } = null!;
    
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
    
    public long ExecutionTime { get; set; }
    public DateTime CreatedAt { get; set; }


}