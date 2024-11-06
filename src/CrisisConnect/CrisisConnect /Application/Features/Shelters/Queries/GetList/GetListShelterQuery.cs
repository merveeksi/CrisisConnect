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

namespace Application.Features.Shelters.Queries.GetList;

public class GetListShelterQuery:IRequest<GetListResponse<GetListShelterListItemDto>>, ICachableRequest, ILoggableRequest
{
    public PageRequest PageRequest { get; set; }
    
    
    public string CacheKey => $"GetListShelterQuery({PageRequest.PageIndex}_{PageRequest.PageSize})";
    public bool BypassCache { get; }
    public string? CacheGroupKey => "GetShelters";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetListShelterQueryHandler : IRequestHandler<GetListShelterQuery, GetListResponse<GetListShelterListItemDto>>
    {
        private readonly IShelterRepository _shelterRepository;
        private readonly IMapper _mapper;

        public GetListShelterQueryHandler(IShelterRepository shelterRepository, IMapper mapper)
        {
            _shelterRepository = shelterRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListShelterListItemDto>> Handle(GetListShelterQuery request, CancellationToken cancellationToken)
        {
            Paginate<Shelter> shelters =  await _shelterRepository.GetListAsync(
                include: s => s.Include(s => s.Volunteer).Include(s => s.Disaster)
                    .Include(s=>s.Request).Include(s=>s.Resources),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken : cancellationToken,
                withDeleted:true
            );

            GetListResponse<GetListShelterListItemDto> response = _mapper.Map<GetListResponse<GetListShelterListItemDto>>(shelters);
            return response;
        }
    }
}