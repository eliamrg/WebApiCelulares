using Microsoft.EntityFrameworkCore;
using WebApiCelulares.Entidades;

namespace WebApiCelulares
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) 
        { 
        
        }
        public DbSet<Celular> Celulares { get; set;}
    }
}
