using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.AdvanceRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Dtos.AdvanceDTOs;
using IKAPP.Application.Features.AdvanceFeatures.AdvanceRules;
using IKAPP.Domain.Entities.AggregateModels.Advances;
using IKAPP.Domain.Entities.AggregateModels.Personals;
using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IKAPP.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceApproval;

public class AdvanceApprovalCommandHandler : BaseHandler<IAdvanceReadRepository, IAdvanceWriteRepository>, IRequestHandler<AdvanceApprovalCommand, IDataResult<AdvanceViewDTO>>
{
    private readonly UserManager<Personal> userManager;
    private readonly AdvanceRuleForApplication rules;

    public AdvanceApprovalCommandHandler(IMapper mapper, IUnitOfWork<IAdvanceReadRepository, IAdvanceWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor ,UserManager<Personal> userManager,AdvanceRuleForApplication rules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.userManager = userManager;
        this.rules = rules;
    }

    public async Task<IDataResult<AdvanceViewDTO>> Handle(AdvanceApprovalCommand request, CancellationToken cancellationToken)
    {
        Advance? advance = await unitOfWork.ReadRepository.GetByIdAsync(request.Id);
        await rules.AdvanceMustNotBeNull(advance);
        Personal? personel = await userManager.FindByNameAsync(request.PersonelName);
        advance.UpdateEntityForBusiines(null,null,request.StatusofApproval);
      
      
        if (advance.TypeofAdvance == TypeofAdvance.IndividualAdvance)
        {
            if (request.StatusofApproval == Approval.Approved)
            {
                Tuple<Personal, Advance> resultofTuple = await unitOfWork.WriteRepository.ControlofAdvance(personel, advance);
                personel = resultofTuple.Item1;
                advance = resultofTuple.Item2;
            }
        }
        advance.UpdateBaseEntiy(null,null,null,Status.Modified,DateTime.Now);
        advance.UpdateEntityForBusiines(null, DateTime.Now, null);
        var result = await userManager.UpdateAsync(personel);
        await userManager.UpdateSecurityStampAsync(personel);
        Advance updatedAdvance = await unitOfWork.WriteRepository.UpdateAsync(advance);
        await rules.AdvanceMustNotBeNull(updatedAdvance);
        await unitOfWork.SaveAsync();
       return DataResult<AdvanceViewDTO>.DataResponse(mapper.Map<AdvanceViewDTO>(updatedAdvance.CreateAdvanceDTO()),System.Net.HttpStatusCode.OK,"Günceleme başarıyla tamamlandı");
      
        
    }
}
