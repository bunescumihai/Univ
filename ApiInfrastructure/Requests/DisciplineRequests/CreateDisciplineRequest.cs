using AppCore.DataDB;
using AppCore.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.DisciplineRequests;

public class CreateDisciplineRequest : IRequest<Discipline?>
{
    public Discipline Discipline;
    
    public CreateDisciplineRequest(Discipline discipline)
    {
        Discipline = discipline;
    }

    internal class CreateDisciplineRequestHandler : IRequestHandler<CreateDisciplineRequest, Discipline?>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<CreateDisciplineRequestHandler> _logger;

        public CreateDisciplineRequestHandler(ILogger<CreateDisciplineRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Discipline?> Handle(CreateDisciplineRequest request, CancellationToken cancellationToken)
        {
            var response =  await _context.Disciplines.AddAsync(request.Discipline);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return null;
            }

            return response.Entity;
        }
    }
}
