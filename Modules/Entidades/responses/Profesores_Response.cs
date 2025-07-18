using System;
using System.ComponentModel.DataAnnotations;

namespace p_proyect.Modules.Entidades.responses
{
        public class Profesores_Response
        {

                public long Id { get; set; }

                [Display(Name = "Nombre del profesor")]
                public string Nombre { get; set; }
                [Display(Name = "Apellido del profesor")]
                public string Apellido { get; set; }

                [Display(Name = "Tel. Profeosr")]
                public string Numero_De_Telefono { get; set; }

                [Display(Name = "Porcentaje de comision")]
                public decimal Porcentaje_De_Comision { get; set; } = 0;

                [Display(Name = "Pago total de comision")]
                public decimal Pago_Total_De_Comision { get; set; }

                [Display(Name = "Cursos impartidos")]
                public int Cursos_Impartidos_Count { get; set; } = 0;


                [Display(Name = "Fecha de agregado")]
                public DateTime Fecha_de_agregado_al_sistema { get; set; } = DateTime.Now;

                [Display(Name = "Fecha de integracion al sistema")]
                public DateTime Fecha_De_Integracion_al_Sistema { get; set; }
        }
}
