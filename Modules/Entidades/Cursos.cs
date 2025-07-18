using p_proyect.Modules.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace p_proyect.Modules.Entidades
{
        public class Cursos
        {
                [Key]
                [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                public long Id { get; set; }
                [Required]
                [DisplayName("Nombre del curso")]
                public string Nombre { get; set; }
                [DisplayName("Descripcion del curso")]
                public string Descripcion { get; set; }

                [DisplayName("Dia en el que se imparte el curso")]
                public Dias_De_La_Semana Dia_Curso { get; set; } = Dias_De_La_Semana.Sabado;

                [DisplayName("Hoara de inicio")]
                public TimeSpan Hora_De_Inicio { get; set; } = new TimeSpan(8, 0, 0); // 8:00am

                [DisplayName("Hora de finalizacion")]
                public TimeSpan Hora_De_Finalizacion { get; set; } = new TimeSpan(12, 0, 0); // 12:00pm
                
                [ForeignKey("Profesor")]
                public long Profesor_Id { get; set; }
                public Profesor Profesor { get; set; }

                [DisplayName("Cantidad De estudiantes")]
                public int Cantidad_De_Estudiantes { get; set; } = 0;

                [DisplayName(  "Costo del curso total")]
                public decimal Costo_Del_Curso { get; set; } = 0;

                [DisplayName(  "Costo de inscripcion")]
                public decimal Inscripcion { get; set; } = 0;


                [DisplayName( "Estado del curso")]
                public Estados_Generales Estado_Actual_Del_Curso { get; set; } = Estados_Generales.Activo;
                public override string ToString() {
                        return $"{Nombre}";
                }
        }
}
