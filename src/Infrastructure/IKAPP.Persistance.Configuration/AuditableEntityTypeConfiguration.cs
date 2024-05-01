using IKAPP.Domain.Entities.SeedWorks.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Persistance.Configuration;

public class AuditableEntityTypeConfiguration<TEntity> : BaseEntityConfiguration<TEntity> where TEntity : AuditableEntity
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.DeletedDate).IsRequired();
        builder.HasQueryFilter(e => EF.Property<bool>(e, "IsActive"));
    }
}
