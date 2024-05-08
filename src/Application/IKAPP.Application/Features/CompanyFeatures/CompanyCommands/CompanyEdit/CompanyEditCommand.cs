﻿using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.CompanyFeatures.CompanyCommands.CompanyEdit;

public class CompanyEditCommand:IRequest<IDataResult<CompanyEditCommand>>
{
    public string Id { get; set; } = default!;
    public string? Name { get; set; }
    public string Unvan { get; set; }
    public string MersisNo { get; set; }
    public string VergiNo { get; set; }
    public string VergiDairesi { get; set; }
    public string Adres { get; set; }
    public IFormFile Picture { get; set; }
    public string? LogoPath { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }
    public int CalısanSayisi { get; set; }
    public DateTime KurulusTarihi { get; set; }
    public DateTime SozlesmeBaslangic { get; set; }
    public DateTime SozlesmeBitis { get; set; }
}
