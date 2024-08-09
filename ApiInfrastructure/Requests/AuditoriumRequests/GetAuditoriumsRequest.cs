using AppCore.DataDB;
using AppCore.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.AuditoriumRequests;

public class GetAuditoriumsRequest : IRequest<List<Auditorium>>
{
    internal class GetAuditoriumsRequestHandler : IRequestHandler<GetAuditoriumsRequest, List<Auditorium>>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<GetAuditoriumsRequestHandler> _logger;

        public GetAuditoriumsRequestHandler(ILogger<GetAuditoriumsRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<Auditorium>> Handle(GetAuditoriumsRequest request, CancellationToken cancellationToken)
        {
            var auditoriums  = await _context.Auditoriums.ToListAsync();
            return auditoriums;
        }
    }
}
