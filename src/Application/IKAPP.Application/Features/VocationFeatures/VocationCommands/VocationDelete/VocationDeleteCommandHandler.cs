using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Contract.VocationRepositories;
using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions;
using IKAPP.Domain.Entities.AggregateModels.Vocations;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IKAPP.Application.Features.VocationFeatures.VocationCommands.VocationDelete;

public class VocationDeleteCommandHandler : BaseHandler<IVocationReadRepository, IVocationWriteRepository>, IRequestHandler<VocationDeleteCommand, IResult>
{
    public VocationDeleteCommandHandler(IMapper mapper, IUnitOfWork<IVocationReadRepository, IVocationWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
    }

    public async Task<IResult> Handle(VocationDeleteCommand request, CancellationToken cancellationToken)
    {
        Vocation? vocation = await unitOfWork.ReadRepository.GetByIdAsync(request.Id);

        await unitOfWork.WriteRepository.DeleteAsync(vocation!);
        await unitOfWork.SaveAsync();
        return Result.Response(System.Net.HttpStatusCode.OK, "Silme işlemi başarıyla Tamamlandı.");
    }
}
