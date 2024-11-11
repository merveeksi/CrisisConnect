using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.Features.Alerts.Queries.GetById;

public class GetByIdAlertQuery:IRequest<GetByIdAlertResponse>
{
    public AlertId Id { get; set; }
    
    public class GetByIdAlertQueryHandler : IRequestHandler<GetByIdAlertQuery, GetByIdAlertResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAlertRepository _alertRepository;

        public GetByIdAlertQueryHandler(IMapper mapper, IAlertRepository alertRepository)
        {
            _mapper = mapper;
            _alertRepository = alertRepository;
        }

        public async Task<GetByIdAlertResponse> Handle(GetByIdAlertQuery request, CancellationToken cancellationToken)
        {
            Alert? alert = await _alertRepository.GetAsync(predicate: c => c.Id == request.Id, withDeleted: true, cancellationToken: cancellationToken);
            GetByIdAlertResponse response = _mapper.Map<GetByIdAlertResponse>(alert);
            return response;
        }
    }
}