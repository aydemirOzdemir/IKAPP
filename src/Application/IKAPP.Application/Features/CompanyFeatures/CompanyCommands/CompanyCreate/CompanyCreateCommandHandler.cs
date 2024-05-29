using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.Common;
using IKAPP.Application.Contract.CompanyRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Features.CompanyFeatures.CompanyRules;
using IKAPP.Domain.Entities.AggregateModels.Companies;
using IKAPP.Domain.Entities.AggregateModels.Companies.CompanyDTOs;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IKAPP.Application.Features.CompanyFeatures.CompanyCommands.CompanyCreate;

public class CompanyCreateCommandHandler : BaseHandler<ICompanyReadRepository, ICompanyWriteRepository>, IRequestHandler<CompanyCreateCommand, IResult>
{
    private readonly CompanyRuleForApplication rules;

    public CompanyCreateCommandHandler(IMapper mapper, IUnitOfWork<ICompanyReadRepository, ICompanyWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor,CompanyRuleForApplication rules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.rules = rules;
    }

    public async Task<IResult> Handle(CompanyCreateCommand request, CancellationToken cancellationToken)
    {
        CompanyDTO companyDTO = mapper.Map<CompanyDTO>(request);
        companyDTO.Id=Guid.NewGuid().ToString();
        Company company = await unitOfWork.WriteRepository.AddAsync(Company.CreateCompany(companyDTO));
        await rules.CompanyShouldNotBeNull(company);
        await unitOfWork.SaveAsync();

        return Result.Response(System.Net.HttpStatusCode.Created,"Şirket eklendi");
    }
}
