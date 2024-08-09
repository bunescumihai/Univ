using AppCore.DataDB;
using AppCore.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.PersonRequests.StudentRequests;

public class GetStudentsRequest : IRequest<List<Student>>
{
    internal class GetStudentsRequestHandler : IRequestHandler<GetStudentsRequest, List<Student>>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<GetStudentsRequestHandler> _logger;

        public GetStudentsRequestHandler(ILogger<GetStudentsRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<Student>> Handle(GetStudentsRequest request, CancellationToken cancellationToken)
        {
            var students  = await _context.Students.ToListAsync();
            return students;
        }
    }
}
