using AppCore.DataDB;
using AppCore.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.SpecialityRequests;

public class DeleteSpecialityRequest : IRequest<bool>
{
    private int _specialityId;
    public DeleteSpecialityRequest(int specialityId)
    {
        _specialityId = specialityId;
    }
    internal class DeleteSpecialityRequestHandler : IRequestHandler<DeleteSpecialityRequest, bool>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<DeleteSpecialityRequestHandler> _logger;

        public DeleteSpecialityRequestHandler(ILogger<DeleteSpecialityRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<bool> Handle(DeleteSpecialityRequest request, CancellationToken cancellationToken)
        {
            var result = await _context.Specialities.FirstOrDefaultAsync(x => x.SpecialityId == request._specialityId);
            
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
