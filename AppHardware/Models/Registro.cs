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

        public int? UsuarioId { get; set; }
        //[DataType(DataType.Text)]
        [Required(ErrorMessage = "Seleccione el usuario")]
        [Display(Name = "Usuario")]
        public virtual Usuario Usuario { get; set; }
        

        public int? ProductoId { get; set; }
        //[DataType(DataType.Text)]
        [Display(Name = "Nombre del producto")]
        [Required(ErrorMessage = "Seleccione el producto")]
        public virtual Producto Producto { get; set; }


        [Display(Name = "Fecha de entrega")]
        [Required(ErrorMessage = "Ingrese una fecha válida")]
        public DateTime FechaEntrega { get; set; }


        [Display(Name = "Fecha de devolución")]
        public DateTime FechaDevolucion { get; set; }
        
    }
}
