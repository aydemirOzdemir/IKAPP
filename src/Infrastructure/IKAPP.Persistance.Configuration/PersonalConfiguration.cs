using IKAPP.Domain.Entities.AggregateModels.Personals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Persistance.Configuration;

public class PersonalConfiguration : IEntityTypeConfiguration<Personal>
{
    public void Configure(EntityTypeBuilder<Personal> builder)
    {
        builder.HasQueryFilter(e => e.IsActive == true);
        builder.HasKey(x => x.Id);
        builder.OwnsOne(x => x.PersonalNames, t =>
        {
            t.Property(x => x.FirstName).HasColumnType("nvarchar(50)").IsRequired();
            t.Property(p => p.LastName).IsRequired().HasColumnType("nvarchar(50)");
        });
        builder.OwnsOne(p => p.TCIdentityNumber, i =>
        {
            i.Property(v=>v.Value).HasColumnName("IdentityNumber").IsRequired().HasColumnType("nchar(11)");
        });
        builder.OwnsOne(p => p.BirthDate, i =>
        {
            i.Property(v => v.Value).HasColumnName("BirthDate").IsRequired().HasColumnType("datetime");
        });
        builder.Property(p => p.Address).IsRequired().HasColumnType("nvarchar(max)");
        builder.Property(p => p.PlaceOfBirth).IsRequired().HasColumnType("nvarchar(50)");
    }
}
