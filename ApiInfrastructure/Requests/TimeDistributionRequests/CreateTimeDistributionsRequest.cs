using AppCore.DataDB;
using AppCore.Models;
using AppServices.FileSaverService;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.TimeDistributionRequests;

public class CreateTimeDistributionRequest : IRequest<TimeDistribution>
{

    private TimeDistribution _timeDistribution;
    
    public CreateTimeDistributionRequest(TimeDistribution timeDistribution)
    {
        this._timeDistribution = timeDistribution;
    }

    internal class CreateTimeDistributionRequestHandler : IRequestHandler<CreateTimeDistributionRequest, TimeDistribution?>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<CreateTimeDistributionRequestHandler> _logger;

        public CreateTimeDistributionRequestHandler(ILogger<CreateTimeDistributionRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<TimeDistribution?> Handle(CreateTimeDistributionRequest request, CancellationToken cancellationToken)
        {
            var response = await _context.TimeDistributions.AddAsync(request._timeDistribution);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return null;
            }
            

            return request._timeDistribution;
        }
        
    }
}
