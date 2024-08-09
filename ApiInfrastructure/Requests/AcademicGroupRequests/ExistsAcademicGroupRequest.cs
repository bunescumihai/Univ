using AppCore.DataDB;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using AppCore.Models;
namespace Univ.Requests.EducationalGroupRequests;
public class ExistsAcademicGroupRequest : IRequest<bool>
{
    public string Name;
    public ExistsAcademicGroupRequest(string name)
    {
        Name = name;
    }

    internal class ExistsAcademicGroupsRequestHandler : IRequestHandler<ExistsAcademicGroupRequest, bool>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<ExistsAcademicGroupsRequestHandler> _logger;

        public ExistsAcademicGroupsRequestHandler(ILogger<ExistsAcademicGroupsRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<bool> Handle(ExistsAcademicGroupRequest request, CancellationToken cancellationToken)
        {
            var response = await _context.AcademicGroups.FirstOrDefaultAsync(x => x.Name == request.Name);
            
            if (response is null)
                return false;

            return true;
        }
    }
}
