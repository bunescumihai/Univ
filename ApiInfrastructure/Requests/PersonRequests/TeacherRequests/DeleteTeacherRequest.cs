using AppCore.DataDB;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace Univ.Requests.PersonRequests.TeacherRequests;

public class DeleteTeacherRequest : IRequest<bool>
{
    private readonly int _teacherId;
    
    public DeleteTeacherRequest(int teacherId)
    {
        _teacherId = teacherId;
    }

    internal class DeleteTeacherRequestHandler : IRequestHandler<DeleteTeacherRequest, bool>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<DeleteTeacherRequestHandler> _logger;

        public DeleteTeacherRequestHandler(ILogger<DeleteTeacherRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<bool> Handle(DeleteTeacherRequest request, CancellationToken cancellationToken)
        {
            var result = await _context.Teachers.FirstOrDefaultAsync(x => x.PersonId == request._teacherId, cancellationToken);

            if (result is null)
                return false;
            
            try
            {
                _context.Teachers.Remove(result);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
