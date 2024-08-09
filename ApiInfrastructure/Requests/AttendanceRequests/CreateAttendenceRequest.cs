using AppCore.DataDB;
using AppCore.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.AttendanceRequests;

public class CreateAttendanceRequest : IRequest<Attendance?>
{
    public Attendance Attendance;
    
    public CreateAttendanceRequest(Attendance auditorium)
    {
        Attendance = auditorium;
    }

    internal class CreateAttendanceRequestHandler : IRequestHandler<CreateAttendanceRequest, Attendance?>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<CreateAttendanceRequestHandler> _logger;

        public CreateAttendanceRequestHandler(ILogger<CreateAttendanceRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Attendance?> Handle(CreateAttendanceRequest request, CancellationToken cancellationToken)
        {
            var response =  await _context.Attendances.AddAsync(request.Attendance);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return null;
            }

            return request.Attendance;
        }
    }
}
