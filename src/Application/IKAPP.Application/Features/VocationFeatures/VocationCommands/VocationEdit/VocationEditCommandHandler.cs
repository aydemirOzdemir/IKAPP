using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Contract.VocationRepositories;
using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions.TypeofPermissionDTOs;
using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using IKAPP.Domain.Entities.AggregateModels.Vocations;
using IKAPP.Domain.Entities.AggregateModels.Vocations.VocationDTOs;

namespace IKAPP.Application.Features.VocationFeatures.VocationCommands.VocationEdit;

public class VocationEditCommandHandler : BaseHandler<IVocationReadRepository, IVocationWriteRepository>,IRequestHandler<VocationEditCommand,IResult>
{
    public VocationEditCommandHandler(IMapper mapper, IUnitOfWork<IVocationReadRepository, IVocationWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
    }

    public async Task<IResult> Handle(VocationEditCommand request, CancellationToken cancellationToken)
    {
        Vocation? vocation = await unitOfWork.ReadRepository.GetByIdAsync(request.Id);
        VocationUpdateDTO updateDTO = mapper.Map<VocationUpdateDTO>(request);
        await vocation.UpdateVocation(updateDTO);
        var result = await unitOfWork.WriteRepository.UpdateAsync(vocation);
        await unitOfWork.SaveAsync();
        return Result.Response(System.Net.HttpStatusCode.OK, "Güncelleme yapıldı.");
    }
}

