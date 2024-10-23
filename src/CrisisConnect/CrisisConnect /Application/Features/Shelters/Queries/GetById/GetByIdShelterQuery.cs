using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Shelters.Queries.GetById;

public class GetByIdShelterQuery:IRequest<GetByIdShelterResponse>
{
    public Guid Id { get; set; }
    
    public class GetByIdShelterQueryHandler : IRequestHandler<GetByIdShelterQuery, GetByIdShelterResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShelterRepository _shelterRepository;

        public GetByIdShelterQueryHandler(IMapper mapper, IShelterRepository shelterRepository)
        {
            _mapper = mapper;
            _shelterRepository = shelterRepository;
        }

        public async Task<GetByIdShelterResponse> Handle(GetByIdShelterQuery request, CancellationToken cancellationToken)
        {
            Shelter? shelter = await _shelterRepository.GetAsync(predicate: s => s.Id == request.Id, withDeleted:true, cancellationToken:cancellationToken);
            GetByIdShelterResponse response = _mapper.Map<GetByIdShelterResponse>(shelter);
            return response;
        }
    }
}