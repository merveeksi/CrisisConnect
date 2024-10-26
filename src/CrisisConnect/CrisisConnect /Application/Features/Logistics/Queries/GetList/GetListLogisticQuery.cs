using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Logistics.Queries;

public class GetListLogisticQuery : IRequest<GetListResponse<GetListLogisticListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    
    public class GetListLogisticQueryHandler : IRequestHandler<GetListLogisticQuery, GetListResponse<GetListLogisticListItemDto>>
    {
        private readonly ILogisticRepository _logisticRepository;
        private readonly IMapper _mapper;

        public GetListLogisticQueryHandler(ILogisticRepository logisticRepository, IMapper mapper)
        {
            _logisticRepository = logisticRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLogisticListItemDto>> Handle(GetListLogisticQuery request, CancellationToken cancellationToken)
        {
            Paginate<Logistic> logistics =  await _logisticRepository.GetListAsync(
                include: l=>l.Include(l=>l.Disaster).Include(l=>l.Resource),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken : cancellationToken,
                withDeleted:true
            );

            GetListResponse<GetListLogisticListItemDto> response = _mapper.Map<GetListResponse<GetListLogisticListItemDto>>(logistics);
            return response;
        }
    }
}