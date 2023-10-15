using Microsoft.EntityFrameworkCore;
using PHDevIO.Domain.Entities;
using PHDevIO.Infra.Data.EntitiesConfiguration;

namespace PHDevIO.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Fornecedor> Fornecedores;

        public DbSet<Endereco> Enderecos;

        public DbSet<Produto> Produtos;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach(var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))
                ))
            {
                property.SetColumnType("varchar(200)");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            foreach(var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }


            base.OnModelCreating(modelBuilder);
        }
    }
}
