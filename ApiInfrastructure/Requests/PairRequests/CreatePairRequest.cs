using AppCore.DataDB;
using AppCore.Models;
using AppServices.FileSaverService;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.PairRequests;

public class CreatePairRequest : IRequest<Pair>
{

    private Pair _pair;
    
    public CreatePairRequest(Pair pair)
    {
        this._pair = pair;
    }

    internal class CreatePairRequestHandler : IRequestHandler<CreatePairRequest, Pair?>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<CreatePairRequestHandler> _logger;

        public CreatePairRequestHandler(ILogger<CreatePairRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Pair?> Handle(CreatePairRequest request, CancellationToken cancellationToken)
        {
            var response = await _context.Pairs.AddAsync(request._pair);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return null;
            }
            

            return request._pair;
        }
        
    }
}
