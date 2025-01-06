using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OzcanEnterprise.Library.Entities;
using OzcanEnterprise.Library.EntityTypeConfigurations.BaseEntityConfigurations;

namespace OzcanEnterprise.Library.EntityTypeConfigurations
{
    public class RecipeConfiguration : BaseEntityConfiguration<Recipe>
    {
        public override void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.Property(r => r.Title)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(r => r.Description)
                   .IsRequired();

            builder.Property(r => r.Instructions)
                   .IsRequired();

            builder.Property(r => r.PreparationTime)
                   .IsRequired();

            builder.Property(r => r.CookingTime)
                   .IsRequired();

            builder.Property(r => r.ServingSize)
                   .IsRequired();

            builder.HasOne(r => r.Category)
                   .WithMany(c => c.Recipes)
                   .HasForeignKey(r => r.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.Author)
                   .WithMany(u => u.Recipes)
                   .HasForeignKey(r => r.AuthorId)
                   .OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }

}
