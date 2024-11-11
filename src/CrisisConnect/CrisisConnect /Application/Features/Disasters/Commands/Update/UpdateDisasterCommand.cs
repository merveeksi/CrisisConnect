using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.Features.Disasters.Commands.Update;

public class UpdateDisasterCommand : IRequest<UpdatedDisasterResponse>, ICacheRemoverRequest
{
    public string? CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetDisasters";
    public DisasterId Id { get; set; }
    
    public string Name { get; set; }

    public class UpdateDisasterCommandHandler : IRequestHandler<UpdateDisasterCommand, UpdatedDisasterResponse>
    {
        private readonly IDisasterRepository _disasterRepository;
        private readonly IMapper _mapper;

        public UpdateDisasterCommandHandler(IDisasterRepository disasterRepository, IMapper mapper)
        {
            _disasterRepository = disasterRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedDisasterResponse> Handle(UpdateDisasterCommand request,
            CancellationToken cancellationToken)
        {
            Disaster? disaster = await _disasterRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            disaster = _mapper.Map(request, disaster);
            await _disasterRepository.UpdateAsync(disaster); //veritabanına kaydetme işlemi
            UpdatedDisasterResponse
                response = _mapper
                    .Map<UpdatedDisasterResponse>(
                        disaster); //disaster nesnesini UpdatedDisasterResponse nesnesine dönüştürme işlemi
            return response;
        }
    }
}