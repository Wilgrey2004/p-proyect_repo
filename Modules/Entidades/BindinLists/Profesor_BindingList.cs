using p_proyect.Modules.Entidades.responses;
using p_proyect.Utils;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;


namespace p_proyect.Modules.Entidades.BindinLists
{
        public class Profesor_BindingList
        {
                private BindingList<Profesores_Response> profesores_lista_Convertida = new BindingList<Profesores_Response>();

                public BindingList<Profesores_Response> GetList() {
                        try
                        {


                                using (var context = new AppDbContext(OpcionsBuilder_c.getConnection().Options))
                                {
                                        //var queryCursos = context.Cursos.Include(x => x.Profesor).Where(x => x.Estado_Actual_Del_Curso == Estado.Activo).ToList();

                                        
                                        var query = context.Profesors.Include(x => x.Cursos_Impartidos).Select(x => new Profesores_Response {
                                                Nombre = x.Nombre,
                                                Apellido = x.Apellido,
                                                Id = x.Id,
                                                Numero_De_Telefono = x.Numero_De_Telefono,
                                                Porcentaje_De_Comision = x.Porcentaje_De_Comision,
                                                Cursos_Impartidos_Count = x.Cursos_Impartidos.Where(Ci => Ci.Estado_Actual_Del_Curso == Enums.Estados_Generales.Activo).Count()
                                        });

                                        // Convertimos el resultado a BindingList

                                        profesores_lista_Convertida = new BindingList<Profesores_Response>(query.ToList());
                                        return profesores_lista_Convertida;
                                }

                        } catch (Exception ex)
                        {
                                MessageBox.Show("Ocurrio un error en el inicio de secion...\n" + ex);
                                return null;
                        }

                }
        }
}
