using IKAPP.Domain.Entities.AggregateModels.Advances;
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

public  class Company:AuditableEntity,IAggregateRoot
{
    public Company(string id, Name name,string? mersisNo,string? vergiNo,string? vergiDairesi,string? logoPath,string? phone,string? adres,string? mail,int? calisanSayisi,DateTime? kurulusTarihi,DateTime? sozlesmeBaslangic, DateTime? sozlesmeBitis) : base(id, name)
    {
        Personeller = new HashSet<Personal>();
        Departmanlar = new HashSet<DepartmentCompany>();
        Avanslar = new HashSet<Advance>();
        Harcamalar = new HashSet<Expense>();
        Izinler = new HashSet<Permission>();
        Unvan = name;
        MersisNo = mersisNo;
        VergiNo = vergiNo;
        VergiDairesi = vergiDairesi;
        LogoPath = logoPath;
        Phone = phone;
        Adres = adres;
        Mail = mail;
        CalisanSayisi = calisanSayisi;
        KurulusTarihi= kurulusTarihi;
        SozlesmeBaslangic= sozlesmeBaslangic;
        SozlesmeBitis= sozlesmeBitis;
    }
    public Name Unvan { get;private set; }
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
    public ICollection<Personal>? Personeller { get;private set; }
    public ICollection<DepartmentCompany>? Departmanlar { get; private set; }
    public ICollection<Advance>? Avanslar { get; private set; }
    public ICollection<Expense>? Harcamalar { get; private set; }
    public ICollection<Permission>? Izinler { get; private set; }
}
