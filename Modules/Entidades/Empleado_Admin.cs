using p_proyect.Modules.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace p_proyect.Modules.Entidades
{
        public class Empleado_Admin
        {
                [Key]
                [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                public long Id { get; set; }

                [Display(Name = "Nombre del Empleado")]
                public string Nombre_del_Administrador { get; set; }

                [Display(Name = "Apellido del Empleado")]
                public string Apellido_del_Administrador { get; set; }

                [Display(Name = "Numero de telefono")]
                public string Numero_de_Telefono { get; set; }

                [Display(Name = "Cotraseña")]
                public string Pass { get; set; }

                [Display(Name = "Contraseña confirmada")]
                public string Pass_confirm { get; set; }

                [Display(Name = "Estado del Empleado")]
                public Estados_Generales Estado { get; set; } = Estados_Generales.Activo;

                public override string ToString() {
                        return $"{Nombre_del_Administrador} {Apellido_del_Administrador}";
                }

        }
}
