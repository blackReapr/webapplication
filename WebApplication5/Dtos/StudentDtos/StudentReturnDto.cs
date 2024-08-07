namespace WebApplication5.Dtos.StudentDtos;

public class StudentReturnDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Point { get; set; }
    public int GroupId { get; set; }
    public GroupInStudentReturnDto Group { get; set; }
}

public class GroupInStudentReturnDto
{
    public string Name { get; set; }
    public int StudentsCount { get; set; }
}