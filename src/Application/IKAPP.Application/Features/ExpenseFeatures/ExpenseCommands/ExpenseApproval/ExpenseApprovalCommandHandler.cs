using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.ExpenseRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Dtos.DepartmentDTOs;
using IKAPP.Application.Dtos.ExpenseDTOs;
using IKAPP.Application.Features.ExpenseFeatures.ExpenseRules;
using IKAPP.Domain.Entities.AggregateModels.Advances;
using IKAPP.Domain.Entities.AggregateModels.Expenses;
using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IKAPP.Application.Features.ExpenseFeatures.ExpenseCommands.ExpenseApproval;

public class ExpenseApprovalCommandHandler : BaseHandler<IExpenseReadRepository, IExpenseWriteRepository>, IRequestHandler<ExpenseApprovalCommand, IDataResult<ExpenseViewDTO>>
{
    private readonly ExpenseRuleForApplication rules;

    public ExpenseApprovalCommandHandler(IMapper mapper, IUnitOfWork<IExpenseReadRepository, IExpenseWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor, ExpenseRuleForApplication rules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.rules = rules;
    }

    public async Task<IDataResult<ExpenseViewDTO>> Handle(ExpenseApprovalCommand request, CancellationToken cancellationToken)
    {
        Expense? expense = await unitOfWork.ReadRepository.GetByIdAsync(request.Id);
        await rules.ExpenseShouldNotBeNull(expense, "Onaylanacak Harcama bulunamadı.");
          expense!.UpdateEntityForBusiines(null, DateTime.Now, request.StatusofApproval);
        expense!.UpdateBaseEntiy(null, null, null, Status.Modified, DateTime.Now);
        Expense? result=await unitOfWork.WriteRepository.UpdateAsync(expense);
        await rules.ExpenseShouldNotBeNull(result, "Onaylama veya iptal edilme işlemi yapılamadı.");
        await unitOfWork.SaveAsync();
        return DataResult<ExpenseViewDTO>.DataResponse(mapper.Map<ExpenseViewDTO>(expense.CreateExpenseDTO()),System.Net.HttpStatusCode.OK,"Harcama onaylama veya reddedilme işlemi başarılı.");

    }
}

