using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Centers.Queries.GetById;

public class GetByIdCenterQuery:IRequest<GetByIdCenterResponse>
{
    public Guid Id { get; set; }
    
    public class GetByIdCenterQueryHandler : IRequestHandler<GetByIdCenterQuery, GetByIdCenterResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICenterRepository _centerRepository;

        public GetByIdCenterQueryHandler(IMapper mapper, ICenterRepository centerRepository)
        {
            _mapper = mapper;
            _centerRepository = centerRepository;
        }

        public async Task<GetByIdCenterResponse> Handle(GetByIdCenterQuery request, CancellationToken cancellationToken)
        {
            Center? center = await _centerRepository.GetAsync(predicate: c => c.Id == request.Id, withDeleted: true, cancellationToken: cancellationToken);
            GetByIdCenterResponse response = _mapper.Map<GetByIdCenterResponse>(center);
            return response;
        }
    }
}