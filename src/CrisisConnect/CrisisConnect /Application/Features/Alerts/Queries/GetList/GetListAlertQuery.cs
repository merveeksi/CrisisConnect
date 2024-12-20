using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Alerts.Queries.GetList;

public class GetListAlertQuery :IRequest<GetListResponse<GetListAlertListItemDto>>, ICachableRequest, ILoggableRequest
{
    public PageRequest PageRequest { get; set; }
    
    public string CacheKey => $"GetListAlertQuery({PageRequest.PageIndex}_{PageRequest.PageSize})";
    public bool BypassCache { get; }
    public string? CacheGroupKey => "GetAlerts";
    public TimeSpan? SlidingExpiration { get; }
    
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
                include: a => a.Include(a => a.Disaster),
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