using AppCore.DataDB;
using AppCore.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.SpecialityRequests;

public class GetSpecialityRequest : IRequest<Speciality?>
{
    private int _specialityId;

    public GetSpecialityRequest(int specialityId)
    {
        _specialityId = specialityId;
    }
    internal class GetSpecialityRequestHandler : IRequestHandler<GetSpecialityRequest, Speciality?>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<GetSpecialityRequestHandler> _logger;

        public GetSpecialityRequestHandler(ILogger<GetSpecialityRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Speciality?> Handle(GetSpecialityRequest request, CancellationToken cancellationToken)
        {
            var educationalInstitutions  = await _context.Specialities
                .Include(e => e.EducationalInstitution)
                .Include(e => e.AcademicGroups)
                .FirstOrDefaultAsync(s => s.SpecialityId == request._specialityId);
            return educationalInstitutions;
        }
    }
}
