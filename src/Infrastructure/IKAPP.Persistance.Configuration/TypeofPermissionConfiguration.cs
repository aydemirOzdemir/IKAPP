using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Persistance.Configuration;

public class TypeofPermissionConfiguration : AuditableEntityTypeConfiguration<TypeofPermission>
{
    public override void Configure(EntityTypeBuilder<TypeofPermission> builder)
    {
        builder.Property(x => x.Duration).IsRequired();
        builder.Property(x => x.Gender).IsRequired();

        base.Configure(builder);
    }
}
