namespace HolaMundo.Damaris;

// PascalCase
class Docente
{
    private int Id { get; set; }
    public int NumeroDeEmpleado { get; set; }
    public string? Nombres { get; set; }
    public string? Apellidos { get; set; }

    public Docente()
    {
        this.Id = new Random().Next(1,100);
    }
}