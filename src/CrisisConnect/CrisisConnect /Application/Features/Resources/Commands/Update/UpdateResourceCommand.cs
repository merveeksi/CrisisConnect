using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.Resources.Commands.Update;

public class UpdateResourceCommand : IRequest<UpdatedResourceResponse>,ICacheRemoverRequest
{
    public string? CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetResources";

    public Guid Id { get; set; }
    
    public string Name { get; set; }

    public class UpdateResourceCommandHandler : IRequestHandler<UpdateResourceCommand, UpdatedResourceResponse>
    {
        private readonly IResourceRepository _resourceRepository;
        private readonly IMapper _mapper;

        public UpdateResourceCommandHandler(IResourceRepository resourceRepository, IMapper mapper)
        {
            _resourceRepository = resourceRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedResourceResponse> Handle(UpdateResourceCommand request,
            CancellationToken cancellationToken)
        {
            Resource? resource = await _resourceRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            resource = _mapper.Map(request, resource);
            await _resourceRepository.UpdateAsync(resource); //veritabanına kaydetme işlemi
            UpdatedResourceResponse
                response = _mapper
                    .Map<UpdatedResourceResponse>(
                        resource); //resource nesnesini UpdatedResourceResponse nesnesine dönüştürme işlemi
            return response;
        }
    }
}