using AppCore.DataDB;
using AppCore.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.PersonRequests.StudentRequests;

public class GetStudentByIdRequest : IRequest<Student?>
{
    private readonly int _studentId;
    public GetStudentByIdRequest(int studentId)
    {
        _studentId = studentId;
    }

    internal class GetStudentByIdRequestHandler : IRequestHandler<GetStudentByIdRequest, Student?>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<GetStudentByIdRequestHandler> _logger;

        public GetStudentByIdRequestHandler(ILogger<GetStudentByIdRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Student?> Handle(GetStudentByIdRequest request, CancellationToken cancellationToken)
        {
            var response = await _context.Students.FirstOrDefaultAsync(x => x.PersonId == request._studentId, cancellationToken);
            return response;
        }
    }
}
