using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebTeste.Models.ModelConfigurations
{
    public class TodoConfiguration : BaseConfiguration<Todo>
    {
        public override void Configure(EntityTypeBuilder<Todo> builder)
        {
            base.Configure(builder);

            builder.ToTable("Todo");

            builder.Property(prop => prop.CreatedOn)
                .HasColumnType("TIMESTAMP(0)")
                .IsRequired();

            builder.Property(prop => prop.Body)
                .HasMaxLength(1000);

            builder.Property(prop => prop.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(prop => prop.IsCompleted)
                .IsRequired();

        }
    }
}
