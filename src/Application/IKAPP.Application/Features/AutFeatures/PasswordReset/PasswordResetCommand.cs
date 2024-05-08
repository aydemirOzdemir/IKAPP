using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.AutFeatures.PasswordReset;

public class PasswordResetCommand:IRequest<IResult>
{
    public string Email { get; set; }
}

