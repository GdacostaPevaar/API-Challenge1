using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge1.Entities
{
    public class Producto
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Display(Name = "Tipode de  producto")]
        public string Tipodeproducto { get; set; }

  
        public decimal Valor { get; set; }

        [Display(Name = "Fecha Compra")]

        public DateTime FechaCompra { get; set; }


        [Display(Name = "Estado del producto" )]
        public bool EstadoDelProducto { get; set; }


    }
}
