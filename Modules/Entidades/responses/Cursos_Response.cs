using p_proyect.Modules.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p_proyect.Modules.Entidades.request
{
        public class Cursos_Response
        {
                public long Id { get; set; }

                [Display(Name = "Nombre del curso")]
                public string Nombre { get; set; }
                [Display(Name = "Descripcion del curso")]
                public string Descripcion { get; set; }

                [Display(Name = "Dia en el que se imparte el curso")]
                public Dias_De_La_Semana Dia_Curso { get; set; } = Dias_De_La_Semana.Sabado;

                [Display(Name = "Hoara de inicio")]
                public TimeSpan Hora_De_Inicio { get; set; } = new TimeSpan(8, 0, 0); // 8:00am

                [Display(Name = "Hora de finalizacion")]
                public TimeSpan Hora_De_Finalizacion { get; set; } = new TimeSpan(12, 0, 0); // 12:00pm

                [Display(Name = "Nombre del Profesor")]
                public string Nombre_Del_Profesor { get; set; }

                [Display(Name = "Cantidad De estudiantes")]
                public int Cantidad_De_Estudiantes { get; set; } = 0;

                [Display(Name = "Costo del curso total")]
                public decimal Costo_Del_Curso { get; set; } = 0;

                [Display(Name = "Costo de inscripcion")]
                public decimal Inscripcion { get; set; } = 0;

                [Display(Name = "Estado del curso")]
                public Estados_Generales Estado_Actual_Del_Curso { get; set; } = Estados_Generales.Activo;
        }
}
