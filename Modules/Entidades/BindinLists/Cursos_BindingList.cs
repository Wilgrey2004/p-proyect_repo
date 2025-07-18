using Microsoft.EntityFrameworkCore;
using p_proyect.Modules.Entidades.request;
using p_proyect.Utils;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;


namespace p_proyect.Modules.Entidades.BindinLists
{
        public class Cursos_BindingList
        {
                private BindingList<Cursos_Response> Cursos_Lista = new BindingList<Cursos_Response>();

                public BindingList<Cursos_Response> GetList() {
                        try
                        {


                                using (var context = new AppDbContext(OpcionsBuilder_c.getConnection().Options))
                                {
                                        //var queryCursos = context.Cursos.Include(x => x.Profesor).Where(x => x.Estado_Actual_Del_Curso == Estado.Activo).ToList();
                                        //var queryCursos_R = context.R_Estudiantes_Cursos.Include(es => es.Estudiante).Include(cu => cu.Cursos).ToList();

                                        var query = context.Cursos.Include(x => x.Profesor).Select(x => new Cursos_Response {
                                                Id = x.Id,
                                                Nombre = x.Nombre,
                                                Descripcion = x.Descripcion,
                                                Nombre_Del_Profesor = x.Profesor.Nombre + " " + x.Profesor.Apellido,
                                                Dia_Curso = x.Dia_Curso,
                                                Hora_De_Inicio = x.Hora_De_Inicio,
                                                Hora_De_Finalizacion = x.Hora_De_Finalizacion,
                                                Costo_Del_Curso = x.Costo_Del_Curso,
                                                Inscripcion = x.Inscripcion,
                                                Cantidad_De_Estudiantes = context.R_Estudiantes_Cursos.Count(r => r.Id_Curso == x.Id),
                                                Estado_Actual_Del_Curso = x.Estado_Actual_Del_Curso
                                        }).ToList();

                                        // Convertimos el resultado a BindingList

                                        Cursos_Lista = new BindingList<Cursos_Response>(query.ToList());
                                        return Cursos_Lista;
                                }

                        } catch (Exception ex)
                        {
                                MessageBox.Show("Ocurrio un error en el inicio de secion...\n" + ex);
                                return null;
                        }

                }
        }
}
