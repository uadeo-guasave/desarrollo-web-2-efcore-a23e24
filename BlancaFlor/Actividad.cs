using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HolaMundo.Damaris;

namespace HolaMundo.BlancaFlor;

[Table("Actividades")]
class Actividad
{
    public int Id { get; private set; }

    [Required]
    public DateTime FechaDeRegistro { get; set; }

    [Required]
    public int DocenteId { get; set; }

    [Required, MaxLength(100)]
    public string? EjeTematico { get; set; }

    [Required, MaxLength(100)]
    public string? Subeje { get; set; }

    [Required, MaxLength(300)]
    public string? Descripcion { get; set; }

    [NotMapped]
    public Docente Docente { get; set; } = new();
}