using AppCore.Models.Enum;

namespace Univ.Dto.AttendanceDtos;

public class CreateAttendanceDto
{    
    public int? PersonId { get; set; }
    public int? PairId { get; set; }
    public Status? Status { get; set; }
}