using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.ExpenseRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Features.ExpenseFeatures.ExpenseRules;
using IKAPP.Domain.Entities.AggregateModels.Advances;
using IKAPP.Domain.Entities.AggregateModels.Expenses;
using IKAPP.Domain.Entities.AggregateModels.Expenses.ExpenseDTOs;
using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IKAPP.Application.Features.ExpenseFeatures.ExpenseCommands.ExpenseEdit;

public class ExpenseEditCommandHandler : BaseHandler<IExpenseReadRepository, IExpenseWriteRepository>,IRequestHandler<ExpenseEditCommand, IDataResult<ExpenseEditCommand>>
{
    private readonly ExpenseRuleForApplication rules;

    public ExpenseEditCommandHandler(IMapper mapper, IUnitOfWork<IExpenseReadRepository, IExpenseWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor,ExpenseRuleForApplication rules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.rules = rules;
    }

    public async Task<IDataResult<ExpenseEditCommand>> Handle(ExpenseEditCommand request, CancellationToken cancellationToken)
    {
        Expense? expense=await unitOfWork.ReadRepository.GetByIdAsync(request.Id);
        await rules.ExpenseShouldNotBeNull(expense,"Güncellenecek Harcama Bulunamadı.");
        await rules.CanNotCancelApprovedOrRejectedExpenses(expense);
       
      await  expense!.UpdateExpense( mapper.Map<ExpenseUpdateDTO>(request!));
        expense.UpdateBaseEntiy(new(request.TypeofExpenses.ToString()), null, null, Status.Modified, DateTime.Now);
        Expense result=await unitOfWork.WriteRepository.UpdateAsync(expense);
        await rules.ExpenseShouldNotBeNull(result,"Harcama Güncellenemedi.");
        await unitOfWork.SaveAsync();
        return DataResult<ExpenseEditCommand>.DataResponse(request,System.Net.HttpStatusCode.OK,"Güncelleme başarıyla tamamlandı.");
 
    }
}
