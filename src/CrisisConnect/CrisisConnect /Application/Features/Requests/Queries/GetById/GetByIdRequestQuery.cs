using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Requests.Queries.GetById;

public class GetByIdRequestQuery:IRequest<GetByIdRequestResponse>
{
    public Guid Id { get; set; }
    
    public class GetByIdRequestQueryhandler : IRequestHandler<GetByIdRequestQuery, GetByIdRequestResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequestRepository _requestRepository;

        public GetByIdRequestQueryhandler(IMapper mapper, IRequestRepository requestRepository)
        {
            _mapper = mapper;
            _requestRepository = requestRepository;
        }

        public async Task<GetByIdRequestResponse> Handle(GetByIdRequestQuery request, CancellationToken cancellationToken)
        {
           Request? requestEntity = await _requestRepository.GetAsync(predicate: r => r.Id == request.Id, withDeleted:true, cancellationToken:cancellationToken);
           GetByIdRequestResponse response = _mapper.Map<GetByIdRequestResponse>(requestEntity);
           return response;
        }
    }
}