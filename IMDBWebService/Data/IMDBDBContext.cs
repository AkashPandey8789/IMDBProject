using IMDBWebService.Models;
using Microsoft.EntityFrameworkCore;

namespace IMDBWebService.Data
{
    public class IMDBDBContext:DbContext
    {
        public IMDBDBContext(DbContextOptions<IMDBDBContext> options):base(options)
        {
                
        }

        public DbSet<Movies> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
 
    }
}
