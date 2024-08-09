using AppCore.DataDB;
using AppCore.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using Univ.Dto.EducationalInstitutionDtos;
using Univ.Requests.AuditoriumRequests;

namespace Univ.Requests.EducationalInstitutionRequests;

public class CreateEducationalInstitutionRequest : IRequest<EducationalInstitution?>
{
    private EducationalInstitution _educationalInstitution;
    
    public CreateEducationalInstitutionRequest(EducationalInstitution educationalInstitution)
    {
        _educationalInstitution = educationalInstitution;
    }

    internal class CreateEducationalInstitutionRequestHandler : IRequestHandler<CreateEducationalInstitutionRequest, EducationalInstitution?>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<CreateEducationalInstitutionRequestHandler> _logger;

        public CreateEducationalInstitutionRequestHandler(ILogger<CreateEducationalInstitutionRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<EducationalInstitution?> Handle(CreateEducationalInstitutionRequest request, CancellationToken cancellationToken)
        {
            var response =  await _context.EducationalInstitutions.AddAsync(request._educationalInstitution);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return null;
            }

            return request._educationalInstitution;
        }
    }
}
