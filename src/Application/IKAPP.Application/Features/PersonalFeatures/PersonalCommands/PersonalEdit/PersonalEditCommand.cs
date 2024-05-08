using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.PersonalFeatures.PersonalCommands.PersonalEdit;

public class PersonalEditCommand:IRequest<IAuthDataResult<PersonalEditCommand,IdentityResult>>
{
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; } = default!;
    public string PicturePath { get; set; }
    public IFormFile? Picture { get; set; }
}
