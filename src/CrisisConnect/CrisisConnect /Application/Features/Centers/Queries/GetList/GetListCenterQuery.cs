using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Centers.Queries;

public class GetListCenterQuery : IRequest<GetListResponse<GetListCenterListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    
    public class GetListCenterQueryHandler : IRequestHandler<GetListCenterQuery, GetListResponse<GetListCenterListItemDto>>
    {
        private readonly ICenterRepository _centerRepository;
        private readonly IMapper _mapper;
        
        public GetListCenterQueryHandler(ICenterRepository centerRepository, IMapper mapper)
        {
            _centerRepository = centerRepository;
            _mapper = mapper;
        }
        
        public async Task<GetListResponse<GetListCenterListItemDto>> Handle(GetListCenterQuery request, CancellationToken cancellationToken)
        {
            Paginate<Center> centers =  await _centerRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken : cancellationToken,
                withDeleted:true
            );
            GetListResponse<GetListCenterListItemDto> response = _mapper.Map<GetListResponse<GetListCenterListItemDto>>(centers);
            return response;
        }
    }
}