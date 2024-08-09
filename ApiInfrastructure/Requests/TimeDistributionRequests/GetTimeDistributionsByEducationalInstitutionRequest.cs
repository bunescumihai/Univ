using AppCore.DataDB;
using AppCore.Models;
using AppCore.Models.Enum;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.TimeDistributionRequests;
public class GetTimeDistributionsByEducationalInstitutionRequest : IRequest<List<TimeDistribution>>
{

    private int _educationalInstitutionId;
    public GetTimeDistributionsByEducationalInstitutionRequest(int educationalInstitutionId)
    {
        _educationalInstitutionId = educationalInstitutionId;
    }

    internal class GetTimeDistributionsByEducationalInstitutionRequestHandler : IRequestHandler<GetTimeDistributionsByEducationalInstitutionRequest, List<TimeDistribution>>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<GetTimeDistributionsByEducationalInstitutionRequestHandler> _logger;

        public GetTimeDistributionsByEducationalInstitutionRequestHandler(ILogger<GetTimeDistributionsByEducationalInstitutionRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<TimeDistribution>> Handle(GetTimeDistributionsByEducationalInstitutionRequest request, CancellationToken cancellationToken)
        {
            var rs = await _context.TimeDistributions.Where(x => x.EducationalInstitutionId == request._educationalInstitutionId).ToListAsync();
            return rs;
        }
    }
}
