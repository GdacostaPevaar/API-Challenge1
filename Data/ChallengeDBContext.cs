using Challenge1.Entities;
using Microsoft.EntityFrameworkCore;

namespace Challenge1.Data
{
    public class ChallengeDBContext:DbContext
    {

        public ChallengeDBContext(DbContextOptions options) : base(options)
        {


        }


    

        public DbSet<Producto> Productos { get; set; }  
    }
}
