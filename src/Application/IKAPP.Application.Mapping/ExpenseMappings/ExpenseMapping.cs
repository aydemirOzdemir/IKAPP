using AutoMapper;
using IKAPP.Application.Dtos.ExpenseDTOs;
using IKAPP.Application.Features.ExpenseFeatures.ExpenseCommands.ExpenseApproval;
using IKAPP.Application.Features.ExpenseFeatures.ExpenseCommands.ExpenseCreate;
using IKAPP.Application.Features.ExpenseFeatures.ExpenseCommands.ExpenseEdit;
using IKAPP.Domain.Entities.AggregateModels.Expenses;
using IKAPP.Domain.Entities.AggregateModels.Expenses.ExpenseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IKAPP.Application.Mapping.ExpenseMappings;

public class ExpenseMapping : Profile
{
    public ExpenseMapping()
    {
        CreateMap<ExpenseDTO, ExpenseViewDTO>().ReverseMap();
        CreateMap<ExpenseDTO, ExpenseCreateCommand>().ReverseMap();
        CreateMap<ExpenseDTO, ExpenseEditCommand>().ReverseMap();
        CreateMap<ExpenseUpdateViewDTO, ExpenseEditCommand>().ReverseMap();
        CreateMap<ExpenseViewDTO, ExpenseApprovalCommand>().ReverseMap();
        CreateMap<ExpenseDTO, ExpenseUpdateViewDTO>().ReverseMap();

    }
}