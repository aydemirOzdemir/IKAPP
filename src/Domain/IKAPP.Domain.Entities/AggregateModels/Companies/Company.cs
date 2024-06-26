﻿using IKAPP.Domain.Entities.AggregateModels.Advances;
using IKAPP.Domain.Entities.AggregateModels.Advances.AdvanceDTOs;
using IKAPP.Domain.Entities.AggregateModels.Companies.CompanyDTOs;
using IKAPP.Domain.Entities.AggregateModels.Departments;
using IKAPP.Domain.Entities.AggregateModels.Expenses;
using IKAPP.Domain.Entities.AggregateModels.Permissions;
using IKAPP.Domain.Entities.AggregateModels.Personals;
using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.Entities.SeedWorks;
using IKAPP.Domain.Entities.SeedWorks.Base;
using IKAPP.Domain.SeedWorks.Base.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Companies;

public class Company : AuditableEntity, IAggregateRoot
{
    private Company(CompanyDTO companyDTO) : base(companyDTO.Id, new(companyDTO.Name))
    {
        Personeller = new HashSet<Personal>();
        Departmanlar = new HashSet<DepartmentCompany>();
        Avanslar = new HashSet<Advance>();
        Harcamalar = new HashSet<Expense>();
        Izinler = new HashSet<Permission>();
        MersisNo = companyDTO.MersisNo;
        VergiNo = companyDTO.VergiNo;
        VergiDairesi = companyDTO.VergiDairesi;
        LogoPath = companyDTO.LogoPath;
        Phone = companyDTO.Phone;
        Adres = companyDTO.Adres;
        Mail = companyDTO.Mail;
        CalisanSayisi = companyDTO.CalisanSayisi;
        KurulusTarihi = companyDTO.KurulusTarihi;
        SozlesmeBaslangic = companyDTO.SozlesmeBaslangic;
        SozlesmeBitis = companyDTO.SozlesmeBitis;
    }

    public string? MersisNo { get; private set; }
    public string? VergiNo { get; private set; }
    public string? VergiDairesi { get; private set; }
    public string? LogoPath { get; private set; }
    public string? Phone { get; private set; }
    public string? Adres { get; private set; }
    public string? Mail { get; private set; }
    public int? CalisanSayisi { get; private set; }
    public DateTime? KurulusTarihi { get; private set; }
    public DateTime? SozlesmeBaslangic { get; private set; }
    public DateTime? SozlesmeBitis { get; private set; }
    //navigation properties
    public ICollection<Personal>? Personeller { get; private set; }
    public ICollection<DepartmentCompany>? Departmanlar { get; private set; }
    public ICollection<Advance>? Avanslar { get; private set; }
    public ICollection<Expense>? Harcamalar { get; private set; }
    public ICollection<Permission>? Izinler { get; private set; }

    public static Company CreateCompany(CompanyDTO companyDTO) 
    {
        Company company = new(companyDTO);
        company.UpdateBaseEntiy(null,DateTime.Now,null,Enums.Status.Added,null);
        return company;
    }

    public CompanyDTO CreateCompanyDTO() => new()
    {
        Id = this.Id,
        Name = this.Name.Value,
        MersisNo = this.MersisNo,
        VergiDairesi = this.VergiDairesi,
        VergiNo = this.VergiNo,
        LogoPath = this.LogoPath,
        Phone = this.Phone,
        Adres = this.Adres,
        Mail = this.Mail,
        CalisanSayisi = this.CalisanSayisi,
        KurulusTarihi = this.KurulusTarihi,
        SozlesmeBaslangic = this.SozlesmeBaslangic,
        SozlesmeBitis = this.SozlesmeBitis,
    };
    public static IEnumerable<CompanyDTO> CreateCompanyDTOs(IEnumerable<Company> companies)
    {
        List<CompanyDTO> companyDTOs = new List<CompanyDTO>();
        foreach (Company company in companies)
            companyDTOs.Add(new CompanyDTO()
            {
                Id = company.Id,
                Name = company.Name.Value,
                MersisNo = company.MersisNo,
                VergiDairesi = company.VergiDairesi,
                VergiNo = company.VergiNo,
                LogoPath = company.LogoPath,
                Phone = company.Phone,
                Adres = company.Adres,
                Mail = company.Mail,
                CalisanSayisi = company.CalisanSayisi,
                KurulusTarihi = company.KurulusTarihi,
                SozlesmeBaslangic = company.SozlesmeBaslangic,
                SozlesmeBitis = company.SozlesmeBitis,
            });
        return companyDTOs;
    }
    public Task UpdateCompany(CompanyUpdateDTO companyUpdateDTO)
    {
        MersisNo = companyUpdateDTO.MersisNo;
        VergiDairesi = companyUpdateDTO.VergiDairesi;
        Adres = companyUpdateDTO.Adres;
        LogoPath = companyUpdateDTO.LogoPath;
        Phone = companyUpdateDTO.Phone;
        Mail = companyUpdateDTO.Mail;
        CalisanSayisi = companyUpdateDTO.CalısanSayisi;
        KurulusTarihi = companyUpdateDTO.KurulusTarihi;
        SozlesmeBaslangic = companyUpdateDTO.SozlesmeBaslangic;
        SozlesmeBitis = companyUpdateDTO.SozlesmeBitis;
        UpdateBaseEntiy(new(companyUpdateDTO.Name),null, companyUpdateDTO.Id,Enums.Status.Modified,DateTime.Now);
        return Task.CompletedTask;
    }
    public Task SoftDeleteCompany()
    {
      
        UpdateBaseEntiy(null, null, null, Enums.Status.Deleted, null);
        UpdateDeleteDate(DateTime.Now);
        return Task.CompletedTask;
    }
    public Task AddPersonals(List<Personal> personals)
    {
        foreach (Personal personal in personals)
        {
            Personeller.Add(personal);
        }

        return Task.CompletedTask;
    }
    public Task AddDepartments(List<DepartmentCompany> departments)
    {
        foreach (DepartmentCompany department in departments)
        {
            Departmanlar.Add(department);
        }

        return Task.CompletedTask;
    }
    public Task AddAdvances(List<Advance> advances)
    {
        foreach (Advance advance in advances)
        {
            Avanslar.Add(advance);
        }

        return Task.CompletedTask;
    }
    public Task AddExpenses(List<Expense> expenses)
    {
        foreach (Expense expense in expenses)
        {
            Harcamalar.Add(expense);
        }

        return Task.CompletedTask;
    }
    public Task AddPermissions(List<Permission> permissions)
    {
        foreach (Permission permission in permissions)
        {
            Izinler.Add(permission);
        }

        return Task.CompletedTask;
    }

}

