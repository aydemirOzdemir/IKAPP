using IKAPP.Application.Dtos.ExpenseDTOs;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.ExpenseFeatures.ExpenseQueries.ExpenseGetAll;

public class ExpenseGetAllQuery:IRequest<IDataResult<IEnumerable<ExpenseViewDTO>>>
{
    public bool Tracking { get; set; } = true;
    public bool IsApproval { get; set; } = false;
   
}
