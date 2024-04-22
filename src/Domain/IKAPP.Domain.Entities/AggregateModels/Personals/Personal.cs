using IKAPP.Domain.Entities.AggregateModels.Advances;
using IKAPP.Domain.Entities.AggregateModels.Companies;
using IKAPP.Domain.Entities.AggregateModels.Departments;
using IKAPP.Domain.Entities.AggregateModels.Expenses;
using IKAPP.Domain.Entities.AggregateModels.Permissions;
using IKAPP.Domain.Entities.AggregateModels.Personals.PersonalRules;
using IKAPP.Domain.Entities.AggregateModels.Personals.PersonalValueObjects;
using IKAPP.Domain.Entities.AggregateModels.Vocations;
using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.Entities.SeedWorks;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Personals;

public  class Personal:IdentityUser,IAggregateRoot
{
    private readonly PersonalRule rules;
    public  Personal(PersonalNames names,IdentityNumber identityNumber,DateTime startDateOfWork, DateTime? finishedDateOfWork,BirthDate birthDate, decimal? salary,string address,Gender gender,string placeofBirth,string? picturePath,string vocationId,string companyId,string departmantId,Department department,Vocation vocation,Company company)
    {
        rules = new();
        Advances = new HashSet<Advance>();
        Expenses = new HashSet<Expense>();
        Permissions = new HashSet<Permission>();
        PersonalNames = names;
        TCIdentityNumber = identityNumber;
        rules.GenderCanNotBeEmpty(gender);
        Gender= gender;
        rules.StartDateOfWorkRule(startDateOfWork);
        StartDateOfWork = startDateOfWork;
        FinishDateOfWork = finishedDateOfWork;
        BirthDate = birthDate;
        Salary = salary;
        rules.AddressCanNotBeEmpty(address);
        Address= address;
        rules.PlaceOfBirthCanNotBeEmpty(placeofBirth);
        PlaceOfBirth= placeofBirth;
        PicturePath = picturePath;
        rules.VocationIdCanNotBeEmpty(vocationId);
        rules.DepartmantIdCanNotBeEmpty(departmantId);
        rules.CompanyIdCanNotBeEmpty(companyId);
        VocationId= vocationId;
        CompanyId=companyId;
        DepartmanId=departmantId;
        rules.VocationCanNotBeEmpty(vocation);
        rules.DepartmantCanNotBeEmpty(department);
        rules.CompanyCanNotBeEmpty(company);
        Company = company;
        Department = department;
        Vocation = vocation;
    }
    public PersonalNames PersonalNames { get; private set; }
    public IdentityNumber TCIdentityNumber { get; private set; } 
    public DateTime StartDateOfWork { get; private set; } 
    public DateTime? FinishDateOfWork { get; private set; }
    public BirthDate BirthDate { get; private set; } 
    public decimal? Salary { get; private set; }
    public string Address { get; private set; } 
    public Gender Gender { get; private set; }
    public string PlaceOfBirth { get; private set; }
    public string? PicturePath { get; private set; }
    public string VocationId { get; private set; } 
    public string CompanyId { get; private set; } 
    public string DepartmanId { get; private set; } 
    public decimal? UsedAdvance { get; private set; }
    public int? NumberofAdvance { get; private set; }
    public DateTime? AdvanceRenewalDate { get; private set; }
    public string CreatedBy { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public string ModifiedBy { get; private set; }
    public DateTime ModifiedDate { get; private set; }
    public string? DeletedBy { get; private set; }
    public DateTime? DeletedDate { get; private set; }





    //Navigation properties

    public  Department Department { get; private set; }//departman Entity
    public  Vocation Vocation { get; private set; } //Meslek Entity
    public  Company Company { get; private set; } //Şirket Entity
    public  ICollection<Advance> Advances { get; private set; } //Şirket Entity
    public  ICollection<Expense> Expenses { get; private set; } //Şirket Entity
    public  ICollection<Permission> Permissions { get; private set; } //Şirket Entity
}
