using AppCore.DataDB;
using AppCore.Dto;
using FluentValidation;

namespace Univ.ModelValidators;

public class CreateAcademicGroupDtoValidator : AbstractValidator<CreateAcademicGroupDto>
{

    private readonly PeDbContext _context;
    
    public CreateAcademicGroupDtoValidator(PeDbContext context)
    {
        _context = context;

        RuleFor(academicGroup => academicGroup.Name)
            .Matches("^\\w{2,3}-\\d{2,3}$")
            .NotNull()
            .MustAsync(IsNameUnique)
            .WithMessage($"The academic group already exists");
    }

    private async Task<bool> IsNameUnique(string name, CancellationToken cancellationToken)
    {
        var result = _context.AcademicGroups.FirstOrDefault(x => x.Name == name);
        
        return result == null;
    }
}