using FluentValidation;

namespace WebApplication5.Dtos.StudentDtos;

public class StudentCreateDto
{
    public string Name { get; set; }
    public int Point { get; set; }
    public int GroupId { get; set; }
}

public class StudentCreateDtoValidator : AbstractValidator<StudentCreateDto>
{
    public StudentCreateDtoValidator()
    {
        RuleFor(s => s.Name).NotEmpty().MaximumLength(10);
        RuleFor(s => s.Point).InclusiveBetween(1, 100);
        RuleFor(s => s.GroupId).NotEmpty();
    }
}
