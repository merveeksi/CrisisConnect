using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;
using MediatR;

namespace Application.Features.Disasters.Commands.Create;

//Alacağım bilgi

public class CreateDisasterCommand:IRequest<CreatedDisasterResponse>, ITransactionalRequest, ICacheRemoverRequest, ILoggableRequest
{
    public string? CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetDisasters";
    
    public string Name { get; set; }
    public ContactInfo ContactInfo { get; set; }
    public DisasterType Type { get; set; }
    public DisasterStatus Status { get; set; }
    public ImpactAssessment ImpactAssessment { get; set; }
    public DateTimeInfo DateTime { get; set; }
    
    
    public class CreateDisasterCommandHandler : IRequestHandler<CreateDisasterCommand, CreatedDisasterResponse>
    {
        private readonly IDisasterRepository _disasterRepository;
        private readonly IMapper _mapper;

        public CreateDisasterCommandHandler(IMapper mapper, IDisasterRepository disasterRepository)
        {
            _disasterRepository = disasterRepository;
            _mapper = mapper;
        }


        public async Task<CreatedDisasterResponse>? Handle(CreateDisasterCommand request, CancellationToken cancellationToken)
        {
            Disaster disaster = _mapper.Map<Disaster>(request);
            disaster.Id = new DisasterId(System.DateTime.UtcNow.Ticks);
            
            await _disasterRepository.AddAsync(disaster);
            
            CreatedDisasterResponse createdDisasterResponse = _mapper.Map<CreatedDisasterResponse>(disaster);
            return createdDisasterResponse;
            
        }
    }
}
