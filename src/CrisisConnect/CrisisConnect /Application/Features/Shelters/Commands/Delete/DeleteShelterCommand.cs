using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.Features.Shelters.Commands.Delete;

public class DeleteShelterCommand: IRequest<DeletedShelterResponse>, ICacheRemoverRequest
{
public string? CacheKey => "";
public bool BypassCache => false;
public string? CacheGroupKey => "GetShelters";

    public ShelterId Id { get; set; }
    
    public class DeleteShelterCommandHandler : IRequestHandler<DeleteShelterCommand, DeletedShelterResponse>
    {
        private readonly IShelterRepository _shelterRepository;
        private readonly IMapper _mapper;

        public DeleteShelterCommandHandler(IShelterRepository shelterRepository, IMapper mapper)
        {
            _shelterRepository = shelterRepository;
            _mapper = mapper;
        }

        public async Task<DeletedShelterResponse> Handle(DeleteShelterCommand request,
            CancellationToken cancellationToken)
        {
            Shelter? shelter = await _shelterRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            
            await _shelterRepository.UpdateAsync(shelter);
            
            DeletedShelterResponse response = _mapper.Map<DeletedShelterResponse>(shelter); 
            return response;
        }
    }
}