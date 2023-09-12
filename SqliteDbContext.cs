using HolaMundo.BlancaFlor;
using HolaMundo.Damaris;
using Microsoft.EntityFrameworkCore;

namespace HolaMundo;

class SqliteDbContext : DbContext
{
    // definir las propiedades que se convertiran en tablas
    public DbSet<Docente> Docentes { get; set; }
    public DbSet<Actividad> Actividades { get; set; }

    // definir el controlador y la conexión a la base de datos
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data source=Db/BdControlAct.db");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actividad>(act => 
            act.HasOne<Docente>(a => a.Docente)
                .WithMany(d => d.Actividades));

        modelBuilder.Entity<Docente>(doc =>
            doc.HasMany<Actividad>(d => d.Actividades)
                .WithOne(a => a.Docente));
        
        base.OnModelCreating(modelBuilder);
    }
}