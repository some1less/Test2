using System.Text.Json.Serialization;

namespace Test2.DAL.models;

public class Task
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    [JsonIgnore]
    public virtual ICollection<Record> Records { get; set; } = new List<Record>();

}