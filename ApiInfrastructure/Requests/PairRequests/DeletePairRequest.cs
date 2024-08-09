using AppCore.DataDB;
using AppCore.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.PairRequests;

public class DeletePairRequest : IRequest<bool>
{
    private int _pairId;
    public DeletePairRequest(int pairId)
    {
        _pairId = pairId;
    }
    internal class DeletePairRequestHandler : IRequestHandler<DeletePairRequest, bool>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<DeletePairRequestHandler> _logger;

        public DeletePairRequestHandler(ILogger<DeletePairRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<bool> Handle(DeletePairRequest request, CancellationToken cancellationToken)
        {
            var result = await _context.Pairs.FirstOrDefaultAsync(x => x.PairId == request._pairId);
            
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
