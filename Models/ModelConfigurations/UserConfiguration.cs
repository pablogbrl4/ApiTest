using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebTeste.Models.ModelConfigurations
{
    public class UserConfiguration : BaseConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("User");

            builder.Property(prop => prop.Login)
                .IsRequired();

            builder.HasIndex(prop => prop.Login).IsUnique();

            builder.Property(prop => prop.password)
                .IsRequired();

            builder.Property(prop => prop.Role)
                .IsRequired();

        }
    }
}
