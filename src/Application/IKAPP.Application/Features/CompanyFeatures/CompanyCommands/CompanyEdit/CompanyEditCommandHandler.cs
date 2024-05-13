using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.CompanyRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Features.CompanyFeatures.CompanyRules;
using IKAPP.Domain.Entities.AggregateModels.Companies;
using IKAPP.Domain.Entities.AggregateModels.Companies.CompanyDTOs;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IKAPP.Application.Features.CompanyFeatures.CompanyCommands.CompanyEdit;

public class CompanyEditCommandHandler : BaseHandler<ICompanyReadRepository, ICompanyWriteRepository>, IRequestHandler<CompanyEditCommand, IDataResult<CompanyEditCommand>>
{
    private readonly CompanyRuleForApplication rules;

    public CompanyEditCommandHandler(IMapper mapper, IUnitOfWork<ICompanyReadRepository, ICompanyWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor,CompanyRuleForApplication rules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.rules = rules;
    }

    public async Task<IDataResult<CompanyEditCommand>> Handle(CompanyEditCommand request, CancellationToken cancellationToken)
    {
        Company? company = await unitOfWork.ReadRepository.GetByIdAsync(request.Id);
        await rules.CompanyShouldNotBeNull(company);
       await company.UpdateCompany(mapper.Map<CompanyUpdateDTO>(request)); 
        Company? result = await unitOfWork.WriteRepository.UpdateAsync(company);
       await rules.CompanyShouldNotBeNull(result);
        await unitOfWork.SaveAsync();
        return DataResult<CompanyEditCommand>.DataResponse(request,System.Net.HttpStatusCode.OK,"Güncelleme yapıldı.");
    }
}
