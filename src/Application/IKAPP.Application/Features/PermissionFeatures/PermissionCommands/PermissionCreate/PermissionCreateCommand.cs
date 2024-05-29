using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.PermissionFeatures.PermissionCommands.PermissionCreate;

public class PermissionCreateCommand:IRequest<IResult>
{
    public DateTime? DateofReply { get; set; }
    public DateTime StartedDate { get; set; }
    public DateTime FinishedDate { get; set; }

    public string TypeofPermissionId { get; set; }


   



}
