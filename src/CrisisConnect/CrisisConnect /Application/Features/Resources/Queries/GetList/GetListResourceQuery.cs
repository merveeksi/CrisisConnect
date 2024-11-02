using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Resources.Queries.GetList;

public class GetListResourceQuery:IRequest<GetListResponse<GetListResourceListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    
    public class GetListResourceQueryHandler : IRequestHandler<GetListResourceQuery, GetListResponse<GetListResourceListItemDto>>
    {
        private readonly IResourceRepository _resourceRepository;
        private readonly IMapper _mapper;

        public GetListResourceQueryHandler(IResourceRepository resourceRepository, IMapper mapper)
        {
            _resourceRepository = resourceRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListResourceListItemDto>> Handle(GetListResourceQuery request, CancellationToken cancellationToken)
        {
            Paginate<Resource> resources = await _resourceRepository.GetListAsync(
                include: r => r.Include(r => r.Centers).Include(r=>r.Requests)
                    .Include(r=>r.Shelters).Include(r=>r.Donors),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken,
                withDeleted: true
            );

            GetListResponse<GetListResourceListItemDto> response = _mapper.Map<GetListResponse<GetListResourceListItemDto>>(resources);
            return response;
        }
    }
}