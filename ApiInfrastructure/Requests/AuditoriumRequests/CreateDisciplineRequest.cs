using AppCore.DataDB;
using AppCore.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.AuditoriumRequests;

public class CreateAuditoriumRequest : IRequest<Auditorium?>
{
    public Auditorium Auditorium;
    
    public CreateAuditoriumRequest(Auditorium auditorium)
    {
        Auditorium = auditorium;
    }

    internal class CreateAuditoriumRequestHandler : IRequestHandler<CreateAuditoriumRequest, Auditorium?>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<CreateAuditoriumRequestHandler> _logger;

        public CreateAuditoriumRequestHandler(ILogger<CreateAuditoriumRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Auditorium?> Handle(CreateAuditoriumRequest request, CancellationToken cancellationToken)
        {
            var response =  await _context.Auditoriums.AddAsync(request.Auditorium);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return null;
            }

            return request.Auditorium;
        }
    }
}
