using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.SeedWorks.Base.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Companies.CompanyDTOs;

public sealed record CompanyDTO
{
    public string Name { get; set; } = null!;
    public string Id { get; set; } = null!;
    public string? MersisNo { get; set; }
    public string? VergiNo { get; init; }
    public string? VergiDairesi { get; init; }
    public string? LogoPath { get; init; }
    public string? Phone { get; init; }
    public string? Adres { get; init; }
    public string? Mail { get; init; }
    public int? CalisanSayisi { get; init; }
    public DateTime? KurulusTarihi { get; init; }
    public DateTime? SozlesmeBaslangic { get; init; }
    public DateTime? SozlesmeBitis { get; init; }

}
