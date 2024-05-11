using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.AdvanceRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Dtos.AdvanceDTOs;
using IKAPP.Application.Features.AdvanceFeatures.AdvanceRules;
using IKAPP.Domain.Entities.AggregateModels.Advances;
using IKAPP.Domain.Entities.AggregateModels.Advances.AdvanceDTOs;
using IKAPP.Domain.Entities.AggregateModels.Personals;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace IKAPP.Application.Features.AdvanceFeatures.AdvanceQueries.AdvanceGetAll;

public class AdvanceGetAllQueryHandler : BaseHandler<IAdvanceReadRepository, IAdvanceWriteRepository>, IRequestHandler<AdvanceGetAllQuery, IDataResult<IEnumerable<AdvanceViewDTO>>>
{
    private readonly AdvanceRuleForApplication rules;
    private readonly UserManager<Personal> userManager;

    public AdvanceGetAllQueryHandler(IMapper mapper, IUnitOfWork<IAdvanceReadRepository, IAdvanceWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor, AdvanceRuleForApplication rules, UserManager<Personal> userManager) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.rules = rules;
        this.userManager = userManager;
    }

    public async Task<IDataResult<IEnumerable<AdvanceViewDTO>>> Handle(AdvanceGetAllQuery request, CancellationToken cancellationToken)
    {
        Personal? personal = await userManager.FindByIdAsync(userId);
        if (request.IsApproval)
            return DataResult<IEnumerable<AdvanceViewDTO>>.DataResponse(mapper.Map<IEnumerable<AdvanceViewDTO>>(Advance.CreateAdvanceDTOs(await unitOfWork.ReadRepository.GetAllAsync(f => f.CompanyId == personal.CompanyId, include: query => query.Include(p => p.Personal)))), System.Net.HttpStatusCode.OK, "Avanslar getirildi");

        return DataResult<IEnumerable<AdvanceViewDTO>>.DataResponse(mapper.Map<IEnumerable<AdvanceViewDTO>>(Advance.CreateAdvanceDTOs(await unitOfWork.ReadRepository.GetAllAsync(f => f.PersonalId == personal.Id, tracking: request.Tracking))), System.Net.HttpStatusCode.OK, "Avanslar getirildi");


    }
}
