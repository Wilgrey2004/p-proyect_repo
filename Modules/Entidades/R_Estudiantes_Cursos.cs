using p_proyect.Modules.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace p_proyect.Modules.Entidades
{
        public class R_Estudiantes_Cursos
        {
                [Key]
                [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                public long Id { get; set; }

                [DisplayName("Codigo del Estudiante")]
                [ForeignKey("Estudiante")]
                public long Id_Estudiante { get; set; }
                public Estudiante Estudiante { get; set; }

                [DisplayName("Estado del estudiante")]
                public Estado_Del_Estudiante_En_El_Curso Estado_Estudiante { get; set; } = Estado_Del_Estudiante_En_El_Curso.Activo;

                [DisplayName("Codigo del Curso")]
                [ForeignKey("Cursos")]
                public long Id_Curso { get; set; }
                public Cursos Cursos { get; set; }
        }
}
