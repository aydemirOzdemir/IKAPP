using IKAPP.Domain.Entities.AggregateModels.Advances;
using IKAPP.Domain.Entities.AggregateModels.Companies;
using IKAPP.Domain.Entities.AggregateModels.Departments;
using IKAPP.Domain.Entities.AggregateModels.Expenses;
using IKAPP.Domain.Entities.AggregateModels.Permissions;
using IKAPP.Domain.Entities.AggregateModels.Personals.PersonalDTOs;
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
    public  Personal(PersonalDTO personalDTO)
    {
        rules = new();
        Advances = new HashSet<Advance>();
        Expenses = new HashSet<Expense>();
        Permissions = new HashSet<Permission>();
        PersonalNames = new(personalDTO.FirstName,personalDTO.SecondName,personalDTO.LastName,personalDTO.SecondLastName);
        IdentityNumber identityNumber = new(personalDTO.TCIdentityNumber);
        rules.IdentityNumberCanNotBeEmpty(personalDTO.TCIdentityNumber);
        rules.IdentityNumberLengthMustBe11(personalDTO.TCIdentityNumber);
        rules.IdentityNumberMustBeValid(personalDTO.TCIdentityNumber);
        TCIdentityNumber = new(personalDTO.TCIdentityNumber);
        rules.GenderCanNotBeEmpty(personalDTO.Gender);
        Gender= personalDTO.Gender;
        rules.StartDateOfWorkRule(personalDTO.StartDateOfWork);
        StartDateOfWork = personalDTO.StartDateOfWork;
        FinishDateOfWork = personalDTO.FinishDateOfWork;
        rules.BirthDateRules(personalDTO.BirthDate);
        BirthDate = new(personalDTO.BirthDate);
        Salary = personalDTO.Salary;
        rules.AddressCanNotBeEmpty(personalDTO.Address);
        Address= personalDTO.Address;
        rules.PlaceOfBirthCanNotBeEmpty(personalDTO.PlaceOfBirth);
        PlaceOfBirth= personalDTO.PlaceOfBirth;
        PicturePath = personalDTO.PicturePath;
        rules.VocationIdCanNotBeEmpty(personalDTO.VocationId);
        rules.DepartmantIdCanNotBeEmpty(personalDTO.DepartmanId);
        rules.CompanyIdCanNotBeEmpty(personalDTO.CompanyId);
        VocationId= personalDTO.VocationId;
        CompanyId=personalDTO.CompanyId;
        DepartmanId=personalDTO.DepartmanId;
        rules.VocationCanNotBeEmpty(personalDTO.Vocation);
        rules.DepartmantCanNotBeEmpty(personalDTO.Department);
        rules.CompanyCanNotBeEmpty(personalDTO.Company);
        Company = personalDTO.Company;
        Department = personalDTO.Department;
        Vocation = personalDTO.Vocation;
        UserName = personalDTO.Email;
        Email= personalDTO.Email;
        PhoneNumber = personalDTO.PhoneNumber;
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

    public static Personal CreatePersonal(PersonalDTO personalDTO)=> new Personal(personalDTO) { CreatedDate=DateTime.Now};
    public PersonalDTO CreatePersonalDTO()=>new PersonalDTO
    {
        Id=this.Id,
        Email=this.Email,
        PhoneNumber=this.PhoneNumber,
        FirstName=this.PersonalNames.FirstName,
        SecondName=this.PersonalNames.SecondName,
        LastName=this.PersonalNames.LastName,
        SecondLastName=this.PersonalNames.SecondLastName,
        TCIdentityNumber=this.TCIdentityNumber.Value,
        StartDateOfWork=this.StartDateOfWork,
        FinishDateOfWork=this.FinishDateOfWork,
        BirthDate=this.BirthDate.Value,
        Salary=this.Salary,
        Address=this.Address,
        Gender=this.Gender,
        PlaceOfBirth=this.PlaceOfBirth,
        PicturePath=this.PicturePath,
        VocationId=this.VocationId,
        CompanyId=this.CompanyId,
        DepartmanId=this.DepartmanId,
        UsedAdvance=this.UsedAdvance,
        NumberofAdvance=this.NumberofAdvance,
        AdvanceRenewalDate=this.AdvanceRenewalDate,
        Department=this.Department,
        Company=this.Company,
        Vocation=this.Vocation,

    };

}