using HolaMundo.BlancaFlor;

namespace HolaMundo.Damaris;

// PascalCase
class Docente
{
    public int Id { get; }
    public int NumeroDeEmpleado { get; set; }
    public string? Nombres { get; set; }
    public string? Apellidos { get; set; }
    public List<Actividad> Actividades { get; set; }

    public Docente()
    {
        this.Id = new Random().Next(1,100);
        this.Actividades = new List<Actividad>();
    }
}