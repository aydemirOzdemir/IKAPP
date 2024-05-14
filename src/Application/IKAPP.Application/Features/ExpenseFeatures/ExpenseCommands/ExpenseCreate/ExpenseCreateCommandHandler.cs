using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.ExpenseRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Features.ExpenseFeatures.ExpenseRules;
using IKAPP.Domain.Entities.AggregateModels.Expenses;
using IKAPP.Domain.Entities.AggregateModels.Expenses.ExpenseDTOs;
using IKAPP.Domain.Entities.AggregateModels.Personals;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace IKAPP.Application.Features.ExpenseFeatures.ExpenseCommands.ExpenseCreate;

public class ExpenseCreateCommandHandler : BaseHandler<IExpenseReadRepository, IExpenseWriteRepository>,IRequestHandler<ExpenseCreateCommand,IResult>
{
    private readonly ExpenseRuleForApplication rules;
    private readonly UserManager<Personal> userManager;

    public ExpenseCreateCommandHandler(IMapper mapper, IUnitOfWork<IExpenseReadRepository, IExpenseWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor,ExpenseRuleForApplication rules,UserManager<Personal> userManager) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.rules = rules;
        this.userManager = userManager;
    }

    public async Task<IResult> Handle(ExpenseCreateCommand request, CancellationToken cancellationToken)
    {
        Personal? personal = await userManager.FindByIdAsync(userId);
        ExpenseDTO expenseDTO = mapper.Map<ExpenseDTO>(request);
        expenseDTO.PersonalId = personal.Id;
        expenseDTO.Personal = personal;
        expenseDTO.Company = personal.Company;
        expenseDTO.CompanyId = personal.CompanyId;
        expenseDTO.Name = request.TypeofExpenses.ToString();
        Expense? result = await unitOfWork.WriteRepository.AddAsync(Expense.CreateExpense(expenseDTO));

        await rules.ExpenseShouldNotBeNull(result,"Ekleme işlemi başarısız.");
        await unitOfWork.SaveAsync();
        return Result.Response(System.Net.HttpStatusCode.Created,"Ekleme işlemi başarıyla tamamlandı.");
       
    }
}
