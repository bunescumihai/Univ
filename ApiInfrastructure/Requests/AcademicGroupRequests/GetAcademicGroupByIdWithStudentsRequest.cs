using AppCore.DataDB;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using AppCore.Dto;
using AppCore.Models;

namespace Univ.Requests.EducationalGroupRequests;

public class GetAcademicGroupByIdWithStudentsRequest : IRequest<object?>
{
    public int AcademicGroupId;
    public GetAcademicGroupByIdWithStudentsRequest(int academicGroupId)
    {
        AcademicGroupId = academicGroupId;
    }

    internal class GetAcademicGroupByIdRequestWithStudentsHandler : IRequestHandler<GetAcademicGroupByIdWithStudentsRequest, object?>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<GetAcademicGroupByIdRequestWithStudentsHandler> _logger;

        public GetAcademicGroupByIdRequestWithStudentsHandler(ILogger<GetAcademicGroupByIdRequestWithStudentsHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<object?> Handle(GetAcademicGroupByIdWithStudentsRequest withStudentsRequest, CancellationToken cancellationToken)
        {
            var response = await _context.AcademicGroups.Select(
                    a => new
                    {
                        a.AcademicGroupId,
                        a.StudyYear,
                        a.Name
                    }
                    ).Where(x => x.AcademicGroupId == withStudentsRequest.AcademicGroupId).FirstOrDefaultAsync();
            return response;
        }
    }
}
