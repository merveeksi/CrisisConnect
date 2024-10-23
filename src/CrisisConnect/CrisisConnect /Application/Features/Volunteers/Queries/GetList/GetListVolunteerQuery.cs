using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Volunteers.Queries;

public class GetListVolunteerQuery : IRequest<GetListResponse<GetListVolunteerListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    
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