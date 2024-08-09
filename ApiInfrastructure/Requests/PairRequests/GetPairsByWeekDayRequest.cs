using AppCore.DataDB;
using AppCore.Models;
using AppCore.Models.Enum;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Univ.Requests.PairRequests;
public class GetPairsByWeekDayRequest : IRequest<List<Pair>>
{

    private WeekDay _weekDay;
    public GetPairsByWeekDayRequest(WeekDay weekDay)
    {
        _weekDay = weekDay;
    }

    internal class GetPairsByWeekDayRequestHandler : IRequestHandler<GetPairsByWeekDayRequest, List<Pair>>
    {
        private readonly PeDbContext _context;
        private readonly ILogger<GetPairsByWeekDayRequestHandler> _logger;

        public GetPairsByWeekDayRequestHandler(ILogger<GetPairsByWeekDayRequestHandler> logger, PeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<Pair>> Handle(GetPairsByWeekDayRequest request, CancellationToken cancellationToken)
        {
            var rs = await _context.Pairs.Where(x => x.WeekDay == request._weekDay).ToListAsync();
            return rs;
        }
    }
}
