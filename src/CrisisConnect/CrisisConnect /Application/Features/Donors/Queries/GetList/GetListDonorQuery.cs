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

namespace Application.Features.Donors.Queries.GetList;

public class GetListDonorQuery :IRequest<GetListResponse<GetListDonorListItemDto>>, ICachableRequest, ILoggableRequest
{
    public PageRequest PageRequest { get; set; }
    
    public string CacheKey => $"GetListDonorQuery({PageRequest.PageIndex}_{PageRequest.PageSize})";
    public bool BypassCache { get; }
    public string? CacheGroupKey => "GetDonors";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetListDonorQueryHandler : IRequestHandler<GetListDonorQuery, GetListResponse<GetListDonorListItemDto>>
    {
        private readonly IDonorRepository _donorRepository;
        private readonly IMapper _mapper;
        
        public GetListDonorQueryHandler(IDonorRepository donorRepository, IMapper mapper)
        {
            _donorRepository = donorRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDonorListItemDto>> Handle(GetListDonorQuery request,
            CancellationToken cancellationToken)
        {
            Paginate<Donor> donors = await _donorRepository.GetListAsync(
                include: d => d.Include(d => d.Resources),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize
            );

            var response = _mapper.Map<GetListResponse<GetListDonorListItemDto>>(donors);
            return response;
        }
    }
}