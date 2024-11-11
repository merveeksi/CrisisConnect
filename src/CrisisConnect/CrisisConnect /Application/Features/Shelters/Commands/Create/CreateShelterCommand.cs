using Application.Features.Logistics.Commands.Create;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.Features.Shelters.Commands.Create;

public class CreateShelterCommand : IRequest<CreatedShelterResponse>,  ITransactionalRequest, ICacheRemoverRequest, ILoggableRequest
{
    public string? CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetShelters";

    public string Location { get; set; }
    public string ContactInfo { get; set; }
    public int Capacity { get; set; }


    public class CreateShelterCommandHandler : IRequestHandler<CreateShelterCommand, CreatedShelterResponse>
    {
        private readonly IShelterRepository _shelterRepository;
        private readonly IMapper _mapper;
        
        public CreateShelterCommandHandler(IMapper mapper, IShelterRepository shelterRepository)
        {
            _shelterRepository = shelterRepository;
            _mapper = mapper;
        }

        public async Task<CreatedShelterResponse>? Handle(CreateShelterCommand request, CancellationToken cancellationToken)
        {
            Shelter shelter = _mapper.Map<Shelter>(request);
            shelter.Id = new ShelterId(DateTime.UtcNow.Ticks);
            
            await _shelterRepository.AddAsync(shelter);
            
            CreatedShelterResponse createdShelterResponse = _mapper.Map<CreatedShelterResponse>(shelter);
            return createdShelterResponse;
        }
    }
}