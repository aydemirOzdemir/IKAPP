using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.AdvanceRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Features.AdvanceFeatures.AdvanceRules;
using IKAPP.Domain.Entities.AggregateModels.Advances;
using IKAPP.Domain.Entities.AggregateModels.Advances.AdvanceDTOs;
using IKAPP.Domain.Entities.AggregateModels.Personals;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace IKAPP.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceCreate;

public class AdvanceCreateCommandHandler : BaseHandler<IAdvanceReadRepository, IAdvanceWriteRepository>, IRequestHandler<AdvanceCreateCommand, IResult>
{
    private readonly UserManager<Personal> userManager;
    private readonly AdvanceRuleForApplication rules;

    public AdvanceCreateCommandHandler(IMapper mapper, IUnitOfWork<IAdvanceReadRepository, IAdvanceWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor,UserManager<Personal> userManager,AdvanceRuleForApplication rules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.userManager = userManager;
        this.rules = rules;
    }

    public async Task<IResult> Handle(AdvanceCreateCommand request, CancellationToken cancellationToken)
    {
        Personal? personel = await userManager.FindByIdAsync(userId);
        AdvanceDTO advance = mapper.Map<AdvanceDTO>(request);
        advance.PersonalId = personel.Id;
        advance.Personal = personel;
        advance.Company = personel.Company;
        advance.CompanyId = personel.CompanyId;
        advance.Name = request.TypeofAdvance.ToString();
        Advance createdAdvance = await unitOfWork.WriteRepository.AddAsync(Advance.CreateAdvance(advance));
        await rules.AdvanceMustNotBeNull(createdAdvance);
        await unitOfWork.SaveAsync();
        return Result.Response(System.Net.HttpStatusCode.Created,"Avans isteği başarıyla oluşturulmuştur.");
    }
}
