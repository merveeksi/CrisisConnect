using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Shelters.Queries;

public class GetListShelterQuery:IRequest<GetListResponse<GetListShelterListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    
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
                include: s=>s.Include(s=>s.Disaster),
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