using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.EntityFrameworkCore;
using p_proyect.Utils;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace p_proyect.Modules.Entidades.Formularios.Profesores
{
        public partial class Mas_Informacion_Profesor : MaterialForm
        {
                public Profesor Profesor_Seleccionado { get; set; }
                public Mas_Informacion_Profesor() {
                        InitializeComponent();

                        var materialSkinManager = MaterialSkinManager.Instance;
                        materialSkinManager.AddFormToManage(this);
                        materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                        materialSkinManager.ColorScheme = new ColorScheme(Primary.Amber600, Primary.Amber700, Primary.Amber800, Accent.LightBlue400, TextShade.BLACK);

                }

                private void Mas_Informacion_Profesor_Load( object sender, EventArgs e ) {
                        Nombre_Profesor_txt.Text = Profesor_Seleccionado.Nombre;
                        Apellido_Profesor_txt.Text = Profesor_Seleccionado.Apellido;
                        Numero_Del_Profesor_txt.Text = Profesor_Seleccionado.Numero_De_Telefono;
                        Cargar_Cursos();
                }


                BindingList<Cursos> Cursos_Del_Profesor = new BindingList<Cursos>();

                private void Cargar_Cursos() {
                        try
                        {

                                using (var context = new AppDbContext(OpcionsBuilder_c.getConnection().Options))
                                {

                                        var query = context.Cursos.Include(c => c.Profesor)
                                                .Where(c => c.Profesor_Id == Profesor_Seleccionado.Id)
                                                .ToList();

                                        if (query.Count == 0)
                                        {
                                                return;
                                        }

                                        Listado_De_Cursos_dg.DataSource = null;
                                        Cursos_Del_Profesor.Clear();
                                        Cursos_Del_Profesor = new BindingList<Cursos>(query);
                                        Listado_De_Cursos_dg.DataSource = Cursos_Del_Profesor;
                                }



                        } catch (Exception ex)
                        {
                                MessageBox.Show("Ocurrio un error al cargar los cursos\n" + ex);
                        }
                }
        }
}
