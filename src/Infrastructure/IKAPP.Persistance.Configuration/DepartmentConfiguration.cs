using IKAPP.Domain.Entities.AggregateModels.Departments;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Persistance.Configuration;

public class DepartmentConfiguration : AuditableEntityTypeConfiguration<Department>, IEntityTypeConfiguration<Department>
{
    public override void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasMany(x => x.Sirketler).WithOne(x => x.Department).HasForeignKey(x => x.DepartmanId);
        builder.HasMany(x => x.Personeller).WithOne(x => x.Department).HasForeignKey(x => x.DepartmanId);

   
        builder.HasData(Department.CreateDepartment(new()
        {
            Id = "Ik",
            Name = "Ik"
        }), Department.CreateDepartment(new()
        {
            Id = "Yazılım",
            Name = "Yazılım"
        }));
        base.Configure(builder);

       
    }


 




}
