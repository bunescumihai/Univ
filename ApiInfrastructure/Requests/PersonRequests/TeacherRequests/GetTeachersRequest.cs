using AppCore.DataDB;
using AppCore.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.PersonRequests.TeacherRequests;

public class GetTeachersRequest : IRequest<List<Teacher>>
{
    internal class GetTeachersRequestHandler : IRequestHandler<GetTeachersRequest, List<Teacher>>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<GetTeachersRequestHandler> _logger;

        public GetTeachersRequestHandler(ILogger<GetTeachersRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<Teacher>> Handle(GetTeachersRequest request, CancellationToken cancellationToken)
        {
            var teachers  = await _context.Teachers.ToListAsync();
            return teachers;
        }
    }
}
