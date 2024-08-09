using AppCore.DataDB;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace Univ.Requests.PersonRequests.StudentRequests;

public class DeleteStudentRequest : IRequest<bool>
{
    private readonly int _studentId;
    
    public DeleteStudentRequest(int studentId)
    {
        _studentId = studentId;
    }

    internal class DeleteStudentRequestHandler : IRequestHandler<DeleteStudentRequest, bool>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<DeleteStudentRequestHandler> _logger;

        public DeleteStudentRequestHandler(ILogger<DeleteStudentRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<bool> Handle(DeleteStudentRequest request, CancellationToken cancellationToken)
        {
            var result = await _context.Students.FirstOrDefaultAsync(x => x.PersonId == request._studentId, cancellationToken);

            if (result is null)
                return false;
            
            try
            {
                _context.Students.Remove(result);
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
