using MaterialSkin;
using MaterialSkin.Controls;
using p_proyect.Modules.Entidades.BindinLists;
using p_proyect.Utils;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace p_proyect.Modules.Entidades.Formularios.Estudiantes
{
        public partial class Inscribir_al_Estudiante_A_Un_Curso : MaterialForm
        {
                public Estudiante Estudiante { get; set; }
                public Inscribir_al_Estudiante_A_Un_Curso() {
                        InitializeComponent();

                        var materialSkinManager = MaterialSkinManager.Instance;
                        materialSkinManager.AddFormToManage(this);
                        materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                        materialSkinManager.ColorScheme = new ColorScheme(Primary.Amber600, Primary.Amber700, Primary.Amber800, Accent.LightBlue400, TextShade.BLACK);
                }

                private void Inscribir_al_Estudiante_A_Un_Curso_Load( object sender, EventArgs e ) {
                        Nombre_Del_Estudianete_txt.Text = Estudiante.Nombre;
                        Apellido_Del_Estudiante_txt.Text = Estudiante.Apellido;
                        CargarTabla_De_Cursos();
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
                private void Nombre_Profesor_txt_TextChanged( object sender, EventArgs e ) {

                }



                long Id_del_Curso_Seleccionado = 0;
                Cursos Curso_Seleccionado;
                private void Listado_De_Cursos_dg_CellClick( object sender, DataGridViewCellEventArgs e ) {
                        try
                        {
                                // Verifica que el click no sea en el encabezado
                                if (e.RowIndex >= 0)
                                {
                                        // Obtiene la fila clickeada
                                        DataGridViewRow fila = Listado_De_Cursos_dg.Rows[e.RowIndex];

                                        // Obtiene el valor de la primera celda (ID)
                                        Id_del_Curso_Seleccionado = Convert.ToInt64(fila.Cells[0].Value);

                                        // Muestra el ID (corrigiendo el nombre de la variable)
                                        // MessageBox.Show($" has seleccionado el profesor con el Codigo: {Id_Profesor_Seleccionado}");

                                        try
                                        {

                                                using (var context = new AppDbContext(OpcionsBuilder_c.getConnection().Options))
                                                {
                                                        Curso_Seleccionado = context.Cursos.FirstOrDefault(x => x.Id == Id_del_Curso_Seleccionado);
                                                        if (Curso_Seleccionado == null)
                                                        {
                                                                MessageBox.Show("Curso no encontrado", "mensaje de busqueda");
                                                                return;
                                                        }

                                                        MessageBox.Show($"Has seleccionado al profesor {Curso_Seleccionado}.\nPuedes realizar las acciones de edicion, eliminacion y ver mas informacion.", "Mensaje De Seleeccion.");
                                                        return;
                                                }



                                        } catch (Exception ex)
                                        {
                                                MessageBox.Show("Ocurrio un error en Al seleccionar al Curso" + ex, "Error detectado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                }
                        } catch (Exception ex)
                        {
                                // Manejo de errores (opcionalmente puedes mostrar el error)
                                MessageBox.Show("Error al obtener el ID: " + ex.Message);
                        }
                }

                private void materialButton17_Click( object sender, EventArgs e ) {

                        if (Curso_Seleccionado == null)
                        {
                                MessageBox.Show("Por favor, selecciona un curso antes de inscribir al estudiante.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                        }

                        var mensaje = MessageBox.Show($"Quiere Agregar al estudiante {Nombre_Del_Estudianete_txt.Text} al curso {Curso_Seleccionado.Nombre}?", "Mensaje de confirmacion para el agregado.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (mensaje == DialogResult.No)
                        {
                                return;
                        }

                        try
                        {
                                R_Estudiantes_Cursos Nuevo_Estudiante_Curso = new R_Estudiantes_Cursos();
                                Nuevo_Estudiante_Curso.Id_Curso = Curso_Seleccionado.Id;
                                Nuevo_Estudiante_Curso.Id_Estudiante = Estudiante.Id;
                                using (var context = new AppDbContext(OpcionsBuilder_c.getConnection().Options))
                                {
                                        var query = context.R_Estudiantes_Cursos.FirstOrDefault(x => x.Id_Estudiante == Estudiante.Id && x.Id_Curso == Curso_Seleccionado.Id);
                                        if (query != null)
                                        {
                                                MessageBox.Show("El estudiante ya esta inscripto al curso", "Error detectado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                return;
                                        }
                                        context.R_Estudiantes_Cursos.Add(Nuevo_Estudiante_Curso);
                                        context.SaveChanges();
                                        MessageBox.Show($"El estudiante {Estudiante.Nombre} ha sido inscripto al curso {Curso_Seleccionado.Nombre} correctamente.", "Estudiante Agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }



                        } catch (Exception ex)
                        {
                                MessageBox.Show("Ha ocurrido un erro al crear al Estudiante\n" + ex, "Error detectado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }
        }
}
