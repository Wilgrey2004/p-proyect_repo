using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p_proyect.Modules.Entidades.request
{
        public class Profesor_Request
        {
                [Required]
                [Display(Name = "Nombre del profesor")]
                public string Nombre { get; set; }
                [Display(Name = "Apellido del profesor")]
                public string Apellido { get; set; }

                [Display(Name = "Tel. Profeosr")]
                public string Numero_De_Telefono { get; set; }
        }
}
