using AppCore.DataDB;
using AppCore.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.EducationalGroupRequests;

public class GetAcademicGroupsRequest : IRequest<List<AcademicGroup>>
{
    internal class GetAcademicGroupsRequestHandler : IRequestHandler<GetAcademicGroupsRequest, List<AcademicGroup>>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<GetAcademicGroupsRequestHandler> _logger;

        public GetAcademicGroupsRequestHandler(ILogger<GetAcademicGroupsRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<AcademicGroup>> Handle(GetAcademicGroupsRequest request, CancellationToken cancellationToken)
        {
            var academicGroups = await _context.AcademicGroups.ToListAsync();
            return academicGroups;
        }
    }
}
