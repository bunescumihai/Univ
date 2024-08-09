using AppCore.DataDB;
using AppCore.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.EducationalInstitutionRequests;

public class GetEducationalInstitutionsRequest : IRequest<List<EducationalInstitution>>
{
    internal class GetEducationalInstitutionsRequestHandler : IRequestHandler<GetEducationalInstitutionsRequest, List<EducationalInstitution>>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<GetEducationalInstitutionsRequestHandler> _logger;

        public GetEducationalInstitutionsRequestHandler(ILogger<GetEducationalInstitutionsRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<EducationalInstitution>> Handle(GetEducationalInstitutionsRequest request, CancellationToken cancellationToken)
        {
            var educationalInstitutions  = await _context.EducationalInstitutions.ToListAsync();
            return educationalInstitutions;
        }

    }
}
