using MaterialSkin;
using MaterialSkin.Controls;
using p_proyect.Modules.Entidades.BindinLists;
using p_proyect.Utils;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace p_proyect.Modules.Entidades.Formularios.Profesores
{
        public partial class Asignar_Profesor_A_Un_Curso : MaterialForm
        {
                public Profesor Profesor_Seleccionado { get; set; }
                public Asignar_Profesor_A_Un_Curso() {
                        InitializeComponent();

                        var materialSkinManager = MaterialSkinManager.Instance;
                        materialSkinManager.AddFormToManage(this);
                        materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                        materialSkinManager.ColorScheme = new ColorScheme(Primary.Amber600, Primary.Amber700, Primary.Amber800, Accent.LightBlue400, TextShade.BLACK);
                }

                private void Asignar_Profesor_A_Un_Curso_Load( object sender, EventArgs e ) {
                        Nombre_Profesor_txt.Text = Profesor_Seleccionado.Nombre + " " + Profesor_Seleccionado.Apellido;
                        Numero_Del_Profesor_txt.Text = Profesor_Seleccionado.Numero_De_Telefono;
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

                                                        MessageBox.Show($"Has seleccionado al profesor {Profesor_Seleccionado} y lo asignaras al curso {Curso_Seleccionado}.", "Mensaje De Seleeccion.");
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

                private void materialButton18_Click( object sender, EventArgs e ) {
                        var mensaje = MessageBox.Show($"Quiere Asignar al profesor {Nombre_Profesor_txt.Text} al curso {Curso_Seleccionado.Nombre}?", "Mensaje de confirmacion para el agregado.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (mensaje == DialogResult.No)
                        {
                                return;
                        }

                        try
                        {

                                using (var context = new AppDbContext(OpcionsBuilder_c.getConnection().Options))
                                {
                                        Curso_Seleccionado.Profesor_Id = Profesor_Seleccionado.Id;
                                        context.Cursos.Update(Curso_Seleccionado);
                                        context.SaveChanges();
                                        MessageBox.Show($"El profesor {Profesor_Seleccionado.Nombre} {Profesor_Seleccionado.Apellido} ha sido asignado al curso {Curso_Seleccionado.Nombre} correctamente.", "Mensaje de agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        CargarTabla_De_Cursos();
                                }



                        } catch (Exception ex)
                        {
                                MessageBox.Show("Ocurrio un error al agregar al profesor al curso...\n" + ex);
                        }
                }
        }
}
