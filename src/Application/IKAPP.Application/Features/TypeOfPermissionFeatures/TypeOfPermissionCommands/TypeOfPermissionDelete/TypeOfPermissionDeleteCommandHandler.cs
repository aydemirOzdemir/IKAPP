using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.TypeOfPermissionRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Domain.Entities.AggregateModels.Permissions;
using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IKAPP.Application.Features.TypeOfPermissionFeatures.TypeOfPermissionCommands.TypeOfPermissionDelete;

public class TypeOfPermissionDeleteCommandHandler : BaseHandler<ITypeofPermissionReadRepository, ITypeofPermissionWriteRepository>,IRequestHandler<TypeOfPermissionDeleteCommand,IResult>
{
    public TypeOfPermissionDeleteCommandHandler(IMapper mapper, IUnitOfWork<ITypeofPermissionReadRepository, ITypeofPermissionWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
    }

    public async  Task<IResult> Handle(TypeOfPermissionDeleteCommand request, CancellationToken cancellationToken)
    {
        TypeofPermission? permission = await unitOfWork.ReadRepository.GetByIdAsync(request.Id);
       
        await unitOfWork.WriteRepository.DeleteAsync(permission!);
        await unitOfWork.SaveAsync();
        return Result.Response(System.Net.HttpStatusCode.OK, "Silme işlemi başarıyla Tamamlandı.");
    }
}
