using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Resources.Commands.Create;

public class CreateResourceCommand : IRequest<CreatedResourceResponse>
{
    public string Name { get; set; }
    public ResourceType Type { get; set; }
    public int Quantity { get; set; }
    public string Location { get; set; }
    

    public class CreateResourceCommandHandler : IRequestHandler<CreateResourceCommand, CreatedResourceResponse>
    {
        private readonly IResourceRepository _resourceRepository;
        private readonly IMapper _mapper;


        public CreateResourceCommandHandler(IResourceRepository resourceRepository, IMapper mapper)
        {
            _resourceRepository = resourceRepository;
            _mapper = mapper;
        }

        public async Task<CreatedResourceResponse>? Handle(CreateResourceCommand request, CancellationToken cancellationToken)
        {
            Resource resource = _mapper.Map<Resource>(request);
            resource.Id = Guid.NewGuid();

            _resourceRepository.AddAsync(resource);

            CreatedResourceResponse createdResourceResponse = _mapper.Map<CreatedResourceResponse>(resource);
            return createdResourceResponse;
        }
    }
}