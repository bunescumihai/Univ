using AppCore.DataDB;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using AppCore.Models;

namespace Univ.Requests.EducationalGroupRequests;

public class DeleteAcademicGroupRequest : IRequest<bool>
{
    public int AcademicGroupId;
    
    public DeleteAcademicGroupRequest(int academicGroupId)
    {
        AcademicGroupId = academicGroupId;
    }

    internal class DeleteAcademicGroupRequestHandler : IRequestHandler<DeleteAcademicGroupRequest, bool>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<DeleteAcademicGroupRequestHandler> _logger;

        public DeleteAcademicGroupRequestHandler(ILogger<DeleteAcademicGroupRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<bool> Handle(DeleteAcademicGroupRequest request, CancellationToken cancellationToken)
        {
            var result = await _context.AcademicGroups.FirstOrDefaultAsync(x => x.AcademicGroupId == request.AcademicGroupId);

            if (result is null)
                return false;
            
            try
            {
                _context.AcademicGroups.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
