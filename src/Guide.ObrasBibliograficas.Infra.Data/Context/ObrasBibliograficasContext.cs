using Guide.ObrasBibliograficas.Domain.Entitdades;
using Guide.ObrasBibliograficas.Infra.Data.Extensions;
using Guide.ObrasBibliograficas.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

namespace Guide.ObrasBibliograficas.Infra.Data.Context
{
    public sealed class ObrasBibliograficasContext: DbContext
    {
        public DbSet<ObraBibliografica> ObraBibliografica { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //removendo comportamento cascade delete
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                                .SelectMany(t => t.GetForeignKeys())
                                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.AddConfiguration(new ObraBibliograficaMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
