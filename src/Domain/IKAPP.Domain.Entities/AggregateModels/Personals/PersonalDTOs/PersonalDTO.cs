using IKAPP.Domain.Entities.AggregateModels.Companies;
using IKAPP.Domain.Entities.AggregateModels.Departments;
using IKAPP.Domain.Entities.AggregateModels.Personals.PersonalValueObjects;
using IKAPP.Domain.Entities.AggregateModels.Vocations;
using IKAPP.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Personals.PersonalDTOs;

public sealed record PersonalDTO
{
    public string? Id { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string PhoneNumber { get; init; } 
    public string FirstName { get;  set; } = null!;
    public string? SecondName { get;  set; }
    public string LastName { get;  set; } = null!;
    public string? SecondLastName { get;  set; }
    public string TCIdentityNumber { get; init; } = null!;
    public DateTime StartDateOfWork { get; init; } = default!;
    public DateTime? FinishDateOfWork { get; init; }
    public DateTime BirthDate { get; init; } = default!;
    public decimal Salary { get; init; }
    public string Address { get; init; } = null!;
    public Gender Gender { get; init; } = default!;
    public string PlaceOfBirth { get; init; } = null!;
    public string? PicturePath { get; init; }
    public string VocationId { get; init; } = null!;
    public string CompanyId { get; init; } = null!;
    public string DepartmanId { get; init; } = null!;
    public decimal? UsedAdvance { get; init; }
    public int? NumberofAdvance { get; init; }
    public DateTime? AdvanceRenewalDate { get; init; }
    public Department Department { get; init ; }//departman Entity
    public Vocation Vocation { get; init; } //Meslek Entity
    public Company Company { get; init; }
}
