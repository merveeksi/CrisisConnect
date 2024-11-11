using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.Features.Shelters.Commands.Update;

public class UpdateShelterCommand : IRequest<UpdatedShelterResponse>, ICacheRemoverRequest
{
    public string? CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetShelters";
    public ShelterId Id { get; set; }
    
    public string Name { get; set; }

    public class UpdateShelterCommandHandler : IRequestHandler<UpdateShelterCommand, UpdatedShelterResponse>
    {
        private readonly IShelterRepository _shelterRepository;
        private readonly IMapper _mapper;

        public UpdateShelterCommandHandler(IShelterRepository shelterRepository, IMapper mapper)
        {
            _shelterRepository = shelterRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedShelterResponse> Handle(UpdateShelterCommand request,
            CancellationToken cancellationToken)
        {
            Shelter? shelter = await _shelterRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            shelter = _mapper.Map(request, shelter);
            await _shelterRepository.UpdateAsync(shelter); //veritabanına kaydetme işlemi
            UpdatedShelterResponse
                response = _mapper
                    .Map<UpdatedShelterResponse>(
                        shelter); //shelter nesnesini UpdatedShelterResponse nesnesine dönüştürme işlemi
            return response;
        }
    }
}