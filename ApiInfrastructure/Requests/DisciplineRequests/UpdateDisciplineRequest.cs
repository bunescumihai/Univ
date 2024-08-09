using AppCore.DataDB;
using AppCore.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.DisciplineRequests;

public class UpdateDisciplineRequest : IRequest<Discipline?>
{
    public Discipline Discipline;
    public int DisciplineId;
    
    public UpdateDisciplineRequest(int disciplineId, Discipline discipline)
    {
        Discipline = discipline;
        DisciplineId = disciplineId;
    }

    internal class UpdateDisciplineRequestHandler : IRequestHandler<UpdateDisciplineRequest, Discipline?>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<UpdateDisciplineRequestHandler> _logger;

        public UpdateDisciplineRequestHandler(ILogger<UpdateDisciplineRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Discipline?> Handle(UpdateDisciplineRequest request, CancellationToken cancellationToken)
        {
            var Discipline = await _context.Disciplines.FirstOrDefaultAsync(x => x.DisciplineId == request.DisciplineId, cancellationToken);

            if (Discipline == default)
                return null;

            Discipline.SetUpdate(request.Discipline);
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return null;
            }

            return Discipline;
        }
    }
}
