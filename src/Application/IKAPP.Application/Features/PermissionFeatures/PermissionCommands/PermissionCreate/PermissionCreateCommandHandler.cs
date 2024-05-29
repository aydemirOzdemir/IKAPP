using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.PermissionRepositories;
using IKAPP.Application.Contract.TypeOfPermissionRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Features.PermissionFeatures.PermissionRules;
using IKAPP.Domain.Entities.AggregateModels.Permissions;
using IKAPP.Domain.Entities.AggregateModels.Permissions.PermissionDTOs;
using IKAPP.Domain.Entities.AggregateModels.Personals;
using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions;
using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace IKAPP.Application.Features.PermissionFeatures.PermissionCommands.PermissionCreate;

public class PermissionCreateCommandHandler : BaseHandler<IPermissionReadRepository, IPermissionWriteRepository>,IRequestHandler<PermissionCreateCommand, IResult>
{
    private readonly PermissionRuleForApplication rules;
    private readonly UserManager<Personal> userManager;
    private readonly ITypeofPermissionReadRepository typeofPermissionReadRepository;

    public PermissionCreateCommandHandler(IMapper mapper, IUnitOfWork<IPermissionReadRepository, IPermissionWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor,PermissionRuleForApplication rules,UserManager<Personal> userManager,ITypeofPermissionReadRepository typeofPermissionReadRepository) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.rules = rules;
        this.userManager = userManager;
        this.typeofPermissionReadRepository = typeofPermissionReadRepository;
    }

    public async Task<IResult> Handle(PermissionCreateCommand request, CancellationToken cancellationToken)
    {
        Personal? personal = await userManager.FindByIdAsync(userId);
        PermissionDTO permissionDTO = mapper.Map<PermissionDTO>(request);
        TypeofPermission? typeofPermission = await typeofPermissionReadRepository.GetByIdAsync(request.TypeofPermissionId);
        permissionDTO.DayCount = typeofPermission.Duration;
        permissionDTO.FinishedDate = permissionDTO.StartedDate.AddDays(permissionDTO.DayCount);
        permissionDTO.Name = typeofPermission.Name.Value;
        permissionDTO.PersonalId = personal.Id;
        permissionDTO.TypeofPermissionId = typeofPermission.Id;
        permissionDTO.Personal = personal;
        permissionDTO.Id=Guid.NewGuid().ToString();
        permissionDTO.TypeofPermission = typeofPermission;
        permissionDTO.Company = personal.Company;
        permissionDTO.CompanyId = personal.CompanyId;
       Permission permission= Permission.CreatePermission(permissionDTO);
        permission.UpdateBaseEntiy(null,DateTime.UtcNow,null,Status.Added,null);
        Permission result=await unitOfWork.WriteRepository.AddAsync(permission);
        await rules.PermissionShouldNotBeNull(result, "Ekleme işlemi başarısız.");
        await unitOfWork.SaveAsync();
        return Result.Response(System.Net.HttpStatusCode.Created,"Ekleme işlemi başarılı");
       throw new NotImplementedException();
    }
}