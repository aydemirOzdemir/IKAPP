using IKAPP.Application.Dtos.CompanyDTOs;
using IKAPP.Application.Dtos.DepartmentDTOs;
using IKAPP.Application.Dtos.VocationDTOs;
using IKAPP.Domain.Entities.AggregateModels.Companies;
using IKAPP.Domain.Entities.AggregateModels.Departments;
using IKAPP.Domain.Entities.AggregateModels.Vocations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Dtos.PersonalDTOs;

public class PersonalDetailViewDTO
{
    public string FirstName { get; set; } = default!;
    public string? SecondName { get; set; }
    public string LastName { get; set; } = default!;
    public string? SecondLastName { get; set; }
    public string TCIdentityNumber { get; set; } = default!;
    public DateTime StartDateOfWork { get; set; } = DateTime.Now;
    public DateTime BirthDate { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string PlaceOfBirth { get; set; } = default!;
    public string? PicturePath { get; set; }
    public string? DepartmanId { get; set; }
    public string? VocationId { get; set; }
    public string? CompanyId { get; set; }


    public  DepartmentViewDTO Department { get; set; }//departman Entity
    public  VocationViewDTO Vocation { get; set; } //Meslek Entity
    public  CompanyViewDTO Company { get; set; } //Şirket Entity
}
