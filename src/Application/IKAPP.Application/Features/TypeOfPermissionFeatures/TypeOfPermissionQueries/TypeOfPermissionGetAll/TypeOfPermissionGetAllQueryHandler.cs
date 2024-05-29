using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.TypeOfPermissionRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Dtos.DepartmentDTOs;
using IKAPP.Application.Dtos.TypeOfPermissionDTOs;
using IKAPP.Domain.Entities.AggregateModels.Departments;
using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IKAPP.Application.Features.TypeOfPermissionFeatures.TypeOfPermissionQueries.TypeOfPermissionGetAll;

public class TypeOfPermissionGetAllQueryHandler : BaseHandler<ITypeofPermissionReadRepository, ITypeofPermissionWriteRepository>,IRequestHandler<TypeOfPermissionGetAllQuery, IDataResult<IEnumerable<TypeOfPermissionViewDTO>>>
{
    public TypeOfPermissionGetAllQueryHandler(IMapper mapper, IUnitOfWork<ITypeofPermissionReadRepository, ITypeofPermissionWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
    }

    public async Task<IDataResult<IEnumerable<TypeOfPermissionViewDTO>>> Handle(TypeOfPermissionGetAllQuery request, CancellationToken cancellationToken)
    {
        return DataResult<IEnumerable<TypeOfPermissionViewDTO>>.DataResponse(mapper.Map<IEnumerable<TypeOfPermissionViewDTO>>(TypeofPermission.CreateTypeOfPermissionDTOs(await unitOfWork.ReadRepository.GetAllAsync(tracking: request.Tracking))), System.Net.HttpStatusCode.OK, "Avans Tipleri listelendi.");
    }
}
