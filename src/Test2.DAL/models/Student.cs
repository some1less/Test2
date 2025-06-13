namespace Test2.DAL.models;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    
    public virtual ICollection<Record> Records { get; set; } = new List<Record>();

}