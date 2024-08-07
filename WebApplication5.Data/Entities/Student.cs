namespace WebApplication5.Data.Entities;

public class Student : BaseEntity
{
    public string Name { get; set; }
    public int Point { get; set; }
    public int GroupId { get; set; }
    public Group Group { get; set; }
}
