using AppCore.DataDB;
using AppCore.Models;
using AppCore.Models.Enum;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.EducationalGroupRequests;

public class CreateAcademicGroupRequest : IRequest<AcademicGroup?>
{
    private string _name;
    private StudyYear _studyYear;
    private int _specialityId;
    
    public CreateAcademicGroupRequest(string name, StudyYear studyYear, int specialityId)
    {
        _name = name;
        _studyYear = studyYear;
        _specialityId = specialityId;
    }

    internal class CreateAcademicGroupRequestHandler : IRequestHandler<CreateAcademicGroupRequest, AcademicGroup?>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<CreateAcademicGroupRequestHandler> _logger;

        public CreateAcademicGroupRequestHandler(ILogger<CreateAcademicGroupRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<AcademicGroup?> Handle(CreateAcademicGroupRequest request, CancellationToken cancellationToken)
        {
            AcademicGroup academicGroup = new AcademicGroup() { Name = request._name, StudyYear = request._studyYear, SpecialityId = request._specialityId};

            try
            {
                await _context.AcademicGroups.AddAsync(academicGroup);
                await _context.SaveChangesAsync();
                return academicGroup;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
