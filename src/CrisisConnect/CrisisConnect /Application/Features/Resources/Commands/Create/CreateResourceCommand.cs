using Application.Features.Resources.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Resources.Commands.Create;

public class CreateResourceCommand : IRequest<CreatedResourceResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ResourceType Type { get; set; }
    public int Quantity { get; set; }
    public string Location { get; set; }
    

    public class CreateResourceCommandHandler : IRequestHandler<CreateResourceCommand, CreatedResourceResponse>
    {
        private readonly IResourceRepository _resourceRepository;
        private readonly IMapper _mapper;
        private readonly ResourceBusinessRules _resourceBusinessRules;


        public CreateResourceCommandHandler(IResourceRepository resourceRepository, IMapper mapper, ResourceBusinessRules resourceBusinessRules)
        {
            _resourceRepository = resourceRepository;
            _mapper = mapper;
            _resourceBusinessRules = resourceBusinessRules;
        }

        public async Task<CreatedResourceResponse>? Handle(CreateResourceCommand request, CancellationToken cancellationToken)
        {
            await _resourceBusinessRules.CheckResourceAvailability(request.Id, request.Quantity);
            
            Resource resource = _mapper.Map<Resource>(request);
            resource.Id = Guid.NewGuid();

            await _resourceRepository.AddAsync(resource);

            CreatedResourceResponse createdResourceResponse = _mapper.Map<CreatedResourceResponse>(resource);
            return createdResourceResponse;
        }
    }
}