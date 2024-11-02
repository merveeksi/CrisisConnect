using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Alerts.Queries.GetListByDynamic;

public class GetListByDynamicAlertQuery: IRequest<GetListResponse<GetListByDynamicAlertListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public class GetListByDynamicAlertQueryHandler : IRequestHandler<GetListByDynamicAlertQuery, GetListResponse<GetListByDynamicAlertListItemDto>>
    {
        private readonly IAlertRepository _alertRepository;
        private readonly IMapper _mapper;

        public GetListByDynamicAlertQueryHandler(IAlertRepository alertRepository, IMapper mapper)
        {
            _alertRepository = alertRepository;
            _mapper = mapper;
        }
        public async Task<GetListResponse<GetListByDynamicAlertListItemDto>> Handle(GetListByDynamicAlertQuery request, CancellationToken cancellationToken)
        {
            Paginate<Alert> alerts = await _alertRepository.GetListByDynamicAsync(
                request.DynamicQuery,
                include: a => a.Include(a => a.Disaster),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize
            );

            var response = _mapper.Map<GetListResponse<GetListByDynamicAlertListItemDto>>(alerts);

            return response;
        }
    }
}