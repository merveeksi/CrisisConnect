using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Alerts.Queries;

public class GetListAlertQuery :IRequest<GetListResponse<GetListAlertListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    
    public class GetListAlertQueryHandler : IRequestHandler<GetListAlertQuery, GetListResponse<GetListAlertListItemDto>>
    {
        private readonly IAlertRepository _alertRepository;
        private readonly IMapper _mapper;

        public GetListAlertQueryHandler(IAlertRepository alertRepository, IMapper mapper)
        {
            _alertRepository = alertRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAlertListItemDto>> Handle(GetListAlertQuery request, CancellationToken cancellationToken)
        {
            Paginate<Alert> alerts = await _alertRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken,
                withDeleted: true
            );

            GetListResponse<GetListAlertListItemDto> response = _mapper.Map<GetListResponse<GetListAlertListItemDto>>(alerts);
            return response;
        }
    }
}