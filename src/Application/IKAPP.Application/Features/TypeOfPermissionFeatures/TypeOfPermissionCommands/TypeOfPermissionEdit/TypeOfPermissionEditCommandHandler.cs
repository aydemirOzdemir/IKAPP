using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.TypeOfPermissionRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions;
using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions.TypeofPermissionDTOs;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IKAPP.Application.Features.TypeOfPermissionFeatures.TypeOfPermissionCommands.TypeOfPermissionEdit;

public class TypeOfPermissionEditCommandHandler : BaseHandler<ITypeofPermissionReadRepository, ITypeofPermissionWriteRepository>,IRequestHandler<TypeOfPermissionEditCommand,IResult>
{
    public TypeOfPermissionEditCommandHandler(IMapper mapper, IUnitOfWork<ITypeofPermissionReadRepository, ITypeofPermissionWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
    }

    public async Task<IResult> Handle(TypeOfPermissionEditCommand request, CancellationToken cancellationToken)
    {
        TypeofPermission? typeofPermission=await unitOfWork.ReadRepository.GetByIdAsync(request.Id);
        TypeOfPermissionUpdateDTO updateDTO=mapper.Map<TypeOfPermissionUpdateDTO>(request);
        await typeofPermission.UpdateTypeOfPermission(updateDTO);
        var result = await unitOfWork.WriteRepository.UpdateAsync(typeofPermission);
        await unitOfWork.SaveAsync();
        return Result.Response(System.Net.HttpStatusCode.OK,"Güncelleme yapıldı.");
    }
}
