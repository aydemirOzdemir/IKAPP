using IKAPP.Domain.Entities.Interfaces;
using IKAPP.Domain.Entities.SeedWorks.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IKAPP.Persistance.Configuration;

public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(p => p.Name).HasConversion(name => name.Value, value => new(value));

        builder.Property(x => x.Status).IsRequired();
     
        builder.Property(x => x.CreatedDate).IsRequired();


        builder.Property(x => x.ModifiedDate).IsRequired();
    }
}
