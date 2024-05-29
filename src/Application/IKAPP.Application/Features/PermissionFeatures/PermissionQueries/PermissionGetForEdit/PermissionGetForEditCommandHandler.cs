using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.PermissionRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Dtos.ExpenseDTOs;
using IKAPP.Application.Dtos.PermissionDTOs;
using IKAPP.Domain.Entities.AggregateModels.Permissions.PermissionDTOs;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IKAPP.Application.Features.PermissionFeatures.PermissionQueries.PermissionGetForEdit;

public class PermissionGetForEditCommandHandler : BaseHandler<IPermissionReadRepository, IPermissionWriteRepository>, IRequestHandler<PermissionGetForEditCommand, IDataResult<PermissionUpdateViewDTO>>
{
    public PermissionGetForEditCommandHandler(IMapper mapper, IUnitOfWork<IPermissionReadRepository, IPermissionWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
    }

    public async Task<IDataResult<PermissionUpdateViewDTO>> Handle(PermissionGetForEditCommand request, CancellationToken cancellationToken)=> DataResult<PermissionUpdateViewDTO>.DataResponse(mapper.Map<PermissionUpdateViewDTO>(await unitOfWork.ReadRepository.GetByIdAsync(request.Id, request.IsTracking)), System.Net.HttpStatusCode.OK, "Güncellenecek data getirildi.");

}
