using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.EntityFrameworkCore;
using p_proyect.Utils;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace p_proyect.Modules.Entidades.Formularios.Profesores
{
        public partial class Profesor_Editar : MaterialForm
        {
                public Profesor profesor = new Profesor();
                public Profesor_Editar() {
                        InitializeComponent();

                        var materialSkinManager = MaterialSkinManager.Instance;
                        materialSkinManager.AddFormToManage(this);
                        materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                        materialSkinManager.ColorScheme = new ColorScheme(Primary.Amber600, Primary.Amber700, Primary.Amber800, Accent.Green400, TextShade.WHITE);
                }

                private void Profesor_Editar_Load( object sender, EventArgs e ) {
                        ID_Del_Profesor_txt.Text = profesor.Id.ToString();
                        Nombre_Del_Profesor_txt.Text = profesor.Nombre;
                        Apellido_Del_Profesor_txt.Text = profesor.Apellido;
                        Numero_Del_Profesor_txt.Text = profesor.Numero_De_Telefono;
                        Comision_Del_Profesor.Text = profesor.Porcentaje_De_Comision.ToString();
                        CargarTabla();
                }
                BindingList<Cursos> Cursos_Del_Profesor = new BindingList<Cursos>();
                private void CargarTabla() {
                        try
                        {

                                using (var context = new AppDbContext(OpcionsBuilder_c.getConnection().Options))
                                {
                                        var query = context.Cursos.Include(x => x.Profesor).Where(x => x.Profesor_Id == profesor.Id);
                                        Cursos_Del_Profesor = new BindingList<Cursos>(query.ToList());
                                        Cursos_Impartidos.DataSource = Cursos_Del_Profesor;
                                }



                        } catch (Exception ex)
                        {
                                MessageBox.Show("Ocurrio un error en Al Cargar lso cursos del profesor" + ex, "Error detectado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }

                private void Nombre_Profesor_txt_TextChanged( object sender, EventArgs e ) {

                }

                private void bunifuButton1_Click( object sender, EventArgs e ) {
                        var mensaje = MessageBox.Show($"Quiere Editar al profesor?", "Mensaje de confirmacion para el agregado.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (mensaje == DialogResult.No)
                        {
                                return;
                        }

                        try
                        {

                                using (var context = new AppDbContext(OpcionsBuilder_c.getConnection().Options))
                                {

                                }



                        } catch (Exception ex)
                        {
                                MessageBox.Show("Ocurrio un error en Al agregar al profesor" + ex, "Error detectado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }

                private void bunifuButton2_Click( object sender, EventArgs e ) {
                        this.Close();
                }
        }
}
