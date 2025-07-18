using MaterialSkin;
using MaterialSkin.Controls;
using p_proyect.Modules.Entidades.BindinLists;
using p_proyect.Modules.Entidades.responses;
using p_proyect.Modules.Enums;
using p_proyect.Utils;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace p_proyect.Modules.Entidades.Formularios.F_Cursos
{
        public partial class F_Cursos_Mas_Informacion : MaterialForm
        {

                public Cursos Curso_Seleccionado { get; set; }

                public F_Cursos_Mas_Informacion() {
                        InitializeComponent();

                        var materialSkinManager = MaterialSkinManager.Instance;
                        materialSkinManager.AddFormToManage(this);
                        materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                        materialSkinManager.ColorScheme = new ColorScheme(Primary.Amber600, Primary.Amber700, Primary.Amber800, Accent.LightBlue400, TextShade.BLACK);

                }

                private void F_Cursos_Mas_Informacion_Load( object sender, EventArgs e ) {
                        CargarDatos();
                        Cargar_Tabla_Curos();
                }
                private void Cargar_Combo_Box_Profesores() {
                        try
                        {
                                using (var context = new AppDbContext(OpcionsBuilder_c.getConnection().Options))
                                {
                                        var ListaDeProfesores = context.Profesors.Select(p => new {
                                                p.Id,
                                                NombreCompleto = p.Nombre + " " + p.Apellido
                                        }).ToList();
                                        Profesor_Que_Imparte_El_Curso_com.DataSource = ListaDeProfesores;
                                        Profesor_Que_Imparte_El_Curso_com.DisplayMember = "NombreCompleto";
                                        Profesor_Que_Imparte_El_Curso_com.ValueMember = "Id";
                                }
                        } catch (Exception ex)
                        {
                                MessageBox.Show("Ocurrio un error en la carga de profesores al combobox\n" + ex);
                        }
                }
                BindingList<R_Relacion_Cursos_Estudiantes> Lista_De_Estudiantes = new BindingList<R_Relacion_Cursos_Estudiantes>();
                private void Cargar_Tabla_Curos() {
                        R_Estudiantes_Cursos_BindingList r_Estudiantes_Cursos_BindingList = new R_Estudiantes_Cursos_BindingList();
                        Lista_De_Estudiantes.Clear();
                        Lista_De_Estudiantes = r_Estudiantes_Cursos_BindingList.GetList(Curso_Seleccionado.Id);

                        Listado_De_Cursos_dg.DataSource = null;
                        Listado_De_Cursos_dg.DataSource = Lista_De_Estudiantes;
                }

                private void CargarDatos() {

                        Dia_En_Que_Se_Imparte_com.DataSource = Enum.GetValues(typeof(Dias_De_La_Semana));
                        Cargar_Combo_Box_Profesores();


                        Nombre_Del_Curso_txt.Text = Curso_Seleccionado.Nombre;
                        Descripcion_Del_Curso_txt.Text = Curso_Seleccionado.Descripcion;
                        Costo_Total_Del_Curso_txt.Text = Curso_Seleccionado.Costo_Del_Curso.ToString();
                        Costo_De_La_Inscripcion_Del_Curso_txt.Text = Curso_Seleccionado.Inscripcion.ToString();
                        Dia_En_Que_Se_Imparte_com.SelectedItem = Curso_Seleccionado.Dia_Curso;

                        TimeSpan hora_De_Inicio = Curso_Seleccionado.Hora_De_Inicio;
                        Hora_De_Inicio_dp.Text = hora_De_Inicio.ToString();

                        TimeSpan hora_De_Finalizacion = Curso_Seleccionado.Hora_De_Finalizacion;
                        Hora_De_Finalizacion.Text = hora_De_Finalizacion.ToString();

                        Profesor_Que_Imparte_El_Curso_com.SelectedValue = Curso_Seleccionado.Profesor_Id;
                        //Estado_Actual_Del_Curso_com.SelectedItem = Curso_Seleccionado.Estado_Actual_Del_Curso;

                }
        }
}
