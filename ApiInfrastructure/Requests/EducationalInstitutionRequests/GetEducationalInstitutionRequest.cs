using AppCore.DataDB;
using AppCore.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.EducationalInstitutionRequests;

public class GetEducationalInstitutionRequest : IRequest<EducationalInstitution?>
{
    private int _educationalInstitutionId;

    public GetEducationalInstitutionRequest(int educationalInstitutionId)
    {
        _educationalInstitutionId = educationalInstitutionId;
    }
    internal class GetEducationalInstitutionRequestHandler : IRequestHandler<GetEducationalInstitutionRequest, EducationalInstitution?>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<GetEducationalInstitutionRequestHandler> _logger;

        public GetEducationalInstitutionRequestHandler(ILogger<GetEducationalInstitutionRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<EducationalInstitution?> Handle(GetEducationalInstitutionRequest request, CancellationToken cancellationToken)
        {
            var educationalInstitutions  = await _context.EducationalInstitutions
                .Include(e => e.Specialities)
                .Include(e => e.ParentEducationalInstitution)
                .Include(e=> e.ChildEducationalInstitutions)
                .FirstOrDefaultAsync(x => x.EducationalInstitutionId == request._educationalInstitutionId);
            return educationalInstitutions;
        }

    }
}
