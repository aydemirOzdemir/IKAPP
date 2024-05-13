using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.CompanyRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Dtos.CompanyDTOs;
using IKAPP.Application.Features.CompanyFeatures.CompanyRules;
using IKAPP.Domain.Entities.AggregateModels.Companies;
using IKAPP.Domain.Entities.AggregateModels.Companies.CompanyDTOs;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IKAPP.Application.Features.CompanyFeatures.CompanyQueries.CompanyGet;

public class CompanyGetQueryHandler : BaseHandler<ICompanyReadRepository, ICompanyWriteRepository>, IRequestHandler<CompanyGetQuery, IDataResult<CompanyViewDTO>>
{
    private readonly CompanyRuleForApplication rules;

    public CompanyGetQueryHandler(IMapper mapper, IUnitOfWork<ICompanyReadRepository, ICompanyWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor,CompanyRuleForApplication rules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.rules = rules;
    }

    public async Task<IDataResult<CompanyViewDTO>> Handle(CompanyGetQuery request, CancellationToken cancellationToken)
    {
       Company? company= await unitOfWork.ReadRepository.GetByIdAsync(request.Id);
        await rules.CompanyShouldNotBeNull(company);
        return DataResult<CompanyViewDTO>.DataResponse(mapper.Map<CompanyViewDTO>(company!.CreateCompanyDTO()),System.Net.HttpStatusCode.OK,"Şirket bulundu.");
    }
}
