using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Requests; //  !!isimlendirme hatası var. Core.Application.Requests olmalı
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Disasters.Queries.GetList;

public class GetListDisasterQuery: IRequest<GetListResponse<GetListDisasterListItemDto>>, ICachableRequest, ILoggableRequest
{
    public PageRequest PageRequest { get; set; }  //bana bir sayfalama isteği ver
    
    public string CacheKey => $"GetListDisasterQuery({PageRequest.PageIndex}_{PageRequest.PageSize})";
    public bool BypassCache { get; }
    public string? CacheGroupKey => "GetDisasters";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListDisasterQueryHandler : IRequestHandler<GetListDisasterQuery, GetListResponse<GetListDisasterListItemDto>>
    {
        private readonly IDisasterRepository _disasterRepository;
        private readonly IMapper _mapper;


        public GetListDisasterQueryHandler(IDisasterRepository disasterRepository, IMapper mapper)
        {
            _disasterRepository = disasterRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDisasterListItemDto>> Handle(GetListDisasterQuery request, CancellationToken cancellationToken)
        {
            Paginate<Disaster> disasters =  await _disasterRepository.GetListAsync(
                include: d=>d.Include(d=>d.Center),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken : cancellationToken,
                withDeleted:true
            );

            GetListResponse<GetListDisasterListItemDto> response = _mapper.Map<GetListResponse<GetListDisasterListItemDto>>(disasters);
            return response;

        }
    }
}