using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.Common;
using IKAPP.Application.Contract.CompanyRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Features.CompanyFeatures.CompanyRules;
using IKAPP.Domain.Entities.AggregateModels.Companies;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IKAPP.Application.Features.CompanyFeatures.CompanyCommands.CompanyDelete;

public class CompanyDeleteCommandHandler : BaseHandler<ICompanyReadRepository, ICompanyWriteRepository>, IRequestHandler<CompanyDeleteCommand, IResult>
{
    private readonly CompanyRuleForApplication rules;

    public CompanyDeleteCommandHandler(IMapper mapper, IUnitOfWork<ICompanyReadRepository, ICompanyWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor,CompanyRuleForApplication rules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.rules = rules;
    }

    public async Task<IResult> Handle(CompanyDeleteCommand request, CancellationToken cancellationToken)
    {
        Company? company = await unitOfWork.ReadRepository.GetByIdAsync(request.Id);
        await rules.CompanyShouldNotBeNull(company);
         await unitOfWork.WriteRepository.DeleteAsync(company);
        await unitOfWork.SaveAsync();
       return Result.Response(System.Net.HttpStatusCode.OK,"Şirket silindi");

    }
}
