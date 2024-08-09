using AppCore.DataDB;
using AppCore.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.DisciplineRequests;

public class GetDisciplineByIdRequest : IRequest<Discipline?>
{
    private readonly int _disciplineId;
    public GetDisciplineByIdRequest(int disciplineId)
    {
        _disciplineId = disciplineId;
    }

    internal class GetDisciplineByIdRequestHandler : IRequestHandler<GetDisciplineByIdRequest, Discipline?>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<GetDisciplineByIdRequestHandler> _logger;

        public GetDisciplineByIdRequestHandler(ILogger<GetDisciplineByIdRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Discipline?> Handle(GetDisciplineByIdRequest request, CancellationToken cancellationToken)
        {
            var response = await _context.Disciplines.FirstOrDefaultAsync(x => x.DisciplineId == request._disciplineId, cancellationToken);
            return response;
        }
    }
}
