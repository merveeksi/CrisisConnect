using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;
using MediatR;

namespace Application.Features.Disasters.Commands.Create;

//Alacağım bilgi

public class CreateDisasterCommand:IRequest<CreatedDisasterResponse>, ITransactionalRequest // IRequest<TResponse>
{
    public string Name { get; set; }
    public DisasterType Type { get; set; }
    public bool IsActive { get; set; }
    public DisasterStatus Status { get; set; }
    public Address Address { get; set; }
    public string EmergencyContactInfo { get; set; }
    public ImpactAssessment ImpactAssessment { get; set; }
    
    public DateTime DateOccurred { get; set; }
    public DateTime? DateResolved { get; set; } 

    public DateTime CreatedAt { get; set; }
    public DateTime? LastUpdatedAt { get; set; }
    
    
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
            disaster.Id = Guid.NewGuid();
            
            await _disasterRepository.AddAsync(disaster);
            
            CreatedDisasterResponse createdDisasterResponse = _mapper.Map<CreatedDisasterResponse>(disaster);
            return createdDisasterResponse;
            
        }
    }
}
