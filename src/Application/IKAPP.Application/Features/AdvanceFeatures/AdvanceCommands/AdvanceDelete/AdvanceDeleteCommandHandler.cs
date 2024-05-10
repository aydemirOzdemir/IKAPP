using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.AdvanceRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Features.AdvanceFeatures.AdvanceRules;
using IKAPP.Domain.Entities.AggregateModels.Advances;
using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IKAPP.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceDelete;

public class AdvanceDeleteCommandHandler : BaseHandler<IAdvanceReadRepository, IAdvanceWriteRepository>, IRequestHandler<AdvanceDeleteCommand, IResult>
{
    private readonly AdvanceRuleForApplication rules;

    public AdvanceDeleteCommandHandler(IMapper mapper, IUnitOfWork<IAdvanceReadRepository, IAdvanceWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor,AdvanceRuleForApplication rules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.rules = rules;
    }

    public async Task<IResult> Handle(AdvanceDeleteCommand request, CancellationToken cancellationToken)
    {
        Advance? advance = await unitOfWork.ReadRepository.GetByIdAsync(request.Id);
        await rules.AdvanceMustNotBeNull(advance);
        await rules.CanNotCancelApprovedOrRejectedAdvances(advance);
        await unitOfWork.WriteRepository.DeleteAsync(advance);
        await unitOfWork.SaveAsync();
        return Result.Response(System.Net.HttpStatusCode.OK,"Avans Silinmiştir.");
    }
}
