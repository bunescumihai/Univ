using AppCore.DataDB;
using AppCore.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.TimeDistributionRequests;

public class DeleteTimeDistributionRequest : IRequest<bool>
{
    private int _timeDistributionId;
    public DeleteTimeDistributionRequest(int timeDistributionId)
    {
        _timeDistributionId = timeDistributionId;
    }
    internal class DeleteTimeDistributionRequestHandler : IRequestHandler<DeleteTimeDistributionRequest, bool>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<DeleteTimeDistributionRequestHandler> _logger;

        public DeleteTimeDistributionRequestHandler(ILogger<DeleteTimeDistributionRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<bool> Handle(DeleteTimeDistributionRequest request, CancellationToken cancellationToken)
        {
            var result = await _context.TimeDistributions.FirstOrDefaultAsync(x => x.TimeDistributionId == request._timeDistributionId);
            
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
