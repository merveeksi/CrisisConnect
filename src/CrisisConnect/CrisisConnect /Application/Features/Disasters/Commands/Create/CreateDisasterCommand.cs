using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Disasters.Commands.Create;

//Alacağım bilgi

public class CreateDisasterCommand:IRequest<CreatedDisasterResponse> // IRequest<TResponse>
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string Location { get; set; }
    public int Severity { get; set; } 
    public DateTime DateOccurred { get; set; }
    public int Casualties { get; set; }
    public string Description { get; set; }
    
    
    
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
