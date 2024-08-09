using AppCore.DataDB;
using AppCore.Models;
using AppServices.FileSaverService;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.SpecialityRequests;

public class CreateSpecialityRequest : IRequest<Speciality>
{

    private Speciality _speciality;
    
    public CreateSpecialityRequest(Speciality speciality)
    {
        this._speciality = speciality;
    }

    internal class CreateSpecialityRequestHandler : IRequestHandler<CreateSpecialityRequest, Speciality?>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<CreateSpecialityRequestHandler> _logger;

        public CreateSpecialityRequestHandler(ILogger<CreateSpecialityRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Speciality?> Handle(CreateSpecialityRequest request, CancellationToken cancellationToken)
        {
            var response = await _context.Specialities.AddAsync(request._speciality);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return null;
            }
            

            return request._speciality;
        }
    }
}
