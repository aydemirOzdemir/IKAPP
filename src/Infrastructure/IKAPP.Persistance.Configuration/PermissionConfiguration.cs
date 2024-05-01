using IKAPP.Domain.Entities.AggregateModels.Permissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Persistance.Configuration;

public class PermissionConfiguration : BaseForBusinessEntityConfiguration<Permission>
{
    public override void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.HasOne(x => x.Personal).WithMany(x => x.Permissions).HasForeignKey(x => x.PersonalId);
        builder.HasOne(x => x.TypeofPermission).WithMany(x => x.Permissions).HasForeignKey(x => x.TypeofPermissionId);
        builder.HasOne(x => x.Company).WithMany(x => x.Izinler).HasForeignKey(x => x.CompanyId);
        builder.OwnsOne(x => x.PermissionTime, t =>
        {
            t.Property(x => x.DayCount).HasColumnType("tinyint").IsRequired();
            t.Property(x => x.StartedDate).IsRequired().HasColumnType("datetime");
            t.Property(x => x.FinishedDate).IsRequired().HasColumnType("datetime");
        });
        base.Configure(builder);
    }
}
