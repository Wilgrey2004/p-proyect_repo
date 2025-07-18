using MaterialSkin;
using MaterialSkin.Controls;
using p_proyect.Modules.Entidades.BindinLists;
using p_proyect.Modules.Entidades.responses;
using p_proyect.Modules.Enums;
using p_proyect.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p_proyect.Modules.Entidades.Formularios.Estudiantes
{
        public partial class Edicion_Estudiante_F : MaterialForm
        {
                public Estudiante Estudiante_A_Editar = new Estudiante();
                public Edicion_Estudiante_F() {
                        InitializeComponent();

                        var materialSkinManager = MaterialSkinManager.Instance;
                        materialSkinManager.AddFormToManage(this);
                        materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                        materialSkinManager.ColorScheme = new ColorScheme(Primary.Amber600, Primary.Amber700, Primary.Amber800, Accent.LightBlue400, TextShade.BLACK);

                }

                private void Cargar_Info_Del_Estudiante() {
                        try
                        {

                                Nombre_Del_Estudiante_txt.Text = Estudiante_A_Editar.Nombre;
                                Apellido_Del_Estudiante_txt.Text = Estudiante_A_Editar.Apellido;
                                Edad_Del_Estudiante_txt.Text = Estudiante_A_Editar.Edad.ToString();
                                Cedula_Del_Estudiante_txt.Text = Estudiante_A_Editar.Cedula;
                                Apodo_Del_Estudiante_txt.Text = Estudiante_A_Editar.Apodo ?? "";
                                Genero_Del_Estudiante_com.SelectedItem = Estudiante_A_Editar.Sexo;

                                DateTime fecha = Estudiante_A_Editar.Fecha_De_Inscripcion == null ? DateTime.Now : Estudiante_A_Editar.Fecha_De_Inscripcion;
                                if (fecha < Fecha_Del_Estudiante_dp.MinDate)
                                {
                                        Fecha_Del_Estudiante_dp.Value = Fecha_Del_Estudiante_dp.MinDate;
                                } else
                                {
                                        Fecha_Del_Estudiante_dp.Value = fecha;
                                }

                                Direccion_Del_Estudiante_txt.Text = Estudiante_A_Editar.Direccion;
                                Municipio_Del_Estudiante_txt.Text = Estudiante_A_Editar.Municipio;
                                Sector_Del_Estudiante_txt.Text = Estudiante_A_Editar.Sector;
                                Nombre_Del_Tutor_Del_Estudiante_txt.Text = Estudiante_A_Editar.Nombre_del_tutor;
                                Numero_Del_Tutor_Del_Estudiante_txt.Text = Estudiante_A_Editar.Telefono_del_tutor;
                                Estado_Actual_Combo.SelectedItem = Estudiante_A_Editar.Estado_Actual_Del_Estudiante;
                                Nivel_Educacional_Del_Estudiante_com.SelectedItem = Estudiante_A_Editar.Nivel_De_Educacion;
                                Estado_Actual_Combo.SelectedItem = Estudiante_A_Editar.Estado_Actual_Del_Estudiante;


                        } catch (Exception ex)
                        {
                                MessageBox.Show("Error Al cargar la informacion del usuario..\n" + ex);
                        }
                }
                private void Edicion_Estudiante_F_Load( object sender, EventArgs e ) {
                        Cargar_Tabla_De_Estudiantes();
                        Cargar_Combobox_Estado();
                        Cargar_Combo_Box_Genero();
                        Cargar_Combo_Box_Si_No();
                        
                        Cargar_Combo_Box_Nivel_Educacional();
                        Cargar_Info_Del_Estudiante();
                }
                BindingList<Estudiantes_Response> Lista_De_Estudiantes = new BindingList<Estudiantes_Response>();

                private void Cargar_Combo_Box_Si_No() {
                        Estudia_En_La_Actualidad_com.DataSource = Enum.GetValues(typeof(Si_No_Enums));
                        Estudia_En_La_Actualidad_com.SelectedIndex = 0; // Selecciona el primer elemento por defecto
                }

                private void Cargar_Tabla_De_Estudiantes() {
                        Estudiantes_BindingList estudiantes_BindingList = new Estudiantes_BindingList();
                        Lista_De_Estudiantes.Clear();
                        Lista_De_Estudiantes = estudiantes_BindingList.GetList();
                        Estudiantes_dataview.DataSource = Lista_De_Estudiantes;
                }

                private void Cargar_Combo_Box_Nivel_Educacional() {
                        Nivel_Educacional_Del_Estudiante_com.DataSource = Enum.GetValues(typeof(Nivel_Educacional));
                        Nivel_Educacional_Del_Estudiante_com.SelectedIndex = 0; // Selecciona el primer elemento por defecto
                }
                private void Cargar_Combobox_Estado() {
                        Estado_Actual_Combo.DataSource = Enum.GetValues(typeof(Estados_Generales));
                        Estado_Actual_Combo.SelectedItem = Estudiante_A_Editar.Estado_Actual_Del_Estudiante;
                }

                private void Cargar_Combo_Box_Genero() {
                        Genero_Del_Estudiante_com.DataSource = Enum.GetValues(typeof(Sexo));
                }


                private Estudiante Regresar_Estudiante() {
                        

                        Estudiante_A_Editar.Nombre = Nombre_Del_Estudiante_txt.Text.Trim();
                        Estudiante_A_Editar.Apellido = Apellido_Del_Estudiante_txt.Text.Trim();
                        Estudiante_A_Editar.Edad = Convert.ToInt32(Edad_Del_Estudiante_txt.Text.Trim());
                        Estudiante_A_Editar.Cedula = Cedula_Del_Estudiante_txt.Text.Trim();
                        Estudiante_A_Editar.Sexo = (Sexo)Genero_Del_Estudiante_com.SelectedItem;
                        Estudiante_A_Editar.Apodo = Apodo_Del_Estudiante_txt.Text.Trim();
                        Estudiante_A_Editar.Direccion = Direccion_Del_Estudiante_txt.Text.Trim();
                        Estudiante_A_Editar.Municipio = Municipio_Del_Estudiante_txt.Text.Trim();
                        Estudiante_A_Editar.Sector = Sector_Del_Estudiante_txt.Text.Trim();
                        Estudiante_A_Editar.Nombre_del_tutor = Nombre_Del_Tutor_Del_Estudiante_txt.Text.Trim();
                        Estudiante_A_Editar.Telefono_del_tutor = Numero_Del_Tutor_Del_Estudiante_txt.Text.Trim();
                        Estudiante_A_Editar.Estado_Actual_Del_Estudiante = (Estados_Generales)Estado_Actual_Combo.SelectedItem;
                        Estudiante_A_Editar.Nivel_De_Educacion = (Nivel_Educacional)Nivel_Educacional_Del_Estudiante_com.SelectedItem;
                        Estudiante_A_Editar.Fecha_De_Inscripcion = Fecha_Del_Estudiante_dp.Value;
                        Estudiante_A_Editar.Estado = (Estados_Generales) Estado_Actual_Combo.SelectedItem;

                        return Estudiante_A_Editar;
                }
                private async void  materialButton14_Click( object sender, EventArgs e ) {
                        var mensaje = MessageBox.Show($"Quieres guardar los cambios?", "Mensaje de confirmacion para el agregado.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (mensaje == DialogResult.No)
                        {
                                return;
                        }

                        try
                        {

                                using (var context = new AppDbContext(OpcionsBuilder_c.getConnection().Options))
                                {
                                        context.Estudiantes.Update(Regresar_Estudiante());
                                        await context.SaveChangesAsync();
                                        Cargar_Tabla_De_Estudiantes();
                                        MessageBox.Show("Estudiante actualizado correctamente", "Actualizacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }



                        } catch (Exception ex)
                        {
                                MessageBox.Show("Ha ocurrido un error al actualizar al estudiante\n" + ex);
                        }
                }
        }
}
