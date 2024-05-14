using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.ExpenseRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Dtos.ExpenseDTOs;
using IKAPP.Application.Features.ExpenseFeatures.ExpenseRules;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IKAPP.Application.Features.ExpenseFeatures.ExpenseQueries.ExpenseGetForEdit;

public class ExpenseGetForEditQueryHandler : BaseHandler<IExpenseReadRepository, IExpenseWriteRepository>,IRequestHandler<ExpenseGetForEditQuery, IDataResult<ExpenseUpdateViewDTO>>
{
    private readonly ExpenseRuleForApplication rules;

    public ExpenseGetForEditQueryHandler(IMapper mapper, IUnitOfWork<IExpenseReadRepository, IExpenseWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor,ExpenseRuleForApplication rules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.rules = rules;
    }

    public async Task<IDataResult<ExpenseUpdateViewDTO>> Handle(ExpenseGetForEditQuery request, CancellationToken cancellationToken) => DataResult<ExpenseUpdateViewDTO>.DataResponse(mapper.Map<ExpenseUpdateViewDTO>(await unitOfWork.ReadRepository.GetByIdAsync(request.Id, request.IsTracking)), System.Net.HttpStatusCode.OK, "Güncellenecek data getirildi.");

}
