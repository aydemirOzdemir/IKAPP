using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.ExpenseRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Dtos.AdvanceDTOs;
using IKAPP.Application.Dtos.ExpenseDTOs;
using IKAPP.Application.Features.ExpenseFeatures.ExpenseRules;
using IKAPP.Domain.Entities.AggregateModels.Advances;
using IKAPP.Domain.Entities.AggregateModels.Expenses;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace IKAPP.Application.Features.ExpenseFeatures.ExpenseQueries.ExpenseGet;

public class ExpenseGetQueryHandler : BaseHandler<IExpenseReadRepository, IExpenseWriteRepository>,IRequestHandler<ExpenseGetQuery,IDataResult<ExpenseViewDTO>>
{
    private readonly ExpenseRuleForApplication rules;

    public ExpenseGetQueryHandler(IMapper mapper, IUnitOfWork<IExpenseReadRepository, IExpenseWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor,ExpenseRuleForApplication rules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.rules = rules;
    }

    public async Task<IDataResult<ExpenseViewDTO>> Handle(ExpenseGetQuery request, CancellationToken cancellationToken)
    {
        if (request.IsApproval)
        {
            Expense? expenseApproval = await unitOfWork.ReadRepository.GetAsync(x => x.Id == request.Id, include: query => query.Include(p => p.Personal));
            await rules.ExpenseShouldNotBeNull(expenseApproval,"Öğe bulunamadı.");
            return DataResult<ExpenseViewDTO>.DataResponse(mapper.Map<ExpenseViewDTO>(expenseApproval.CreateExpenseDTO()), System.Net.HttpStatusCode.OK, "Harcama Gönderildi");
        }
        Expense? expense = await unitOfWork.ReadRepository.GetByIdAsync(request.Id);
        await rules.ExpenseShouldNotBeNull(expense, "Öğe bulunamadı.");
        return DataResult<ExpenseViewDTO>.DataResponse(mapper.Map<ExpenseViewDTO>(expense.CreateExpenseDTO()), System.Net.HttpStatusCode.OK, "Avans gönderildi.");
    }
}