using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppHardware.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductoId { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Categoría")]
        [Required(ErrorMessage = "Ingrese la categoría del producto")]
        public Categoria CatId { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Marca del producto")]
        [Required(ErrorMessage = "Ingrese la marca del producto")]
        public String MarcaNombre { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "Ingrese el modelo del producto")]
        public String ModeloNombre { get; set; }

        [Display(Name = "Descripción")]
        public String ProductoDescripcion { get; set; }
        
        [NotMapped]
        public String NombreCompleto
        {
            get
            {
                return MarcaNombre + " " + ModeloNombre;
            }
         }

    }
}
