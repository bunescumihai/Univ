using AppCore.DataDB;
using AppCore.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.PersonRequests.TeacherRequests;

public class CreateTeacherInfoRequest : IRequest<object?>
{
    internal class CreateTeacherInfoRequestHandler : IRequestHandler<CreateTeacherInfoRequest, object?>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<CreateTeacherInfoRequestHandler> _logger;

        public CreateTeacherInfoRequestHandler(ILogger<CreateTeacherInfoRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<object?> Handle(CreateTeacherInfoRequest request, CancellationToken cancellationToken)
        {
            ResponseBuilder responseBuilder = new ResponseBuilder();

            return responseBuilder.GetResponse();
        }
    }
}
