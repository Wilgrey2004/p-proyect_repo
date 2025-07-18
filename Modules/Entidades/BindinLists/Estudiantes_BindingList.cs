using Microsoft.EntityFrameworkCore;
using p_proyect.Modules.Entidades.responses;
using p_proyect.Utils;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;


namespace p_proyect.Modules.Entidades.BindinLists
{
        public class Estudiantes_BindingList
        {
                private BindingList<Estudiantes_Response> Cursos_Lista = new BindingList<Estudiantes_Response>();

                public BindingList<Estudiantes_Response> GetList() {
                        try
                        {


                                using (var context = new AppDbContext(OpcionsBuilder_c.getConnection().Options))
                                {
                                        //var queryCursos = context.Cursos.Include(x => x.Profesor).Where(x => x.Estado_Actual_Del_Curso == Estado.Activo).ToList();
                                        //var queryCursos_R = context.R_Estudiantes_Cursos.Include(es => es.Estudiante).Include(cu => cu.Cursos).ToList();

                                        var query = context.Estudiantes.Include(x => x.Empleado).Select(x => new Estudiantes_Response {
                                                Id = x.Id,
                                                Nombre = x.Nombre,
                                                Apellido = x.Apellido,
                                                Edad = x.Edad,
                                                Sexo = x.Sexo,
                                                Apodo = x.Apodo,
                                                Cedula = x.Cedula,
                                                Direccion = x.Direccion,
                                                Municipio = x.Municipio,
                                                Sector = x.Sector,
                                                Nombre_del_tutor = x.Nombre_del_tutor,
                                                Telefono_del_tutor = x.Telefono_del_tutor,
                                                Estudia_En_La_Actualidad = x.Estudia_En_La_Actualidad,
                                                Nivel_De_Educacion = x.Nivel_De_Educacion,
                                                Cantidad_De_Cursos_A_Los_Que_Esta_Inscrito = (short)context.R_Estudiantes_Cursos.Count(r => r.Id_Estudiante == x.Id),
                                                Fecha_De_Inscripcion = x.Fecha_De_Inscripcion,
                                                Fecha_De_insercion_al_sistema = x.Fecha_De_insercion_al_sistema,
                                                Nombre_del_Empleado_Que_Lo_Inscribio = x.Empleado.Nombre_del_Administrador + " " + x.Empleado.Apellido_del_Administrador


                                        }).ToList();

                                        // Convertimos el resultado a BindingList

                                        Cursos_Lista = new BindingList<Estudiantes_Response>(query.ToList());
                                        return Cursos_Lista;
                                }

                        } catch (Exception ex)
                        {
                                MessageBox.Show("Ocurrio un error al cargar los estudiantes\n" + ex);
                                return null;
                        }

                }
        }
}
