using AppCore.DataDB;
using AppCore.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.PersonRequests.TeacherRequests;

public class UpdateTeacherRequest : IRequest<Teacher?>
{
    public Teacher Teacher;
    public int TeacherId;
    
    public UpdateTeacherRequest(int teacherId, Teacher teacher)
    {
        Teacher = teacher;
        TeacherId = teacherId;
    }

    internal class UpdateTeacherRequestHandler : IRequestHandler<UpdateTeacherRequest, Teacher?>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<UpdateTeacherRequestHandler> _logger;

        public UpdateTeacherRequestHandler(ILogger<UpdateTeacherRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Teacher?> Handle(UpdateTeacherRequest request, CancellationToken cancellationToken)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.PersonId == request.TeacherId, cancellationToken);

            if (teacher == default)
                return null;

            teacher.SetUpdate(request.Teacher);
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return null;
            }

            return teacher;
        }
    }
}
