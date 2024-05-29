using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.PermissionRepositories;
using IKAPP.Application.Contract.TypeOfPermissionRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Features.PermissionFeatures.PermissionRules;
using IKAPP.Domain.Entities.AggregateModels.Permissions;
using IKAPP.Domain.Entities.AggregateModels.Permissions.PermissionDTOs;
using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions;
using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IKAPP.Application.Features.PermissionFeatures.PermissionCommands.PermissionEdit;

public class PermissionEditCommandHandler : BaseHandler<IPermissionReadRepository, IPermissionWriteRepository>, IRequestHandler<PermissionEditCommand, IResult>
{
    private readonly ITypeofPermissionReadRepository typeofPermissionReadRepository;
    private readonly PermissionRuleForApplication rules;

    public PermissionEditCommandHandler(IMapper mapper, IUnitOfWork<IPermissionReadRepository, IPermissionWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor,ITypeofPermissionReadRepository typeofPermissionReadRepository,PermissionRuleForApplication rules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.typeofPermissionReadRepository = typeofPermissionReadRepository;
        this.rules = rules;
    }

    public async Task<IResult> Handle(PermissionEditCommand request, CancellationToken cancellationToken)
    {
        Permission? permission= await unitOfWork.ReadRepository.GetByIdAsync(request.Id);
        await rules.PermissionShouldNotBeNull(permission,"Seçilen izin bulunamamıştır.");
        TypeofPermission? typeofPermission = await typeofPermissionReadRepository.GetByIdAsync(request.TypeofPermissionId);
        await rules.CanNotCancelApprovedOrRejectedPermissions(permission);
        PermissionUpdateDTO permissionUpdateDTO=mapper.Map<PermissionUpdateDTO>(request);
        permissionUpdateDTO.DayCount = typeofPermission!.Duration;
       await permission!.UpdatePermission(permissionUpdateDTO);
        permission.UpdateBaseEntiy(new(typeofPermission.Name.Value),null,null,Status.Modified,DateTime.Now);
        Permission? result = await unitOfWork.WriteRepository.UpdateAsync(permission);
        await rules.PermissionShouldNotBeNull(result,"Güncellem başarısız.");
        await unitOfWork.SaveAsync();
        return Result.Response(System.Net.HttpStatusCode.OK,"Güncelleme Başarıyla Tamamlandı.");
    }
}