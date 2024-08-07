using FluentValidation;

namespace WebApplication5.Dtos.GroupDtos;

public class GroupCreateDto
{
    public string Name { get; set; }
    public int Limit { get; set; }
}

public class GroupCreateDtoValidator : AbstractValidator<GroupCreateDto>
{
    public GroupCreateDtoValidator()
    {
        RuleFor(g => g.Name).MaximumLength(10).MinimumLength(3);
        RuleFor(g => g.Limit).InclusiveBetween(1, 20);
    }
}
