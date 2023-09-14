// See https://aka.ms/new-console-template for more information

using HolaMundo;
using HolaMundo.BlancaFlor;
using HolaMundo.Damaris;

// CodigoAnterior();
// EliminarBaseDeDatos();
// CrearBaseDeDatos();
// RegistrarPrimerDocente();
var docenteId = 123;
var docente = BuscarDocentePorNumeroDeEmpleado(docenteId);
if (docente is null)
{
    Console.WriteLine($"Docente con el id: {docenteId} no encontrado");
}
else
{
    Console.WriteLine($"Docente {docente.Nombres} encontrado con id: {docente.Id}");
}

RegistrarDosActividades(docente.Id);

static void RegistrarDosActividades(int docenteId)
{
    // definir las actividades
    var actividades = new List<Actividad>
    {
        new Actividad
        {
            FechaDeRegistro = DateTime.Now,
            DocenteId = docenteId,
            EjeTematico = "Eje 1",
            Subeje = "Subeje 1.1",
            Descripcion = "Descripción 1.1"
        },
        new Actividad
        {
            FechaDeRegistro = DateTime.Now,
            DocenteId = docenteId,
            EjeTematico = "Eje 1",
            Subeje = "Subeje 1.2",
            Descripcion = "Descripción 1.2"
        }
    };
    using (var db = new SqliteDbContext())
    {
        // agregar las actividades
        db.Actividades.AddRange(actividades);
        // guardar los cambios
        db.SaveChanges();
    }
}

static Docente? BuscarDocentePorNumeroDeEmpleado(int numeroDeEmpleado)
{
    using (var db = new SqliteDbContext())
    {
        var docente = db.Docentes
            .FirstOrDefault(d => d.NumeroDeEmpleado == numeroDeEmpleado);
        return docente;
    }
}


static void EliminarBaseDeDatos()
{
    using (var db = new SqliteDbContext())
    {
        db.Database.EnsureDeleted();
    }
}

static void RegistrarPrimerDocente()
{
    var docente = new Docente
    {
        NumeroDeEmpleado = 123,
        Nombres = "Jose Luis",
        Apellidos = "Gaxiola Castro"
    };
    using (var db = new SqliteDbContext())
    {
        // equivalente a INSERT de SQL
        db.Docentes.Add(docente);
        db.SaveChanges();
    }
}

static void CrearBaseDeDatos()
{
    // Resources tienen métodos para abrir y cerrar acciones
    using (var db = new SqliteDbContext())
    {
        db.Database.EnsureCreated();
    }
}

static void CodigoAnterior()
{
    Console.WriteLine("Hello, World!");

    // Crear docentes y actividades
    var docente1 = new Docente();
    docente1.Nombres = "José Luis";
    docente1.Apellidos = "Gaxiola Castro";
    docente1.NumeroDeEmpleado = 1234;
    // docente1.Id = 1;

    var actividad1 = new Actividad
    {
        FechaDeRegistro = DateTime.Now,
        DocenteId = docente1.Id,
        EjeTematico = "Eje 1",
        Subeje = "Subeje 2",
        Descripcion = "No dormirse en clase"
    };

    var actividad2 = new Actividad
    {
        FechaDeRegistro = DateTime.Today,
        DocenteId = docente1.Id,
        EjeTematico = "Eje 2",
        Subeje = "Subeje 3",
        Descripcion = "Trabajar en viernes"
    };

    // TODO: Imprimir la descripción de las actividades creadas 
    // y que muestre el nombre del docente
    Console.WriteLine($"Actividad: {actividad1.Descripcion}, Docente: {actividad1.DocenteId}");
    Console.WriteLine($"Actividad: {actividad2.Descripcion}, Docente: {actividad2.DocenteId}");


    // SELECT * FROM Actividades WHERE DocenteId=1;
    // Retornar 2 registros vinculados al profesor 1
    docente1.Actividades.Add(actividad1);
    docente1.Actividades.Add(actividad2);

    // SELECT * FROM Docentes WHERE Id=[actividad1.DocenteId];
    actividad1.Docente = docente1;
    actividad2.Docente = docente1;

    // TODO: Imprimir la descripción de las actividades creadas 
    // y que muestre el nombre del docente
    Console.WriteLine($"Docente: {docente1.Nombres} {docente1.Apellidos}");
    Console.WriteLine("Actividades:");
    foreach (var actividad in docente1.Actividades)
    {
        Console.WriteLine(actividad.Descripcion);
    }
}