// See https://aka.ms/new-console-template for more information
using HolaMundo;
using HolaMundo.BlancaFlor;
using HolaMundo.Damaris;

// CodigoAnterior();
CrearBaseDeDatos();

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

