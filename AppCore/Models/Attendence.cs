using AppCore.Models.Configurations;
using AppCore.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace AppCore.Models;

[EntityTypeConfiguration(typeof(AttendenceConfiguration))]
public class Attendance
{
    public int? AttendanceId { get; set; }
    public int? PairId { get; set; }
    public Pair? Pair { get; set; }
    public DateTime Date { get; set; } = DateTime.Today.Date;
    public int? PersonId { get; set; }
    public Student? Student { get; set; }
    public Status? Status { get; set; }
}