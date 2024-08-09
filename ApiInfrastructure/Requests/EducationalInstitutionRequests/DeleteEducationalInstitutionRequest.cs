using AppCore.DataDB;
using AppCore.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.EducationalInstitutionRequests;

public class DeleteEducationalInstitutionRequest : IRequest<bool>
{
    private int _educationalInstitutionId;
    public DeleteEducationalInstitutionRequest(int educationalInstitutionId)
    {
        _educationalInstitutionId = educationalInstitutionId;
    }
    internal class DeleteEducationalInstitutionRequestHandler : IRequestHandler<DeleteEducationalInstitutionRequest, bool>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<DeleteEducationalInstitutionRequestHandler> _logger;

        public DeleteEducationalInstitutionRequestHandler(ILogger<DeleteEducationalInstitutionRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<bool> Handle(DeleteEducationalInstitutionRequest request, CancellationToken cancellationToken)
        {
            var result = await _context.EducationalInstitutions.FirstOrDefaultAsync(x => x.EducationalInstitutionId == request._educationalInstitutionId);
            
            if (result is null)
                return false;

            _context.Remove(result);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return false;
            }
            
            
            return true;
        }

    }
}
