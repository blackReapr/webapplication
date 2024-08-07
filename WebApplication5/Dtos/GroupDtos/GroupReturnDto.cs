namespace WebApplication5.Dtos.GroupDtos;

public class GroupReturnDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Limit { get; set; }
    public List<StudentInGroupReturnDto> Students { get; set; }
}


public class StudentInGroupReturnDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Point { get; set; }
}