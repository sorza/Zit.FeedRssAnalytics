using Microsoft.EntityFrameworkCore;
using Zit.FeedRssAnalytics.Domain.Entities;

namespace Zit.FeedRssAnalytics.Infra.Data.ORM
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<ArticleMatrix>? ArticleMatrices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Busca em todas as propriedades do tipo 'string' de todas as tabelas
            // e ajusta seu tamanho para varchar(90)
            foreach(var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany( e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(90)");
            }

            //Altera o comportamento padrão do Delete para não deletar em cascata
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            //Aplica a 'customização' dos campos definidas no Mapping
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
