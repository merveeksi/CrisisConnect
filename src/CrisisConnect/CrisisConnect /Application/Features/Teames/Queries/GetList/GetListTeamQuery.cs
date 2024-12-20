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

namespace Application.Features.Teames.Queries.GetList;

public class GetListTeamQuery : IRequest<GetListResponse<GetListTeamListItemDto>>, ICachableRequest, ILoggableRequest
{
    public PageRequest PageRequest { get; set; }
    
    public string CacheKey => $"GetListTeamQuery({PageRequest.PageIndex}_{PageRequest.PageSize})";
    public bool BypassCache { get; }
    public string? CacheGroupKey => "GetTeams";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetListTeamQueryHandler : IRequestHandler<GetListTeamQuery, GetListResponse<GetListTeamListItemDto>>
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;

        public GetListTeamQueryHandler(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTeamListItemDto>> Handle(GetListTeamQuery request, CancellationToken cancellationToken)
        {
            Paginate<Team> teams = await _teamRepository.GetListAsync(
                include: t => t.Include(t => t.Volunteer).Include(t=>t.Center)
                    .Include(t=>t.Requests),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken,
                withDeleted: true
            );

            GetListResponse<GetListTeamListItemDto> response = _mapper.Map<GetListResponse<GetListTeamListItemDto>>(teams);
            return response;
        }
    }
}