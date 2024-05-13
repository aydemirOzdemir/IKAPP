using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.CompanyRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Dtos.CompanyDTOs;
using IKAPP.Application.Features.CompanyFeatures.CompanyRules;
using IKAPP.Domain.Entities.AggregateModels.Companies;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IKAPP.Application.Features.CompanyFeatures.CompanyQueries.CompanyGetAll;

public class CompanyGetAllQueryHandler : BaseHandler<ICompanyReadRepository, ICompanyWriteRepository>,IRequestHandler<CompanyGetAllQuery, IDataResult<IEnumerable<CompanyViewDTO>>>
{
    private readonly CompanyRuleForApplication rules;

    public CompanyGetAllQueryHandler(IMapper mapper, IUnitOfWork<ICompanyReadRepository, ICompanyWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor,CompanyRuleForApplication rules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.rules = rules;
    }

    public async Task<IDataResult<IEnumerable<CompanyViewDTO>>> Handle(CompanyGetAllQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Company> companies = await unitOfWork.ReadRepository.GetAllAsync(tracking:request.Tracking); 
   return     DataResult<IEnumerable<CompanyViewDTO>>.DataResponse(mapper.Map<IEnumerable<CompanyViewDTO>>(Company.CreateCompanyDTOs(companies)),System.Net.HttpStatusCode.OK,"Şirketler listelendi");
    }
}
