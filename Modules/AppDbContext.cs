using Microsoft.EntityFrameworkCore;
using p_proyect.Modules.Entidades;

namespace p_proyect.Modules
{
        public class AppDbContext : DbContext
        {

                public AppDbContext( DbContextOptions<AppDbContext> options ) : base(options) {

                }



                public DbSet<Empleado_Admin> Empleado_Admins { get; set; }
                public DbSet<Estudiante> Estudiantes { get; set; }

                public DbSet<Profesor> Profesors { get; set; }

                public DbSet<Cursos> Cursos { get; set; }
                public DbSet<Adeudo_Curso> Adeudos_Cursos { get; set; }

                public DbSet<R_Estudiantes_Cursos> R_Estudiantes_Cursos { get; set; }

                protected override void OnModelCreating( ModelBuilder modelBuilder ) {
                        //base.OnModelCreating(modelBuilder);
                        base.OnModelCreating(modelBuilder);

                        modelBuilder.Entity<Empleado_Admin>().HasData(
                                new Empleado_Admin { Id = 1,Nombre_del_Administrador = "Administrador", Apellido_del_Administrador = "admin", Numero_de_Telefono = "8494061420", Pass = "admin123", Pass_confirm = "admin123", Estado = Enums.Estados_Generales.Activo }
                                );
                }
        }
}
