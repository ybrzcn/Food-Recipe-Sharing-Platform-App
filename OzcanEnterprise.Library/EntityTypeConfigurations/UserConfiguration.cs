using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzcanEnterprise.Library.Entities;
using OzcanEnterprise.Library.EntityTypeConfigurations.BaseEntityConfigurations;

namespace OzcanEnterprise.Library.EntityTypeConfigurations
{
    public class UserConfiguration : PersonBaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.IsActive).IsRequired();
            builder.Property(u => u.LastLoginDate).HasColumnType("datetime2").IsRequired(false);

            builder.HasMany(u => u.Recipes)
                   .WithOne(r => r.Author)
                   .HasForeignKey(r => r.AuthorId);

            base.Configure(builder);
        }
    }
}
