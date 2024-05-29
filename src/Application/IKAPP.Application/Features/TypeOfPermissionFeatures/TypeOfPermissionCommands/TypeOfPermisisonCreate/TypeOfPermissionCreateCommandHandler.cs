using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.TypeOfPermissionRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Features.TypeOfPermissionFeatures.TypeOfPermissionRules;
using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions;
using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions.TypeofPermissionDTOs;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IKAPP.Application.Features.TypeOfPermissionFeatures.TypeOfPermissionCommands.TypeOfPermisisonCreate;

public class TypeOfPermissionCreateCommandHandler : BaseHandler<ITypeofPermissionReadRepository, ITypeofPermissionWriteRepository>, IRequestHandler<TypeOfPermissionCreateCommand, IResult>
{
    private readonly TypeOfPermissionRuleForApplication rules;

    public TypeOfPermissionCreateCommandHandler(IMapper mapper, IUnitOfWork<ITypeofPermissionReadRepository, ITypeofPermissionWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor,TypeOfPermissionRuleForApplication rules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.rules = rules;
    }

    public async Task<IResult> Handle(TypeOfPermissionCreateCommand request, CancellationToken cancellationToken)
    {
        TypeOfPermissionDTO typeOfPermissionDTO = mapper.Map<TypeOfPermissionDTO>(request);
        typeOfPermissionDTO.Id = Guid.NewGuid().ToString();
        TypeofPermission? result = await unitOfWork.WriteRepository.AddAsync( TypeofPermission.CreateTypeOfPermission(typeOfPermissionDTO));

        return Result.Response(System.Net.HttpStatusCode.Created,"Öğe Eklendi");
       
    }
}
