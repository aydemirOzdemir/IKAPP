using IKAPP.Domain.Entities.AggregateModels.Expenses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Persistance.Configuration;

public class ExpenseConfiguration : BaseForBusinessEntityConfiguration<Expense>
{
    public override void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.HasOne(x => x.Personal).WithMany(x => x.Expenses).HasForeignKey(x => x.PersonalId);
        builder.HasOne(x => x.Company).WithMany(x => x.Harcamalar).HasForeignKey(x => x.CompanyId);
        builder.Property(x => x.Currency).IsRequired();
        builder.Property(x => x.TypeofExpense).IsRequired();
        builder.OwnsOne(x => x.TotalAmount, t =>
        {
            t.Property(x => x.Value).HasColumnName("TotalAmount").HasColumnType("decimal(18,2)").IsRequired();
        });
        base.Configure(builder);
    }
}
