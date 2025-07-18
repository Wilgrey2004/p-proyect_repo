using Microsoft.EntityFrameworkCore;
using p_proyect.Modules.Entidades.request;
using p_proyect.Modules.Entidades.responses;
using p_proyect.Utils;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;


namespace p_proyect.Modules.Entidades.BindinLists
{
        public class R_Estudiantes_Cursos_BindingList
        {
                private BindingList<R_Relacion_Cursos_Estudiantes> Lista_De_Estudiantes = new BindingList<R_Relacion_Cursos_Estudiantes>();

                public BindingList<R_Relacion_Cursos_Estudiantes> GetList(long id_curso) {
                        try
                        {


                                using (var context = new AppDbContext(OpcionsBuilder_c.getConnection().Options))
                                {
                                        
                                        var query = context.R_Estudiantes_Cursos.Where(x => x.Id_Curso == id_curso).Include(x => x.Cursos).Include(x => x.Estudiante).Select(x => new R_Relacion_Cursos_Estudiantes {
                                               Nombre_Estudiante = x.Estudiante.Nombre,
                                               Apellido_Estudiante = x.Estudiante.Apellido,
                                               Edad_Estudiante = x.Estudiante.Edad,
                                               Sexo_Estudiante = x.Estudiante.Sexo,
                                               Nombre_Curso = x.Cursos.Nombre,
                                                Descripcion_Curso = x.Cursos.Descripcion,
                                                Dia_Curso = x.Cursos.Dia_Curso,
                                                Hora_De_Inicio_curso = x.Cursos.Hora_De_Inicio,
                                                Hora_De_Finalizacion_curso = x.Cursos.Hora_De_Finalizacion


                                        }).ToList();

                                        // Convertimos el resultado a BindingList

                                        Lista_De_Estudiantes = new BindingList<R_Relacion_Cursos_Estudiantes>(query.ToList());
                                        return Lista_De_Estudiantes;
                                }

                        } catch (Exception ex)
                        {
                                MessageBox.Show("Ocurrio un error en el inicio de secion...\n" + ex);
                                return null;
                        }

                }
        }
}
