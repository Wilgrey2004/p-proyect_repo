using p_proyect.Modules.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p_proyect.Modules.Entidades.responses
{
        public class Estudiantes_Response
        {
                public long Id { get; set; }

                [Display(Name = "Nombre del estudiante")]
                public string Nombre { get; set; }

                [Display(Name = "Apellido del estudiante")]
                public string Apellido { get; set; }

                [Display(Name = "Edad")]
                public int Edad { get; set; }

                [Display(Name = "Genero")]
                public Sexo Sexo { get; set; }

                [Display(Name = "Apodo / Sobre nombre")]
                public string Apodo { get; set; }

                [Display(Name = "Numero de cedula")]
                public string Cedula { get; set; }

                [Display(Name = "Direccion")]

                public string Direccion { get; set; }
                [Display(Name = "Municipio")]

                public string Municipio { get; set; }

                [Display(Name = "Secctor")]
                public string Sector { get; set; }

                [Display(Name = "Nombre del tutor")]
                public string Nombre_del_tutor { get; set; } = "";

                [Display(Name = "Tel. Tutor")]
                public string Telefono_del_tutor { get; set; } = "";

                // Datos Educacionales

                [Display(Name = "Estudia en la actualidad")]

                public Si_No_Enums Estudia_En_La_Actualidad { get; set; } = Si_No_Enums.Si;

                [Display(Name = "Nivel de Educacion")]
                public Nivel_Educacional Nivel_De_Educacion { get; set; } = Nivel_Educacional.Secundaria;

                //fechas

                [Display(Name = "Fecha de Inscripcion")]
                public DateTime Fecha_De_Inscripcion { get; set; }


                [Display(Name = "Fecha de Insercion Al sistema")]
                public DateTime Fecha_De_insercion_al_sistema { get; set; } = DateTime.Now;
                [Display(Name = "Cantidad De cursos inscritos")]
                public short Cantidad_De_Cursos_A_Los_Que_Esta_Inscrito { get; set; }

                // Empleado que lo a inscrito

                [Display(Name = "Empleado que lo inscribio")]
                public string Nombre_del_Empleado_Que_Lo_Inscribio { get; set; }
        }
}
