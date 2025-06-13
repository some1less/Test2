using System.ComponentModel.DataAnnotations;

namespace Test2.Logic.DTO;

public class TaskDTO
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Description { get; set; }
}