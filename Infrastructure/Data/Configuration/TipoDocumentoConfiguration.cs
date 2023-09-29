using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Data.Configuration;
public class TipoDocumentoConfiguration : IEntityTypeConfiguration<TipoDocumento>
{
    public void Configure(EntityTypeBuilder<TipoDocumento> builder)
    {
        builder.ToTable("tipodocumento");

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id);

        builder.Property(e => e.Descripcion).IsRequired().HasMaxLength(50);
        
    }
}
