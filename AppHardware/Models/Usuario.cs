using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppHardware.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Ingrese el nombre")]
        public String Nombre { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Ingrese el apellido")]
        public String Apellido { get; set; }

        [Display(Name = "¿Es IT?")]
        public bool isIT {get; set; }

        public virtual ICollection<Registro> Registros { get; set; }

        public String NombreCompleto
        {
            get
            {
                return Nombre + " " + Apellido;
            }
        }

    }
}
