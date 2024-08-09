using AppCore.DataDB;
using AppCore.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.SpecialityRequests;

public class GetSpecialitiesRequest : IRequest<List<Speciality>>
{
    internal class GetSpecialitiesRequestHandler : IRequestHandler<GetSpecialitiesRequest, List<Speciality>>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<GetSpecialitiesRequestHandler> _logger;

        public GetSpecialitiesRequestHandler(ILogger<GetSpecialitiesRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<Speciality>> Handle(GetSpecialitiesRequest request, CancellationToken cancellationToken)
        {
            var educationalInstitutions  = await _context.Specialities.ToListAsync();
            return educationalInstitutions;
        }

    }
}
