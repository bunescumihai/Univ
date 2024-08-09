using AppCore.DataDB;
using AppCore.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.DisciplineRequests;

public class GetDisciplinesRequest : IRequest<List<Discipline>>
{
    internal class GetDisciplinesRequestHandler : IRequestHandler<GetDisciplinesRequest, List<Discipline>>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<GetDisciplinesRequestHandler> _logger;

        public GetDisciplinesRequestHandler(ILogger<GetDisciplinesRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<Discipline>> Handle(GetDisciplinesRequest request, CancellationToken cancellationToken)
        {
            var disciplines  = await _context.Disciplines.ToListAsync();
            return disciplines;
        }
    }
}
