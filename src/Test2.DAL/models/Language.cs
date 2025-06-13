namespace Test2.DAL.models;

public class Language
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public virtual ICollection<Record> Records { get; set; } = new List<Record>();

}