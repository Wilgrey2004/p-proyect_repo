using p_proyect.Modules.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p_proyect.Modules.Entidades.responses
{
        public class R_Relacion_Cursos_Estudiantes
        {

                [DisplayName("Nombre del estudiante")]
                public string Nombre_Estudiante { get; set; }

                [DisplayName("Apellido del estudiante")]
                public string Apellido_Estudiante { get; set; }

                [DisplayName("Edad")]
                public int Edad_Estudiante { get; set; }

                [DisplayName("Genero")]
                public Sexo Sexo_Estudiante { get; set; }

                [DisplayName("Nombre del curso")]
                public string Nombre_Curso { get; set; }
                [DisplayName("Descripcion del curso")]
                public string Descripcion_Curso { get; set; }

                [DisplayName("Dia en el que se imparte el curso")]
                public Dias_De_La_Semana Dia_Curso { get; set; } = Dias_De_La_Semana.Sabado;

                [DisplayName("Hoara de inicio")]
                public TimeSpan Hora_De_Inicio_curso { get; set; } = new TimeSpan(8, 0, 0); // 8:00am

                [DisplayName("Hora de finalizacion")]
                public TimeSpan Hora_De_Finalizacion_curso { get; set; } = new TimeSpan(12, 0, 0); // 12:00pm
        }
}
