using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzcanEnterprise.Library.Entities.BaseEntities;

namespace OzcanEnterprise.Library.EntityTypeConfigurations.BaseEntityConfigurations
{
    public class PersonBaseEntityConfiguration<TEntity> : BaseEntityConfiguration<TEntity> where TEntity : PersonBaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(e => e.UserName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(e => e.FirstName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(e => e.LastName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(e => e.Email)
                   .HasMaxLength(100)
                   .IsRequired();

            base.Configure(builder);
        }
    }
}
