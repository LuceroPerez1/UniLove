using Microsoft.EntityFrameworkCore;

namespace UniLove.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Define tus DbSets (tablas) aquí.
        public DbSet<Usuarios> Usuarios { get; set; }
        //public DbSet<Likes> Likes { get; set; }
        //public DbSet<Mensaje> Mensajes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la entidad Usuarios
            modelBuilder.Entity<Usuarios>()
                .HasKey(u => u.IdUsuario);

            base.OnModelCreating(modelBuilder);
        }
    }
}


