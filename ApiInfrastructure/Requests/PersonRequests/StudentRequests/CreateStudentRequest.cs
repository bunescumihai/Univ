using AppCore.DataDB;
using AppCore.Models;
using AppServices.FileSaverService;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.PersonRequests.StudentRequests;

public class CreateStudentRequest : IRequest<Student?>
{
    private Student _student;
    private IFormFile _image;
    
    public CreateStudentRequest(Student student, IFormFile image)
    {
        _image = image;
        _student = student;
    }

    internal class CreateStudentRequestHandler : IRequestHandler<CreateStudentRequest, Student?>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<CreateStudentRequestHandler> _logger;

        public CreateStudentRequestHandler(ILogger<CreateStudentRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Student?> Handle(CreateStudentRequest request, CancellationToken cancellationToken)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var response = await _context.Students.AddAsync(request._student);
                    await _context.SaveChangesAsync();
                    
                    FileSaver fileSaver = new FileSaver();
                    var imagePath = await fileSaver.SaveAsync("wwwroot/images/students", request._image);
                    
                    response.Entity.ImagePath = imagePath;
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return response.Entity;
                }
                catch (Exception e)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    return null;
                }
            }
            

        }
    }
}
