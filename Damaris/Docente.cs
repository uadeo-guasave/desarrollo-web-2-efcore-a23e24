using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HolaMundo.BlancaFlor;

namespace HolaMundo.Damaris;

// PascalCase
[Table("Docentes")]
class Docente
{
    public int Id { get; private set; }

    [Required]
    public int NumeroDeEmpleado { get; set; }

    [Required, MaxLength(50)]
    public string? Nombres { get; set; }

    [Required, MaxLength(50)]
    public string? Apellidos { get; set; }

    [NotMapped] 
    public List<Actividad> Actividades { get; set; } = new();
}