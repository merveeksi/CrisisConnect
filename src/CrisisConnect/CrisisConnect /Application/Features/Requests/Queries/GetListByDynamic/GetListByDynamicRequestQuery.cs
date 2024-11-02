using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Requests.Queries.GetListByDynamic;

public class GetListByDynamicRequestQuery: IRequest<GetListResponse<GetListByDynamicRequestListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public class GetListByDynamicRequestQueryHandler : IRequestHandler<GetListByDynamicRequestQuery, GetListResponse<GetListByDynamicRequestListItemDto>>
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IMapper _mapper;

        public GetListByDynamicRequestQueryHandler(IRequestRepository requestRepository, IMapper mapper)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
        }
        public async Task<GetListResponse<GetListByDynamicRequestListItemDto>> Handle(GetListByDynamicRequestQuery request, CancellationToken cancellationToken)
        {
            Paginate<Request> requests = await _requestRepository.GetListByDynamicAsync(
                request.DynamicQuery,
                include: r => r.Include(r => r.Shelter).Include(r=>r.Resources)
                    .Include(r=>r.Teams),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize
            );

            var response = _mapper.Map<GetListResponse<GetListByDynamicRequestListItemDto>>(requests);

            return response;
        }
    }
}