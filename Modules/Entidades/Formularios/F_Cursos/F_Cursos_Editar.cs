using MaterialSkin;
using MaterialSkin.Controls;
using p_proyect.Modules.Entidades.BindinLists;
using p_proyect.Modules.Enums;
using p_proyect.Utils;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace p_proyect.Modules.Entidades.Formularios.F_Cursos
{
        public partial class F_Cursos_Editar : MaterialForm
        {
                public Cursos Curso_Seleccionado;
                public F_Cursos_Editar() {
                        InitializeComponent();

                        var materialSkinManager = MaterialSkinManager.Instance;
                        materialSkinManager.AddFormToManage(this);
                        materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                        materialSkinManager.ColorScheme = new ColorScheme(Primary.Amber600, Primary.Amber700, Primary.Amber800, Accent.LightBlue400, TextShade.BLACK);

                }
                private void CargarDatos() {
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
                        Estado_Actual_Del_Curso_com.SelectedItem = Curso_Seleccionado.Estado_Actual_Del_Curso;

                }

                private void F_Cursos_Editar_Load( object sender, EventArgs e ) {
                        CargarTabla_De_Cursos();
                        Cargar_Combo_Boxes_Dias_De_La_Semana();
                        Cargar_Combo_Box_Profesores();
                        Cargar_Combo_Box_Estados();
                        CargarDatos();
                        Colocar_Formato_A_Los_Data_Pikers();
                }
                private void Colocar_Formato_A_Los_Data_Pikers() {
                        Hora_De_Inicio_dp.Format = DateTimePickerFormat.Time;
                        Hora_De_Inicio_dp.ShowUpDown = true;
                        //Hora_De_Inicio_dp.Value = DateTime.Now;

                        Hora_De_Finalizacion.Format = DateTimePickerFormat.Time;
                        Hora_De_Finalizacion.ShowUpDown = true;

                }

                private void Cargar_Combo_Box_Estados() {
                        Estado_Actual_Del_Curso_com.DataSource = Enum.GetValues(typeof(Estados_Generales));
                        Estado_Actual_Del_Curso_com.SelectedItem = Curso_Seleccionado.Estado_Actual_Del_Curso;
                }

                private void Cargar_Combo_Boxes_Dias_De_La_Semana() {
                        Dia_En_Que_Se_Imparte_com.DataSource = Enum.GetValues(typeof(Dias_De_La_Semana));
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

                BindingList<Cursos> Cursos_Lista = new BindingList<Cursos>();

                private void CargarTabla_De_Cursos() {
                        try
                        {
                                Cursos_BindingList cursos_BindingList = new Cursos_BindingList();
                                Cursos_Lista.Clear();
                                Listado_De_Cursos_dg.DataSource = cursos_BindingList.GetList();




                        } catch (Exception ex)
                        {
                                MessageBox.Show("ha ocurrido un erro cargando los cursos\n" + ex, "Error detectado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }

                private void materialButton9_Click( object sender, EventArgs e ) {
                        var mensaje = MessageBox.Show($"Editar el curso: {Nombre_Del_Curso_txt.Text}?", "Mensaje de confirmacion para el agregado.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (mensaje == DialogResult.No)
                        {
                                return;
                        }
                        try
                        {
                                using (var context = new AppDbContext(OpcionsBuilder_c.getConnection().Options))
                                {
                                        context.Cursos.Update(Curso_Seleccionado);
                                        context.SaveChanges();
                                        CargarTabla_De_Cursos();
                                        MessageBox.Show($"El curso {Curso_Seleccionado.Nombre} ha sido editado correctamente.", "Curso Editado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                }
                        } catch (Exception ex)
                        {
                                MessageBox.Show("Ocurrio un error en el inicio de secion...\n" + ex);
                        }
                }
        }
}
