using IKAPP.Domain.Entities.AggregateModels.Advances;
using IKAPP.Domain.Entities.AggregateModels.Companies.CompanyDTOs;
using IKAPP.Domain.Entities.AggregateModels.Departments;
using IKAPP.Domain.Entities.AggregateModels.Expenses;
using IKAPP.Domain.Entities.AggregateModels.Permissions;
using IKAPP.Domain.Entities.AggregateModels.Personals;
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

    public static Company CreateCompany(CompanyDTO companyDTO) => new(companyDTO) { CreatedDate = DateTime.Now };



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





}

