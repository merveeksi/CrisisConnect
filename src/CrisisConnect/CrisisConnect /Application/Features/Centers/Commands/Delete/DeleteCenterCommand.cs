using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.Centers.Commands.Delete;

public class DeleteCenterCommand: IRequest<DeletedCenterResponse>, ICacheRemoverRequest
{
    public string? CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetCenters";
    public Guid Id { get; set; }
    
    public class UpdateCenterCommandHandler : IRequestHandler<DeleteCenterCommand, DeletedCenterResponse>
    {
        private readonly ICenterRepository _centerRepository;
        private readonly IMapper _mapper;

        public UpdateCenterCommandHandler(ICenterRepository centerRepository, IMapper mapper)
        {
            _centerRepository = centerRepository;
            _mapper = mapper;
        }

        public async Task<DeletedCenterResponse> Handle(DeleteCenterCommand request,
            CancellationToken cancellationToken)
        {
            Center? center = await _centerRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            
            await _centerRepository.UpdateAsync(center);
            
            DeletedCenterResponse response = _mapper.Map<DeletedCenterResponse>(center); 
            return response;
        }
    }
}