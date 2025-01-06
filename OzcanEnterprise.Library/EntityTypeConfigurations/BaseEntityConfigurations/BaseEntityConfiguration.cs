using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzcanEnterprise.Library.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;

namespace OzcanEnterprise.Library.EntityTypeConfigurations.BaseEntityConfigurations
{
    public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime2");
            builder.Property(e => e.ModifiedDate).HasColumnType("datetime2").IsRequired(false);
        }
    }
}
