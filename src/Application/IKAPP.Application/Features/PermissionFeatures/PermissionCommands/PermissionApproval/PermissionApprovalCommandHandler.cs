using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.PermissionRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Dtos.ExpenseDTOs;
using IKAPP.Application.Dtos.PermissionDTOs;
using IKAPP.Application.Features.PermissionFeatures.PermissionRules;
using IKAPP.Domain.Entities.AggregateModels.Expenses;
using IKAPP.Domain.Entities.AggregateModels.Permissions;
using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IKAPP.Application.Features.PermissionFeatures.PermissionCommands.PermissionApproval;

public class PermissionApprovalCommandHandler : BaseHandler<IPermissionReadRepository, IPermissionWriteRepository>,IRequestHandler<PermissionApprovalCommand, IDataResult<PermissionViewDTO>>
{
    private readonly PermissionRuleForApplication rules;

    public PermissionApprovalCommandHandler(IMapper mapper, IUnitOfWork<IPermissionReadRepository, IPermissionWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor,PermissionRuleForApplication rules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.rules = rules;
    }

    public async Task<IDataResult<PermissionViewDTO>> Handle(PermissionApprovalCommand request, CancellationToken cancellationToken)
    {
        Permission? permission = await unitOfWork.ReadRepository.GetByIdAsync(request.Id);
        await rules.PermissionShouldNotBeNull(permission, "Onaylanacak Harcama bulunamadı.");
        permission!.UpdateEntityForBusiines(null, DateTime.Now, request.StatusofApproval);
        permission!.UpdateBaseEntiy(null, null, null, Status.Modified, DateTime.Now);
        Permission? result = await unitOfWork.WriteRepository.UpdateAsync(permission);
        await rules.PermissionShouldNotBeNull(result, "Onaylama veya iptal edilme işlemi yapılamadı.");
        await unitOfWork.SaveAsync();
        return DataResult<PermissionViewDTO>.DataResponse(mapper.Map<PermissionViewDTO>(permission.CreatePermissionDTO()), System.Net.HttpStatusCode.OK, "Harcama onaylama veya reddedilme işlemi başarılı.");
    }
}
