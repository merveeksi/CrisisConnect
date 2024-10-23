using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Teames.Queries;

public class GetListTeamQuery : IRequest<GetListResponse<GetListTeamListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    
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