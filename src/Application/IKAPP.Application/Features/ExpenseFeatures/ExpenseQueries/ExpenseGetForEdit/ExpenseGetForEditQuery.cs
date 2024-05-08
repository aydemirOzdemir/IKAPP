using IKAPP.Application.Dtos.ExpenseDTOs;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.ExpenseFeatures.ExpenseQueries.ExpenseGetForEdit;

public class ExpenseGetForEditQuery:IRequest<IDataResult<ExpenseUpdateViewDTO>>
{
    public string Id { get; set; }

    public bool IsTracking { get; set; } = true;
}
