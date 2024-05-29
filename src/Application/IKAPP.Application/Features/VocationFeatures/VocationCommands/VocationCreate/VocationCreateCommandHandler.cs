using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Contract.VocationRepositories;
using IKAPP.Domain.Entities.AggregateModels.Vocations;
using IKAPP.Domain.Entities.AggregateModels.Vocations.VocationDTOs;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IKAPP.Application.Features.VocationFeatures.VocationCommands.VocationCreate;

public class VocationCreateCommandHandler : BaseHandler<IVocationReadRepository, IVocationWriteRepository>, IRequestHandler<VocationCreateCommand, IResult>
{
    public VocationCreateCommandHandler(IMapper mapper, IUnitOfWork<IVocationReadRepository, IVocationWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
    }

    public async Task<IResult> Handle(VocationCreateCommand request, CancellationToken cancellationToken)
    {
      VocationDTO vocationDTO=mapper.Map<VocationDTO>(request);
        vocationDTO.Id = Guid.NewGuid().ToString();
        Vocation result = await unitOfWork.WriteRepository.AddAsync(Vocation.CreateVocation(vocationDTO));
        return Result.Response(System.Net.HttpStatusCode.Created,"Meslek Yüklendi.");
    }
}
