using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Disasters.Queries.GetById;

public class GetByIdDisasterQuery: IRequest<GetByIdDisasterResponse>
{
    public Guid Id { get; set; }

    public class GetByIdDisasterQueryHandler:IRequestHandler<GetByIdDisasterQuery,GetByIdDisasterResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDisasterRepository _disasterRepository;

        public GetByIdDisasterQueryHandler(IMapper mapper, IDisasterRepository disasterRepository)
        {
            _mapper = mapper;
            _disasterRepository = disasterRepository;
        }

        public async Task<GetByIdDisasterResponse> Handle(GetByIdDisasterQuery request, CancellationToken cancellationToken)
        {
            Disaster? disaster = await _disasterRepository.GetAsync(predicate: d => d.Id == request.Id, withDeleted:true, cancellationToken:cancellationToken);

            GetByIdDisasterResponse response = _mapper.Map<GetByIdDisasterResponse>(disaster);

            return response;
        }
    }
}