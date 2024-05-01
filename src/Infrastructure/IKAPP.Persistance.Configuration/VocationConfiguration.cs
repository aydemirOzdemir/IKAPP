using IKAPP.Domain.Entities.AggregateModels.Vocations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Persistance.Configuration;

public class VocationConfiguration : AuditableEntityTypeConfiguration<Vocation> 
{ 
    public override void Configure(EntityTypeBuilder<Vocation> builder)
    {
        builder.HasMany(x => x.Personeller).WithOne(x => x.Vocation).HasForeignKey(x => x.VocationId);
        builder.HasData(Vocation.CreateVocation(new()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Satiş Müdürü"
        }), Vocation.CreateVocation(new()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Developer",
        }));

        base.Configure(builder);
    }

}
