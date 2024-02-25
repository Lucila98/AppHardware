using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppHardware.Models
{
    public class Registro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RegistroId { get; set; }

        public int UsuarioId { get; set; }
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "Seleccione el usuario")]
        public virtual Usuario Usuario { get; set; }
        

        public int ProductoId { get; set; }
        [Display(Name = "Nombre del producto")]
        [Required(ErrorMessage = "Seleccione el producto")]
        public virtual Producto Producto { get; set; }


        [Display(Name = "Fecha de entrega")]
        [Required(ErrorMessage = "Ingrese una fecha válida")]
        public DateTime FechaEntrega { get; set; }


        [Display(Name = "Fecha de devolución")]
        public DateTime? FechaDevolucion { get; set; }

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "Ingrese la cantidad")]
        [Range(1, int.MaxValue, ErrorMessage = "La Cantidad debe ser mayor a cero.")]
        public int Cantidad { get; set; }

    }
}
