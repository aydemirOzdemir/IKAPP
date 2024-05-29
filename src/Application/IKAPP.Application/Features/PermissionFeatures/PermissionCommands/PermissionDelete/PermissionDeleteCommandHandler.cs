using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.PermissionRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Features.PermissionFeatures.PermissionRules;
using IKAPP.Domain.Entities.AggregateModels.Permissions;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IKAPP.Application.Features.PermissionFeatures.PermissionCommands.PermissionDelete;

public class PermissionDeleteCommandHandler : BaseHandler<IPermissionReadRepository, IPermissionWriteRepository>, IRequestHandler<PermissionDeleteCommand, IResult>
{
    private readonly PermissionRuleForApplication rules;

    public PermissionDeleteCommandHandler(IMapper mapper, IUnitOfWork<IPermissionReadRepository, IPermissionWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor,PermissionRuleForApplication rules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.rules = rules;
    }

    public async Task<IResult> Handle(PermissionDeleteCommand request, CancellationToken cancellationToken)
    {
        Permission? permission=await unitOfWork.ReadRepository.GetByIdAsync(request.Id);
        await rules.PermissionShouldNotBeNull(permission,"Silinecek Öğe bulunamadı");
        await unitOfWork.WriteRepository.DeleteAsync(permission!);
        await unitOfWork.SaveAsync();
        return Result.Response(System.Net.HttpStatusCode.OK,"Silme işlemi başarıyla Tamamlandı.");

    }
}
