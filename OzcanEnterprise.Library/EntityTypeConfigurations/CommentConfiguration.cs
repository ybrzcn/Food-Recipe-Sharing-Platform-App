using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OzcanEnterprise.Library.Entities;
using OzcanEnterprise.Library.EntityTypeConfigurations.BaseEntityConfigurations;

namespace OzcanEnterprise.Library.EntityTypeConfigurations
{
    public class CommentConfiguration : BaseEntityConfiguration<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c => c.Content)
                   .HasMaxLength(500)
                   .IsRequired();

            builder.HasOne(c => c.Recipe)
                   .WithMany(r => r.Comments)
                   .HasForeignKey(c => c.RecipeId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.User)
                   .WithMany(u => u.Comments)
                   .HasForeignKey(c => c.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}
