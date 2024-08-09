using AppCore.DataDB;
using AppCore.Models;
using AppCore.Models.Enum;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.EducationalGroupRequests;
public class GetAcademicGroupsByYearRequest : IRequest<List<AcademicGroup>>
{

    private StudyYear _studyYear;
    public GetAcademicGroupsByYearRequest(StudyYear studyYear)
    {
        _studyYear = studyYear;
    }

    internal class GetAcademicGroupsByYearRequestHandler : IRequestHandler<GetAcademicGroupsByYearRequest, List<AcademicGroup>>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<GetAcademicGroupsByYearRequestHandler> _logger;

        public GetAcademicGroupsByYearRequestHandler(ILogger<GetAcademicGroupsByYearRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<AcademicGroup>> Handle(GetAcademicGroupsByYearRequest request, CancellationToken cancellationToken)
        {
            var academicGroups = await _context.AcademicGroups.Where(x => x.StudyYear == request._studyYear).ToListAsync();
            return academicGroups;
        }
    }
}
