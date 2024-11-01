using Application.Features.Disasters.Queries.GetListByDynamic;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Teams.Queries.GetListByDynamic;

public class GetListByDynamicTeamQuery: IRequest<GetListResponse<GetListByDynamicTeamListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public class GetListByDynamicTeamQueryHandler : IRequestHandler<GetListByDynamicTeamQuery, GetListResponse<GetListByDynamicTeamListItemDto>>
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;

        public GetListByDynamicTeamQueryHandler(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }
        public async Task<GetListResponse<GetListByDynamicTeamListItemDto>> Handle(GetListByDynamicTeamQuery request, CancellationToken cancellationToken)
        {
            Paginate<Team> teams = await _teamRepository.GetListByDynamicAsync(
                request.DynamicQuery,
                include: d => d.Include(d => d.Volunteer),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize
            );

            var response = _mapper.Map<GetListResponse<GetListByDynamicTeamListItemDto>>(teams);

            return response;
        }
    }
}