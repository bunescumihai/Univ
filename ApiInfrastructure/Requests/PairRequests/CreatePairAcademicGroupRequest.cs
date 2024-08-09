using AppCore.DataDB;
using AppCore.Models;
using AppServices.FileSaverService;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.PairRequests;

public class CreatePairAcademicGroupRequest : IRequest<PairAcademicGroup?>
{

    private PairAcademicGroup _pairAcademicGroup;
    
    public CreatePairAcademicGroupRequest(PairAcademicGroup pairAcademicGroup )
    {
        _pairAcademicGroup = pairAcademicGroup;
    }

    internal class CreatePairAcademicGroupRequestHandler : IRequestHandler<CreatePairAcademicGroupRequest, PairAcademicGroup?>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<CreatePairAcademicGroupRequestHandler> _logger;

        public CreatePairAcademicGroupRequestHandler(ILogger<CreatePairAcademicGroupRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<PairAcademicGroup?> Handle(CreatePairAcademicGroupRequest request, CancellationToken cancellationToken)
        {
            var response = await _context.PairAcademicGroups.AddAsync(request._pairAcademicGroup);
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return null;
            }
            
            return request._pairAcademicGroup;
        }
        
    }
}
