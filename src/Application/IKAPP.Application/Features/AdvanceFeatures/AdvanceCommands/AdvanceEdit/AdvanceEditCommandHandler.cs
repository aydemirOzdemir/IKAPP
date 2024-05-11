using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.AdvanceRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Features.AdvanceFeatures.AdvanceRules;
using IKAPP.Domain.Entities.AggregateModels.Advances;
using IKAPP.Domain.Entities.AggregateModels.Advances.AdvanceDTOs;
using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IKAPP.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceEdit;

public class AdvanceEditCommandHandler : BaseHandler<IAdvanceReadRepository, IAdvanceWriteRepository>, IRequestHandler<AdvanceEditCommand, IResult>
{
    private readonly AdvanceRuleForApplication rules;

    public AdvanceEditCommandHandler(IMapper mapper, IUnitOfWork<IAdvanceReadRepository, IAdvanceWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor,AdvanceRuleForApplication rules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.rules = rules;
    }

    public async Task<IResult> Handle(AdvanceEditCommand request, CancellationToken cancellationToken)
    {
        Advance? advance= await unitOfWork.ReadRepository.GetByIdAsync(request.Id);
        await rules.AdvanceMustNotBeNull(advance);
        await rules.CanNotCancelApprovedOrRejectedAdvances(advance);
        await advance.UpdateAdvance(mapper.Map<AdvanceUpdateDTO>(request));
        advance.UpdateBaseEntiy(new(request.TypeofAdvance.ToString()),null,null,Status.Modified,DateTime.Now);
        Advance? updatedAdvance = await unitOfWork.WriteRepository.UpdateAsync(advance);
        await rules.AdvanceDoesNotUpdated(advance);
        await unitOfWork.SaveAsync();
        return Result.Response(System.Net.HttpStatusCode.OK,"Avans başarıyla güncellenmiştir.");
    }
}
