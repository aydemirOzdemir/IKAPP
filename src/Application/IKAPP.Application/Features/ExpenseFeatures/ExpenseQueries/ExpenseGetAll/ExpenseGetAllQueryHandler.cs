using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.ExpenseRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Dtos.AdvanceDTOs;
using IKAPP.Application.Dtos.ExpenseDTOs;
using IKAPP.Application.Features.ExpenseFeatures.ExpenseRules;
using IKAPP.Domain.Entities.AggregateModels.Advances;
using IKAPP.Domain.Entities.AggregateModels.Expenses;
using IKAPP.Domain.Entities.AggregateModels.Personals;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IKAPP.Application.Features.ExpenseFeatures.ExpenseQueries.ExpenseGetAll;

public class ExpenseGetAllQueryHandler : BaseHandler<IExpenseReadRepository, IExpenseWriteRepository>,IRequestHandler<ExpenseGetAllQuery, IDataResult<IEnumerable<ExpenseViewDTO>>>
{
    private readonly ExpenseRuleForApplication rules;
    private readonly UserManager<Personal> userManager;

    public ExpenseGetAllQueryHandler(IMapper mapper, IUnitOfWork<IExpenseReadRepository, IExpenseWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor,ExpenseRuleForApplication rules,UserManager<Personal> userManager) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.rules = rules;
        this.userManager = userManager;
    }

    public async Task<IDataResult<IEnumerable<ExpenseViewDTO>>> Handle(ExpenseGetAllQuery request, CancellationToken cancellationToken)
    {
        Personal? personal = await userManager.FindByIdAsync(userId);
        if (request.IsApproval)
            return DataResult<IEnumerable<ExpenseViewDTO>>.DataResponse(mapper.Map<IEnumerable<ExpenseViewDTO>>(Expense.CreateExpenseDTOs(await unitOfWork.ReadRepository.GetAllAsync(f => f.CompanyId == personal.CompanyId, include: query => query.Include(p => p.Personal)))), System.Net.HttpStatusCode.OK, "Harcamalar getirildi");

        return DataResult<IEnumerable<ExpenseViewDTO>>.DataResponse(mapper.Map<IEnumerable<ExpenseViewDTO>>(Expense.CreateExpenseDTOs(await unitOfWork.ReadRepository.GetAllAsync(f => f.PersonalId == personal.Id, tracking: request.Tracking))), System.Net.HttpStatusCode.OK, "Harcamalar getirildi");

    }
}
