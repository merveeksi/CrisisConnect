using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Shelters.Queries.GetListByDynamic;

public class GetListByDynamicShelterQuery: IRequest<GetListResponse<GetListByDynamicShelterListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public class GetListByDynamicShelterQueryHandler : IRequestHandler<GetListByDynamicShelterQuery, GetListResponse<GetListByDynamicShelterListItemDto>>
    {
        private readonly IShelterRepository _shelterRepository;
        private readonly IMapper _mapper;

        public GetListByDynamicShelterQueryHandler(IShelterRepository shelterRepository, IMapper mapper)
        {
            _shelterRepository = shelterRepository;
            _mapper = mapper;
        }
        public async Task<GetListResponse<GetListByDynamicShelterListItemDto>> Handle(GetListByDynamicShelterQuery request, CancellationToken cancellationToken)
        {
            Paginate<Shelter> shelters = await _shelterRepository.GetListByDynamicAsync(
                request.DynamicQuery,
                include: s => s.Include(s => s.Volunteer).Include(s => s.Disaster)
                    .Include(s=>s.Request).Include(s=>s.Resources),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize
            );

            var response = _mapper.Map<GetListResponse<GetListByDynamicShelterListItemDto>>(shelters);

            return response;
        }
    }
}