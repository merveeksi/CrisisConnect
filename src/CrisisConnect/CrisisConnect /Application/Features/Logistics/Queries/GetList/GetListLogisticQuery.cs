using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Logistics.Queries.GetList;

public class GetListLogisticQuery : IRequest<GetListResponse<GetListLogisticListItemDto>>, ICachableRequest, ILoggableRequest
{
    public PageRequest PageRequest { get; set; }
    
    public string CacheKey => $"GetListLogisticQuery({PageRequest.PageIndex}_{PageRequest.PageSize})";
    public bool BypassCache { get; }
    public string? CacheGroupKey => "GetLogistics";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetListLogisticQueryHandler : IRequestHandler<GetListLogisticQuery, GetListResponse<GetListLogisticListItemDto>>
    {
        private readonly ILogisticRepository _logisticRepository;
        private readonly IMapper _mapper;

        public GetListLogisticQueryHandler(ILogisticRepository logisticRepository, IMapper mapper)
        {
            _logisticRepository = logisticRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLogisticListItemDto>> Handle(GetListLogisticQuery request, CancellationToken cancellationToken)
        {
            Paginate<Logistic> logistics =  await _logisticRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken : cancellationToken,
                withDeleted:true
            );

            GetListResponse<GetListLogisticListItemDto> response = _mapper.Map<GetListResponse<GetListLogisticListItemDto>>(logistics);
            return response;
        }
    }
}