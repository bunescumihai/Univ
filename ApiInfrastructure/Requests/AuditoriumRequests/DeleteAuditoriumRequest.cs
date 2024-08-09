using AppCore.DataDB;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace Univ.Requests.AuditoriumRequests;

public class DeleteAuditoriumRequest : IRequest<bool>
{
    private readonly int _auditoriumId;
    
    public DeleteAuditoriumRequest(int auditoriumId)
    {
        _auditoriumId = auditoriumId;
    }

    internal class DeleteAuditoriumRequestHandler : IRequestHandler<DeleteAuditoriumRequest, bool>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<DeleteAuditoriumRequestHandler> _logger;

        public DeleteAuditoriumRequestHandler(ILogger<DeleteAuditoriumRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<bool> Handle(DeleteAuditoriumRequest request, CancellationToken cancellationToken)
        {
            var result = await _context.Auditoriums.FirstOrDefaultAsync(x => x.AuditoriumId == request._auditoriumId, cancellationToken);

            if (result is null)
                return false;
            
            try
            {
                _context.Auditoriums.Remove(result);
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
