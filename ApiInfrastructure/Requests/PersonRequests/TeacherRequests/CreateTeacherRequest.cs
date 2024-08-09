using AppCore.DataDB;
using AppCore.Models;
using AppServices.FileSaverService;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.PersonRequests.TeacherRequests;

public class CreateTeacherRequest : IRequest<Teacher?>
{
    private Teacher _teacher;
    private IFormFile _image;
    
    public CreateTeacherRequest(Teacher teacher, IFormFile image)
    {
        _image = image;
        _teacher = teacher;
    }

    internal class CreateTeacherRequestHandler : IRequestHandler<CreateTeacherRequest, Teacher?>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<CreateTeacherRequestHandler> _logger;

        public CreateTeacherRequestHandler(ILogger<CreateTeacherRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Teacher?> Handle(CreateTeacherRequest request, CancellationToken cancellationToken)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var response = await _context.Teachers.AddAsync(request._teacher);
                    await _context.SaveChangesAsync();
                    
                    FileSaver fileSaver = new FileSaver();
                    string? imagePath = await fileSaver.SaveAsync("wwwroot/images/teachers", request._image);

                    if (imagePath is null)
                        throw new Exception();

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
