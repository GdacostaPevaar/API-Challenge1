using Challenge1.Data;
using Challenge1.Entities;
using Microsoft.EntityFrameworkCore;

namespace Challenge1.Services
{
    public class ProductoRepository : GenericRepository<Producto>
    {
      


        public ProductoRepository(ChallengeDBContext context) : base(context)
        {
      
        }

     
   
    }
}
