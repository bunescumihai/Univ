using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppCore.Models;

public class Auditorium
{
    public int? AuditoriumId { get; set; }
    public string? Name { get; set; }
}