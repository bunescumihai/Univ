using AppCore.DataDB;
using AppCore.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.PersonRequests.TeacherRequests;

public class GetTeacherByIdRequest : IRequest<Teacher?>
{
    private readonly int _teacherId;
    public GetTeacherByIdRequest(int teacherId)
    {
        _teacherId = teacherId;
    }

    internal class GetTeacherByIdRequestHandler : IRequestHandler<GetTeacherByIdRequest, Teacher?>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<GetTeacherByIdRequestHandler> _logger;

        public GetTeacherByIdRequestHandler(ILogger<GetTeacherByIdRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Teacher?> Handle(GetTeacherByIdRequest request, CancellationToken cancellationToken)
        {
            var response = await _context.Teachers.FirstOrDefaultAsync(x => x.PersonId == request._teacherId, cancellationToken);
            return response;
        }
    }
}
