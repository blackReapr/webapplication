namespace WebApplication5.Data.Entities;

public class Group : BaseEntity
{
    public string Name { get; set; }
    public int Limit { get; set; }
    public List<Student> Students { get; set; }
}
