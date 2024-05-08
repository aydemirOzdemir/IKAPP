using IKAPP.Application.Dtos.ExpenseDTOs;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.ExpenseFeatures.ExpenseQueries.ExpenseGet;

public class ExpenseGetQuery : IRequest<IDataResult<ExpenseViewDTO>>
{
    public string Id { get; set; }

    public bool IsApproval { get; set; } = false;
}
