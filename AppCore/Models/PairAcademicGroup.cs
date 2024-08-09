using AppCore.Models.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AppCore.Models;

[EntityTypeConfiguration(typeof(PairAcademicGroupConfiguration))]
public class PairAcademicGroup
{
    public int? PairAcademicGroupId {get; set; }
    public int? PairId { get; set; }
    public Pair? Pair { get; set; }
    public int? AcademicGroupId { get; set; }
    public AcademicGroup? AcademicGroup { get; set; }
}