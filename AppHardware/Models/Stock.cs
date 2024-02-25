using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppHardware.Models
{
    public class Stock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? ProductoId { get; set; }
        [Display(Name = "Nombre del producto")]
        [Required(ErrorMessage = "Seleccione el producto")]
        [ForeignKey("ProductoId")]
        public Producto Producto { get; set; }

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "Ingrese la cantidad")]
        [Range(0, int.MaxValue, ErrorMessage = "La Cantidad debe ser mayor o igual a cero.")]
        public int Cantidad { get; set; }
    }
}
