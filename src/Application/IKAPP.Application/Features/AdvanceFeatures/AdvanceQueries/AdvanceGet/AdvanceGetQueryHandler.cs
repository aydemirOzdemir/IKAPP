using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.AdvanceRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Dtos.AdvanceDTOs;
using IKAPP.Application.Features.AdvanceFeatures.AdvanceRules;
using IKAPP.Domain.Entities.AggregateModels.Advances;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace IKAPP.Application.Features.AdvanceFeatures.AdvanceQueries.AdvanceGet;

public class AdvanceGetQueryHandler : BaseHandler<IAdvanceReadRepository,IAdvanceWriteRepository>, IRequestHandler<AdvanceGetQuery, IDataResult<AdvanceViewDTO>>
{
    private readonly AdvanceRuleForApplication rules;

    public AdvanceGetQueryHandler(IMapper mapper, IUnitOfWork<IAdvanceReadRepository, IAdvanceWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor,AdvanceRuleForApplication rules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.rules = rules;
    }

    public async Task<IDataResult<AdvanceViewDTO>> Handle(AdvanceGetQuery request, CancellationToken cancellationToken)
    {

        if (request.IsApproval)
        {
            Advance? advanceApproval = await unitOfWork.ReadRepository.GetAsync(x => x.Id == request.Id, include: query => query.Include(p => p.Personal));
            await rules.AdvanceMustNotBeNull(advanceApproval);
            return DataResult<AdvanceViewDTO>.DataResponse(mapper.Map<AdvanceViewDTO>(advanceApproval.CreateAdvanceDTO()), System.Net.HttpStatusCode.OK, "Avans Gönderildi");
        }
        Advance? advance = await unitOfWork.ReadRepository.GetByIdAsync(request.Id);
        await rules.AdvanceMustNotBeNull(advance);
        return DataResult<AdvanceViewDTO>.DataResponse(mapper.Map<AdvanceViewDTO>(advance.CreateAdvanceDTO()),System.Net.HttpStatusCode.OK,"Avans gönderildi.");

    }
}

