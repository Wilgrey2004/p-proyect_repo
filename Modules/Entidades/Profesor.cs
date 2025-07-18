using p_proyect.Modules.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace p_proyect.Modules.Entidades
{
        public class Profesor
        {
                [Key]
                [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                public long Id { get; set; }

                [Required]
                [Display(Name = "Nombre del profesor")]
                public string Nombre { get; set; }
                [Display(Name = "Apellido del profesor")]
                public string Apellido { get; set; }

                [Display(Name = "Tel. Profeosr")]
                public string Numero_De_Telefono { get; set; }

                [Display(Name = "Cursos Impartidos")]
                public ICollection<Cursos> Cursos_Impartidos { get; set; }
                public int Cursos_Impartidos_Count { get; set; } 

                [Display(Name = "Porcentaje de comision")]
                public decimal Porcentaje_De_Comision { get; set; } = 0;

                [Display(Name = "Pago total de comision")]
                public decimal Pago_Total_De_Comision { get; set; }
                public Estados_Generales Estados_Generales { get; set; } = Estados_Generales.Activo;

                [Display(Name = "Fecha de agregado")]
                public DateTime Fecha_de_agregado_al_sistema { get; set; } = DateTime.Now;

                [Display(Name = "Fecha de integracion al sistema")]
                public DateTime Fecha_De_Integracion_al_Sistema { get; set; }

                public override string ToString() {
                        return $"Nombre: {Nombre} {Apellido}";
                }

                public string ToString_Con_Id(string id) {
                        return $"Id: {id}/Nombre: s{Nombre} {Apellido}";
                }
        }
}
