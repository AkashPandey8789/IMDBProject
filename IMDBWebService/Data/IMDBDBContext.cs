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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>()
                .HasKey(am => new { am.ActorId, am.MovieId });

            modelBuilder.Entity<MovieActor>()
                .HasOne(am => am.Actor)
                .WithMany(a => a.MovieActors)
                .HasForeignKey(am => am.ActorId);

            modelBuilder.Entity<MovieActor>()
                .HasOne(am => am.Movie)
                .WithMany(m => m.MovieActors)
                .HasForeignKey(am => am.MovieId);
        }
    }
}
