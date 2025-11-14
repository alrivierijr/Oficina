using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oficina.Models;

namespace Oficina.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.InclusaoData).IsRequired();

            builder.Property(c => c.InclusaoUsuarioId).IsRequired();

            builder.Property(c => c.Nome).IsRequired().HasMaxLength(50);

            builder.HasIndex(c => c.Email).IsUnique();

            builder.Property(c => c.Email).IsRequired().HasMaxLength(40);

            builder.Property(c => c.Senha).IsRequired().HasMaxLength(20);

        }
    }
}
