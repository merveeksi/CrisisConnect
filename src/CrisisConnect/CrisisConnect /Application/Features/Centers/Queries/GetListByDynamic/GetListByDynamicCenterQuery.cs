using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Centers.Queries.GetListByDynamic;

public class GetListByDynamicCenterQuery: IRequest<GetListResponse<GetListByDynamicCenterListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public class GetListByDynamicCenterQueryHandler : IRequestHandler<GetListByDynamicCenterQuery, GetListResponse<GetListByDynamicCenterListItemDto>>
    {
        private readonly ICenterRepository _centerRepository;
        private readonly IMapper _mapper;

        public GetListByDynamicCenterQueryHandler(ICenterRepository centerRepository, IMapper mapper)
        {
            _centerRepository = centerRepository;
            _mapper = mapper;
        }
        public async Task<GetListResponse<GetListByDynamicCenterListItemDto>> Handle(GetListByDynamicCenterQuery request, CancellationToken cancellationToken)
        {
            Paginate<Center> centers = await _centerRepository.GetListByDynamicAsync(
                request.DynamicQuery,
                include: c => c.Include(c => c.Teams).Include(c=>c.Resources),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize
            );

            var response = _mapper.Map<GetListResponse<GetListByDynamicCenterListItemDto>>(centers);

            return response;
        }
    }
}