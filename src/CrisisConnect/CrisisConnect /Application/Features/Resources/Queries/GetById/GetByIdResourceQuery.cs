using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Resources.Queries.GetById;

public class GetByIdResourceQuery :IRequest<GetByIdResourceResponse>
{
    public Guid Id { get; set; }
    
    public class GetByIdResourceQueryHandler : IRequestHandler<GetByIdResourceQuery, GetByIdResourceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IResourceRepository _resourceRepository;

        public GetByIdResourceQueryHandler(IMapper mapper, IResourceRepository resourceRepository)
        {
            _mapper = mapper;
            _resourceRepository = resourceRepository;
        }

        public async Task<GetByIdResourceResponse> Handle(GetByIdResourceQuery request, CancellationToken cancellationToken)
        {
            Resource? resource = await _resourceRepository.GetAsync(predicate: r => r.Id == request.Id, withDeleted:true, cancellationToken:cancellationToken);

            GetByIdResourceResponse response = _mapper.Map<GetByIdResourceResponse>(resource);

            return response;
        }
    }
   
}