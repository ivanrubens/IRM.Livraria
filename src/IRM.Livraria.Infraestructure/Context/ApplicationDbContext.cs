using IRM.Livraria.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IRM.Livraria.Infraestructure.Context;

public class ApplicationDbContext : DbContext
{
    public DbSet<Livro> Livros { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
