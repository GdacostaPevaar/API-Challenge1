namespace Challenge1.Models
{
    public class ProductoDTO
    {

      
        public int Id { get; set; }

  
        public string Descripcion { get; set; }

    

    
        public string Tipodeproducto { get; set; }


     

        public decimal Valor { get; set; }

        public DateTime FechaCompra { get; set; }



        public bool EstadoDelProducto { get; set; }
    }
}
