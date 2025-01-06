using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzcanEnterprise.Library.Entities;
using OzcanEnterprise.Library.EntityTypeConfigurations.BaseEntityConfigurations;

namespace OzcanEnterprise.Library.EntityTypeConfigurations
{
    public class CategoryConfiguration : BaseEntityConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(c => c.Description)
                   .HasMaxLength(200)
                   .IsRequired(false);

            builder.HasMany(c => c.Recipes)
                   .WithOne(r => r.Category)
                   .HasForeignKey(r => r.CategoryId);

            base.Configure(builder);
        }
    }
}
