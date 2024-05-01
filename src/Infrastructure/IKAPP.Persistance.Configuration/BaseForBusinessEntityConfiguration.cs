using IKAPP.Domain.Entities.SeedWorks.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Persistance.Configuration;

public class BaseForBusinessEntityConfiguration<TEntity>:AuditableEntityTypeConfiguration<TEntity> where TEntity : BaseEntityForBusiness
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);
    }
}
