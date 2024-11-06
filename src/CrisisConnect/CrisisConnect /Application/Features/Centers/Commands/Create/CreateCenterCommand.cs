using Application.Features.Centers.Commands.Create;
using Application.Features.Centers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;

namespace Application.Features.Centers.Commands.Create;

public class CreateCenterCommand:IRequest<CreatedCenterResponse>, ITransactionalRequest, ICacheRemoverRequest, ILoggableRequest
{
    public string? CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetCenters";
    public string Name { get; set; }
    public string Location { get; set; }
    public int Capacity { get; set; }
}

public class CreateCenterCommandHandler : IRequestHandler<CreateCenterCommand, CreatedCenterResponse>
{
    private readonly ICenterRepository _centerRepository;
    private readonly IMapper _mapper;
    private readonly CenterBusinessRules _centerBusinessRules;
    

    public CreateCenterCommandHandler(ICenterRepository centerRepository, IMapper mapper, CenterBusinessRules centerBusinessRules)
    {
        _centerRepository = centerRepository;
        _mapper = mapper;
        _centerBusinessRules = centerBusinessRules;
    }

    public async Task<CreatedCenterResponse>? Handle(CreateCenterCommand request, CancellationToken cancellationToken)
    {
        await _centerBusinessRules.CenterNameCannotBeDuplicatedWhenInserted(request.Name);
        
        Center center = _mapper.Map<Center>(request);
        center.Id = Guid.NewGuid();

        await _centerRepository.AddAsync(center);
        
        CreatedCenterResponse createdCenterResponse = _mapper.Map<CreatedCenterResponse>(center);
        return createdCenterResponse;
    }
}