using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OzcanEnterprise.Library.Entities;
using OzcanEnterprise.Library.EntityTypeConfigurations.BaseEntityConfigurations;

namespace OzcanEnterprise.Library.EntityTypeConfigurations
{
    public class IngredientConfiguration : BaseEntityConfiguration<Ingredient>
    {
        public override void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.Property(i => i.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(i => i.Quantity)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(i => i.Unit)
                   .HasMaxLength(20)
                   .IsRequired();

            builder.HasOne(i => i.Recipe)
                   .WithMany(r => r.Ingredients)
                   .HasForeignKey(i => i.RecipeId)
                   .OnDelete(DeleteBehavior.Cascade);

            base.Configure(builder);
        }
    }

}
