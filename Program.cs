// See https://aka.ms/new-console-template for more information
using HolaMundo.BlancaFlor;
using HolaMundo.Damaris;

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