// See https://aka.ms/new-console-template for more information

using HolaMundo;
using HolaMundo.BlancaFlor;
using HolaMundo.Damaris;
using Microsoft.EntityFrameworkCore;

// CodigoAnterior();
// EliminarBaseDeDatos();
// CrearBaseDeDatos();
// RegistrarPrimerDocente();
// RegistrarDosActividades();
// BuscarDocentePorId(1);
// MostrarActividadesDeUnDocente(1);
// EliminarUnaActividad();
// git pull origin main --allow-unrelated-histories
// git push origin main
ActualizarUnaActividad();

static void ActualizarUnaActividad()
{
    var actividadId = 2;
    using (var db = new SqliteDbContext())
    {
        var actividad = db.Actividades.Find(actividadId);
        if (actividad is not null)
        {
            actividad.EjeTematico = "Acceso a Datos";
            actividad.Subeje = "Entity Framework";
            actividad.Descripcion = "Operaciones de base de datos";
            db.Update(actividad);
            db.SaveChanges();
        }
    }
}

static void EliminarUnaActividad()
{
    using (var db = new SqliteDbContext())
    {
        var actividad = db.Actividades.Find(1);
        if (actividad is null)
        {
            Console.WriteLine("Registro no existente");
        }
        else
        {
            db.Remove(actividad);
            db.SaveChanges();
        }
    }
}


static void MostrarActividadesDeUnDocente(int docenteId)
{
    using (var db = new SqliteDbContext())
    {
        var actividades = db.Actividades
            .Where(a => a.DocenteId == docenteId)
            .Include(a => a.Docente)
            .ToList();
        if (actividades.Count > 0)
        {
            foreach (var actividad in actividades)
            {
                Console.WriteLine(
                    $"Actividad {actividad.Id}: {actividad.Descripcion}, Docente: {actividad.Docente.Nombres}");
            }
        }
        else
        {
            Console.WriteLine("No se encontraron actividades");
        }
    }
}

static void BuscarDocentePorId(int id)
{
    using (var db = new SqliteDbContext())
    {
        var docente = db.Docentes.Find(id);
        if (docente is null)
        {
            throw new Exception($"Docente no encontrado con el id {id}");
        }

        Console.WriteLine($"Docente {docente.Nombres} encontrado");
    }
}

static void RegistrarDosActividades()
{
    var numEmpleado = 123;
    Docente docente;
    try
    {
        docente = BuscarDocentePorNumeroDeEmpleado(numEmpleado);
    }
    catch (NullReferenceException ex)
    {
        throw new Exception(ex.Message);
    }

    // definir las actividades
    var actividades = new List<Actividad>
    {
        new Actividad
        {
            FechaDeRegistro = DateTime.Now,
            DocenteId = docente.Id,
            EjeTematico = "Eje 1",
            Subeje = "Subeje 1.1",
            Descripcion = "Descripción 1.1"
        },
        new Actividad
        {
            FechaDeRegistro = DateTime.Now,
            DocenteId = docente.Id,
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

static Docente BuscarDocentePorNumeroDeEmpleado(int numeroDeEmpleado)
{
    using (var db = new SqliteDbContext())
    {
        var docente = db.Docentes
            .FirstOrDefault(d => d.NumeroDeEmpleado == numeroDeEmpleado);
        return docente ??
               throw new NullReferenceException($"Docente no encontrado con el número de empleado {numeroDeEmpleado}");
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