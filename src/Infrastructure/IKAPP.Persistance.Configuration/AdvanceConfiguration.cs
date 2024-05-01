using IKAPP.Domain.Entities.AggregateModels.Advances;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Persistance.Configuration;

public class AdvanceConfiguration : BaseForBusinessEntityConfiguration<Advance>
{
    public override void Configure(EntityTypeBuilder<Advance> builder)
    {
        builder.HasOne(x => x.Personal).WithMany(x => x.Advances).HasForeignKey(x => x.PersonalId);
        builder.HasOne(x => x.Company).WithMany(x => x.Avanslar).HasForeignKey(x => x.CompanyId);
        builder.Property(x => x.Currency).IsRequired();
        builder.Property(x => x.TypeofAdvance).IsRequired();
        builder.OwnsOne(x => x.TotalAmount, t => 
        { 
            t.Property(x => x.Value).HasColumnName("TotalAmount").HasColumnType("decimal(18,2)").IsRequired();
        }) ;

        base.Configure(builder);
    }
}
