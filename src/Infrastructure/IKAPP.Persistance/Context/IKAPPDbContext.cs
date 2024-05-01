using IKAPP.Domain.Entities.AggregateModels.Advances;
using IKAPP.Domain.Entities.AggregateModels.Companies;
using IKAPP.Domain.Entities.AggregateModels.Departments;
using IKAPP.Domain.Entities.AggregateModels.Expenses;
using IKAPP.Domain.Entities.AggregateModels.Permissions;
using IKAPP.Domain.Entities.AggregateModels.Personals;
using IKAPP.Domain.Entities.AggregateModels.Roles;
using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions;
using IKAPP.Domain.Entities.AggregateModels.Vocations;
using IKAPP.Persistance.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Persistance.Context;

public class IKAPPDbContext : IdentityDbContext<Personal, Role, string>
{
    public IKAPPDbContext()
    {

    }
    public IKAPPDbContext(DbContextOptions<IKAPPDbContext> options) : base(options) { }
    public DbSet<Personal> Personeller { get; set; }
    public DbSet<Role> Roller { get; set; }
    public DbSet<Department> Departmanlar { get; set; }
    public DbSet<Vocation> Meslekler { get; set; }
    public DbSet<Company> Sirketler { get; set; }
    public DbSet<Permission> Izinler { get; set; }
    public DbSet<Expense> Harcamalar { get; set; }
    public DbSet<Advance> Avanslar { get; set; }
    public DbSet<TypeofPermission> IzınTurleri { get; set; }
    public DbSet<DepartmentCompany> DepartmanSirketler { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IEntityTypeConfiguration<Personal>).Assembly);

        base.OnModelCreating(modelBuilder);
    }


}

