using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.Resources.Commands.Delete;

public class DeleteResourceCommand: IRequest<DeletedResourceResponse>, ICacheRemoverRequest
{
public string? CacheKey => "";
public bool BypassCache => false;
public string? CacheGroupKey => "GetResources";

    public Guid Id { get; set; }
    
    public class UpdateResourceCommandHandler : IRequestHandler<DeleteResourceCommand, DeletedResourceResponse>
    {
        private readonly IResourceRepository _resourceRepository;
        private readonly IMapper _mapper;

        public UpdateResourceCommandHandler(IResourceRepository resourceRepository, IMapper mapper)
        {
            _resourceRepository = resourceRepository;
            _mapper = mapper;
        }

        public async Task<DeletedResourceResponse> Handle(DeleteResourceCommand request,
            CancellationToken cancellationToken)
        {
            Resource? resource = await _resourceRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            
            await _resourceRepository.UpdateAsync(resource);
            
            DeletedResourceResponse response = _mapper.Map<DeletedResourceResponse>(resource); 
            return response;
        }
    }
}