using Microsoft.EntityFrameworkCore;

namespace MovieContexts.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
                : base(options)
        {
        }


        public DbSet<Projets.Models.Projet> Projets { get; set; }
        public DbSet<Exigeances.Models.Exigeance> Exigeance { get; set; }

        public DbSet<TypeExigeances.Models.TypeExigeance> TypeExigeance { get; set; }

        public DbSet<Taches.Models.Tache> taches { get; set; }

        public DbSet<Resps.Models.Resp> resp { get; set; }

        public DbSet<Exigeance_Taches.Models.Exigeance_Tache> Exigeance_Tache { get; set; }

        public DbSet<Jalons.Models.Jalon> jalon { get; set; }

        


    }
}