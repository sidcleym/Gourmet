
using Gourmet.Domain.IRepository;
using Gourmet.Domain.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Gourmet.Persistence.Infra
{
    public class DataContext : DbContext
    {
        public DataContext() : base("Gourmet")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;            
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Prato> Prato { get; set; }
        public DbSet<Restaurante> Restaurante { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties<string>().Configure(p=> p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new UsuarioConfigurations());
           // Database.SetInitializer < DataContext > (new DropCreateDatabaseIfModelChanges<DataContext>());

            //base.OnModelCreating(modelBuilder);
        }
    }
}
