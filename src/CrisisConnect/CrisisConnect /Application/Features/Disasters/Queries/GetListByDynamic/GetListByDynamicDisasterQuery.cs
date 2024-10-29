using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Disasters.Queries.GetListByDynamic;

public class GetListByDynamicDisasterQuery: IRequest<GetListResponse<GetListByDynamicDisasterListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public class GetListByDynamicDisasterQueryHandler : IRequestHandler<GetListByDynamicDisasterQuery, GetListResponse<GetListByDynamicDisasterListItemDto>>
    {
        private readonly IDisasterRepository _disasterRepository;
        private readonly IMapper _mapper;

        public GetListByDynamicDisasterQueryHandler(IDisasterRepository disasterRepository, IMapper mapper)
        {
            _disasterRepository = disasterRepository;
            _mapper = mapper;
        }
        public async Task<GetListResponse<GetListByDynamicDisasterListItemDto>> Handle(GetListByDynamicDisasterQuery request, CancellationToken cancellationToken)
        {
            Paginate<Disaster> disasters = await _disasterRepository.GetListByDynamicAsync(
                request.DynamicQuery,
                include: d => d.Include(d => d.Team).Include(d => d.Resources).Include(d => d.Alert),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize
            );

            var response = _mapper.Map<GetListResponse<GetListByDynamicDisasterListItemDto>>(disasters);

            return response;
        }
    }
}