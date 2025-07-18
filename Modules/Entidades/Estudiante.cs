using p_proyect.Modules.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace p_proyect.Modules.Entidades
{
        public class Estudiante
        {
                [Key]
                [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                public long Id { get; set; }

                [DisplayName("Nombre del estudiante")]
                public string Nombre { get; set; }

                [DisplayName("Apellido del estudiante")]
                public string Apellido { get; set; }

                [DisplayName("Edad")]
                public int Edad { get; set; }

                [DisplayName("Genero")]
                public Sexo Sexo { get; set; }

                [DisplayName("Apodo / Sobre nombre")]
                public string Apodo { get; set; }

                [DisplayName("Numero de cedula")]
                public string Cedula { get; set; }

                [DisplayName("Direccion")]

                public string Direccion { get; set; }
                [DisplayName("Municipio")]

                public string Municipio { get; set; }

                [DisplayName("Secctor")]
                public string Sector { get; set; }

                [DisplayName("Nombre del tutor")]
                public string Nombre_del_tutor { get; set; } = "";

                [DisplayName("Tel. Tutor")]
                public string Telefono_del_tutor { get; set; } = "";

                // Datos Educacionales

                [DisplayName("Estudia en la actualidad")]

                public Si_No_Enums Estudia_En_La_Actualidad { get; set; } = Si_No_Enums.Si;

                [DisplayName("Nivel de Educacion")]
                public Nivel_Educacional Nivel_De_Educacion { get; set; } = Nivel_Educacional.Secundaria;

                //fechas

                [DisplayName("Fecha de Inscripcion")]
                public DateTime Fecha_De_Inscripcion { get; set; } = DateTime.Now;


                [DisplayName("Fecha de Insercion Al sistema")]
                public DateTime Fecha_De_insercion_al_sistema { get; set; } = DateTime.Now;

                public short Cantidad_De_Cursos_A_Los_Que_Esta_Inscrito { get; set; }

                [DisplayName("Estado del estudiante")]
                public Estados_Generales Estado { get; set; } = Estados_Generales.Activo;

                // Empleado que lo a inscrito

                [ForeignKey("Empleado")]
                public long Id_Empleado { get; set; }
                public Empleado_Admin Empleado { get; set; }

                //Estado actual del estudiante 

                [DisplayName("Estado del estudiante")]
                public Estados_Generales Estado_Actual_Del_Estudiante { get; set; } = Estados_Generales.Activo;
                public override string ToString() {
                        return $"{Nombre} {Apellido}";
                }
        }
}
