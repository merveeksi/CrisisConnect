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

namespace Application.Features.Volunteers.Queries.GetList;

public class GetListVolunteerQuery : IRequest<GetListResponse<GetListVolunteerListItemDto>>, ICachableRequest, ILoggableRequest
{
    public PageRequest PageRequest { get; set; }
    
    public string CacheKey => $"GetListVolunteerQuery({PageRequest.PageIndex}_{PageRequest.PageSize})";
    public bool BypassCache { get; }
    public string? CacheGroupKey => "GetVolunteers";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetListVolunteerQueryHandler : IRequestHandler<GetListVolunteerQuery, GetListResponse<GetListVolunteerListItemDto>>
    {
        private readonly IVolunteerRepository _volunteerRepository;
        private readonly IMapper _mapper;

        public GetListVolunteerQueryHandler(IVolunteerRepository volunteerRepository, IMapper mapper)
        {
            _volunteerRepository = volunteerRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListVolunteerListItemDto>> Handle(GetListVolunteerQuery request, CancellationToken cancellationToken)
        {
            Paginate<Volunteer> volunteers = await _volunteerRepository.GetListAsync(
                include: v => v.Include(v => v.Shelter).Include(v=>v.Team)
                    .Include(v=>v.Requests),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken,
                withDeleted: true
            );

            GetListResponse<GetListVolunteerListItemDto> response = _mapper.Map<GetListResponse<GetListVolunteerListItemDto>>(volunteers);
            return response;
        }
    }
}