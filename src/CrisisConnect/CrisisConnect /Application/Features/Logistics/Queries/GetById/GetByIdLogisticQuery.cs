using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Logistics.Queries.GetById;

public class GetByIdLogisticQuery: IRequest<GetByIdLogisticResponse>
{
    public Guid Id { get; set; }
    
    public class GetByIdLogisticQueryHandler : IRequestHandler<GetByIdLogisticQuery, GetByIdLogisticResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILogisticRepository _logisticRepository;

        public GetByIdLogisticQueryHandler(IMapper mapper, ILogisticRepository logisticRepository)
        {
            _mapper = mapper;
            _logisticRepository = logisticRepository;
        }

        public async Task<GetByIdLogisticResponse> Handle(GetByIdLogisticQuery request, CancellationToken cancellationToken)
        {
            Logistic? logistic = await _logisticRepository.GetAsync(predicate: l => l.Id == request.Id, withDeleted: true, cancellationToken: cancellationToken);
            GetByIdLogisticResponse response = _mapper.Map<GetByIdLogisticResponse>(logistic);
            return response;
        }
    }
}