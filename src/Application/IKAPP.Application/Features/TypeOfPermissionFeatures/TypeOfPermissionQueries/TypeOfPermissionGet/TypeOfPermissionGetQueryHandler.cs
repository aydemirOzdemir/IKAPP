using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.TypeOfPermissionRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Dtos.PermissionDTOs;
using IKAPP.Application.Dtos.TypeOfPermissionDTOs;
using IKAPP.Domain.Entities.AggregateModels.Permissions;
using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IKAPP.Application.Features.TypeOfPermissionFeatures.TypeOfPermissionQueries.TypeOfPermissionGet;

public class TypeOfPermissionGetQueryHandler : BaseHandler<ITypeofPermissionReadRepository, ITypeofPermissionWriteRepository>, IRequestHandler<TypeOfPermissionGetQuery, IDataResult<TypeOfPermissionViewDTO>>
{
    public TypeOfPermissionGetQueryHandler(IMapper mapper, IUnitOfWork<ITypeofPermissionReadRepository, ITypeofPermissionWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
    }

    public async Task<IDataResult<TypeOfPermissionViewDTO>> Handle(TypeOfPermissionGetQuery request, CancellationToken cancellationToken)
    {
        TypeofPermission? permission = await unitOfWork.ReadRepository.GetByIdAsync(request.Id);
      
        return DataResult<TypeOfPermissionViewDTO>.DataResponse(mapper.Map<TypeOfPermissionViewDTO>(permission!.CreateTypeOfPermissionDTO()), System.Net.HttpStatusCode.OK, "İzin Türü gönderildi.");  
    }
}
