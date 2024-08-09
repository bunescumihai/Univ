using AppCore.DataDB;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.DisciplineRequests;

public class DeleteDisciplineRequest : IRequest<bool>
{
    private readonly int _disciplineId;
    
    public DeleteDisciplineRequest(int disciplineId)
    {
        _disciplineId = disciplineId;
    }

    internal class DeleteDisciplineRequestHandler : IRequestHandler<DeleteDisciplineRequest, bool>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<DeleteDisciplineRequestHandler> _logger;

        public DeleteDisciplineRequestHandler(ILogger<DeleteDisciplineRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<bool> Handle(DeleteDisciplineRequest request, CancellationToken cancellationToken)
        {
            var result = await _context.Disciplines.FirstOrDefaultAsync(x => x.DisciplineId == request._disciplineId, cancellationToken);

            if (result is null)
                return false;
            
            try
            {
                _context.Disciplines.Remove(result);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
