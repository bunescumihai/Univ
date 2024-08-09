using AppCore.DataDB;
using AppCore.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.PersonRequests.StudentRequests;

public class CreateStudentInfoRequest : IRequest<object?>
{
    internal class CreateStudentInfoRequestHandler : IRequestHandler<CreateStudentInfoRequest, object?>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<CreateStudentInfoRequestHandler> _logger;

        public CreateStudentInfoRequestHandler(ILogger<CreateStudentInfoRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<object?> Handle(CreateStudentInfoRequest request, CancellationToken cancellationToken)
        {
            ResponseBuilder responseBuilder = new ResponseBuilder();
            
            var academicGroups = _context.AcademicGroups.Select(a => new
            {
                a.AcademicGroupId,
                a.Name
            });
            
            
            responseBuilder.Add("academicGroups", academicGroups);

            return responseBuilder.GetResponse();
        }
    }
}
