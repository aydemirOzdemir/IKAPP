using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.DepartmentRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Dtos.DepartmentDTOs;
using IKAPP.Application.Features.DepartmentFeatures.DepartmentRules;
using IKAPP.Domain.Entities.AggregateModels.Departments;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IKAPP.Application.Features.DepartmentFeatures.DepartmentQueries.DepartmentGet;

public class DepartmentGetQueryHandler : BaseHandler<IDepartmentReadRepository, IDepartmentWriteRepository>, IRequestHandler<DepartmentGetQuery, IDataResult<DepartmentViewDTO>>
{
    private readonly DepartmentRuleForApplication rules;

    public DepartmentGetQueryHandler(IMapper mapper, IUnitOfWork<IDepartmentReadRepository, IDepartmentWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor,DepartmentRuleForApplication rules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.rules = rules;
    }

    public async Task<IDataResult<DepartmentViewDTO>> Handle(DepartmentGetQuery request, CancellationToken cancellationToken)
    {
        Department? department = await unitOfWork.ReadRepository.GetByIdAsync(request.Id);
        await rules.DepartmentShouldNotBeNull(department,"Departman bulunamadı.");
        return DataResult<DepartmentViewDTO>.DataResponse(mapper.Map<DepartmentViewDTO>(department!.CreateDepartmentDTO()),System.Net.HttpStatusCode.OK,"Departman getirildi.");
    }
}
    