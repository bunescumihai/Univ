using AppCore.DataDB;
using AppCore.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.PersonRequests.StudentRequests;

public class UpdateStudentRequest : IRequest<Student?>
{
    public Student Student;
    public int StudentId;
    
    public UpdateStudentRequest(int studentId, Student student)
    {
        Student = student;
        StudentId = studentId;
    }

    internal class UpdateStudentRequestHandler : IRequestHandler<UpdateStudentRequest, Student?>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<UpdateStudentRequestHandler> _logger;

        public UpdateStudentRequestHandler(ILogger<UpdateStudentRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Student?> Handle(UpdateStudentRequest request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.PersonId == request.StudentId, cancellationToken);

            if (student == default)
                return null;

            student.SetUpdate(request.Student);
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return null;
            }

            return student;
        }
    }
}
