using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.PersonalFeatures.PersonalCommands.PersonalCreate;

public class PersonalCreateCommand:IRequest<IAuthResult<IdentityResult>>
{
    public string? ManagerUserName { get; set; }
    public string FirstName { get; set; } = default!;
    public string? SecondName { get; set; }
    public string LastName { get; set; } = default!;
    public string? SecondLastName { get; set; }

    public string TCIdentityNumber { get; set; } = default!;

    public DateTime BirthDate { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string PlaceOfBirth { get; set; } = default!;

    public string VocationId { get; set; }

    public string DepartmanId { get; set; }
    public string? CompanyId { get; set; }

    public string PhoneNumber { get; set; } = default!;


    public string Password { get; set; } = "Password12*";

    public decimal Salary { get; set; }
    public string PasswordConfirm { get; set; }
    public Gender Gender { get; set; }


    public PersonalCreateCommand()
    {
        this.PasswordConfirm = this.Password;
    }
}
