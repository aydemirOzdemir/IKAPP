using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.ExpenseRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Features.ExpenseFeatures.ExpenseRules;
using IKAPP.Domain.Entities.AggregateModels.Expenses;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IKAPP.Application.Features.ExpenseFeatures.ExpenseCommands.ExpenseDelete;

public class ExpenseDeleteCommandHandler : BaseHandler<IExpenseReadRepository, IExpenseWriteRepository>,IRequestHandler<ExpenseDeleteCommand,IResult>
{
    private readonly ExpenseRuleForApplication rules;

    public ExpenseDeleteCommandHandler(IMapper mapper, IUnitOfWork<IExpenseReadRepository, IExpenseWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor,ExpenseRuleForApplication rules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.rules = rules;
    }

    public async Task<IResult> Handle(ExpenseDeleteCommand request, CancellationToken cancellationToken)
    {
        Expense? expense=await unitOfWork.ReadRepository.GetByIdAsync(request.Id);
        await rules.ExpenseShouldNotBeNull(expense,"Silinecek öğe bulunamadı.");
        await rules.CanNotCancelApprovedOrRejectedExpenses(expense);
         await unitOfWork.WriteRepository.DeleteAsync(expense!);
        await unitOfWork.SaveAsync();
        return Result.Response(System.Net.HttpStatusCode.OK,"Öğe silindi.");
       
    }
}

