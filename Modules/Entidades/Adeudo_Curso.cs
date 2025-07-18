using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace p_proyect.Modules.Entidades
{
        public class Adeudo_Curso
        {
                [Display(Name = "Codigo De la Deuda")]
                [Key]
                [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                public long Id { get; set; }

                [Display(Name = "Curso del adeudo")]
                [ForeignKey("Curso")]
                public long Id_Curso { get; set; }

                public Cursos Curso { get; set; }

                [Display(Name = "Codigo del Estudiante")]
                [ForeignKey("Estudiante")]
                public long Id_Estudiante { get; set; }
                public Estudiante Estudiante { get; set; }

                [Display(Name = "Total pagado")]
                public decimal Total_Pagado { get; set; } = 0;

                [Display(Name = "Restante a pagar")]
                public decimal Restante_A_Pagar { get; set; } = 0;

                [Display(Name = "Deudo total")]
                public decimal Adeudo { get; set; } = 0;

                public Adeudo_Curso() {

                        this.Adeudo = Curso.Costo_Del_Curso;
                        this.Restante_A_Pagar = Curso.Costo_Del_Curso - Total_Pagado;
                }
        }
}
