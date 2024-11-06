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

namespace Application.Features.Requests.Queries.GetList;

public class GetListRequestQuery :IRequest<GetListResponse<GetListRequestListItemDto>>, ICachableRequest, ILoggableRequest
{
    public PageRequest PageRequest { get; set; }
    
    public string CacheKey => $"GetListRequestQuery({PageRequest.PageIndex}_{PageRequest.PageSize})";
    public bool BypassCache { get; }
    public string? CacheGroupKey => "GetRequests";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetListRequestQueryHandler : IRequestHandler<GetListRequestQuery, GetListResponse<GetListRequestListItemDto>>
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IMapper _mapper;

        public GetListRequestQueryHandler(IRequestRepository requestRepository, IMapper mapper)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
        }
        
        public async Task<GetListResponse<GetListRequestListItemDto>> Handle(GetListRequestQuery request, CancellationToken cancellationToken)
        {
            Paginate<Request> requests =  await _requestRepository.GetListAsync(
                include: r => r.Include(r => r.Shelter).Include(r=>r.Resources)
                    .Include(r=>r.Teams),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken : cancellationToken,
                withDeleted:true
            );
            
            GetListResponse<GetListRequestListItemDto> response = _mapper.Map<GetListResponse<GetListRequestListItemDto>>(requests);
            return response;
        }
    }
}