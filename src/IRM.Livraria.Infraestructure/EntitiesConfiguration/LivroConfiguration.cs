using IRM.Livraria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRM.Livraria.Infraestructure.EntitiesConfiguration;

public class LivroConfiguration : IEntityTypeConfiguration<Livro>
{
    public void Configure(EntityTypeBuilder<Livro> builder)
    {
        builder.HasKey(t => t.LivroId);
        builder.Property(t => t.Titulo).HasMaxLength(150).IsRequired();
        builder.Property(t => t.Autor).HasMaxLength(100).IsRequired();
        builder.Property(t => t.Lancamento).IsRequired();
        builder.Property(t => t.Capa).HasMaxLength(200);
    }
}
