using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.AutFeatures.UpdatePassword;

public class UpdatePasswordCommand:IRequest<IResult>
{
    public string? UserId { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
}
