using MaterialSkin;
using MaterialSkin.Controls;
using p_proyect.Modules;
using p_proyect.Utils;
using System;
using System.Linq;
using System.Windows.Forms;

namespace p_proyect
{
        public partial class Inicio_De_Secion : MaterialForm
        {

                public Inicio_De_Secion() {
                        InitializeComponent();

                        var materialSkinManager = MaterialSkinManager.Instance;
                        materialSkinManager.AddFormToManage(this);
                        materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                        materialSkinManager.ColorScheme = new ColorScheme(Primary.Amber600, Primary.Amber700, Primary.Amber800, Accent.Green400, TextShade.WHITE);


                }

                private void Form1_Load( object sender, EventArgs e ) {

                }

                private void bunifuTextBox2_TextChanged( object sender, EventArgs e ) {

                }

                private void bunifuLabel1_Click( object sender, EventArgs e ) {

                }

                private void bunifuButton1_Click( object sender, EventArgs e ) {

                }

                private void bunifuButton21_Click( object sender, EventArgs e ) {

                }

                private void bunifuLabel3_Click( object sender, EventArgs e ) {

                }

                private void materialButton1_Click( object sender, EventArgs e ) {
                        //string lista = "";
                        try
                        {
                                string nombreABuscar = Nombre_Usuario_txt.Text.Trim();
                                string passAComparar = Pass_Usuario_txt.Text.Trim();
                                using (var context = new AppDbContext(OpcionsBuilder_c.getConnection().Options))
                                {
                                        var Usuario = context.Empleado_Admins.FirstOrDefault(x => x.Nombre_del_Administrador == nombreABuscar);

                                        if (Usuario == null)
                                        {
                                                MessageBox.Show("El usuario no existe, por favor verifique el nombre de usuario o registrese si no tiene una cuenta.");
                                                return;
                                        }
                                        if (Usuario.Pass != passAComparar)
                                        {
                                                MessageBox.Show("La contraseña es incorrecta, por favor verifique la contraseña.");
                                                return;
                                        }

                                        MessageBox.Show($"Bienvenido {Usuario.ToString()}", "Mensaje de bienvenida al sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        
                                        this.Hide();
                                        Gestion gestion = new Gestion();
                                        gestion.admin = Usuario;
                                        gestion.Show();
                                }



                        } catch (Exception ex)
                        {
                                MessageBox.Show("Ocurrio un error en el inicio de secion...\n" + ex);
                        }
                }
        }
}
