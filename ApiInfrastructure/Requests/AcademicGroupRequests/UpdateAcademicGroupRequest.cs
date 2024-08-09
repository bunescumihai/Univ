using AppCore.DataDB;
using AppCore.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.EducationalGroupRequests;

public class UpdateAcademicGroupRequest : IRequest<AcademicGroup?>
{
    public string Name;
    public int AcademicGroupId;
    
    public UpdateAcademicGroupRequest(int academicGroupId, string name)
    {
        Name = name;
        AcademicGroupId = academicGroupId;
    }

    internal class UpdateAcademicGroupRequestHandler : IRequestHandler<UpdateAcademicGroupRequest, AcademicGroup?>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<UpdateAcademicGroupRequestHandler> _logger;

        public UpdateAcademicGroupRequestHandler(ILogger<UpdateAcademicGroupRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<AcademicGroup?> Handle(UpdateAcademicGroupRequest request, CancellationToken cancellationToken)
        {
            AcademicGroup academicGroup = await _context.AcademicGroups.FirstOrDefaultAsync(x => x.AcademicGroupId == request.AcademicGroupId, cancellationToken);

            if (academicGroup == default)
                return null;

            academicGroup.Name = request.Name;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return null;
            }

            return academicGroup;
        }
    }
}
