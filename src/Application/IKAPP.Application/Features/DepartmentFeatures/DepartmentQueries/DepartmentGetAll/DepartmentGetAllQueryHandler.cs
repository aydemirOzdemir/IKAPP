using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.DepartmentRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Dtos.DepartmentDTOs;
using IKAPP.Application.Features.DepartmentFeatures.DepartmentRules;
using IKAPP.Domain.Entities.AggregateModels.Departments;
using IKAPP.Domain.Entities.AggregateModels.Departments.DepartmentDTOs;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IKAPP.Application.Features.DepartmentFeatures.DepartmentQueries.DepartmentGetAll;

public class DepartmentGetAllQueryHandler : BaseHandler<IDepartmentReadRepository, IDepartmentWriteRepository>, IRequestHandler<DepartmentGetAllQuery, IDataResult<IEnumerable<DepartmentViewDTO>>>
{
    private readonly DepartmentRuleForApplication rules;

    public DepartmentGetAllQueryHandler(IMapper mapper, IUnitOfWork<IDepartmentReadRepository, IDepartmentWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor, DepartmentRuleForApplication rules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.rules = rules;
    }

    public async Task<IDataResult<IEnumerable<DepartmentViewDTO>>> Handle(DepartmentGetAllQuery request, CancellationToken cancellationToken)
    {

        return DataResult<IEnumerable<DepartmentViewDTO>>.DataResponse(mapper.Map<IEnumerable<DepartmentViewDTO>>(Department.CreateDepartmentDTOs(await unitOfWork.ReadRepository.GetAllAsync(tracking: request.Tracking))), System.Net.HttpStatusCode.OK, "Departmanlar listelendi.");

    }
}
