using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Donors.Queries.GetListByDynamic;

public class GetListByDynamicDonorQuery :IRequest<GetListResponse<GetListByDynamicDonorListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }
    
    public class GetListByDynamicDonorQueryHandler : IRequestHandler<GetListByDynamicDonorQuery, GetListResponse<GetListByDynamicDonorListItemDto>>
    {
        private readonly IDonorRepository _donorRepository;
        private readonly IMapper _mapper;
        
        public GetListByDynamicDonorQueryHandler(IDonorRepository donorRepository, IMapper mapper)
        {
            _donorRepository = donorRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByDynamicDonorListItemDto>> Handle(GetListByDynamicDonorQuery request,
            CancellationToken cancellationToken)
        {
            Paginate<Donor> donors = await _donorRepository.GetListByDynamicAsync(
                request.DynamicQuery,
                //Entity'deki birerbir ilişkierin include edilmesi
                include: d=>d.Include(d=>d.Disaster)
                    .Include(d=>d.Alert)
                    .Include(d=>d.Team),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize
            ).ConfigureAwait(false);

            var response = _mapper.Map<GetListResponse<GetListByDynamicDonorListItemDto>>(donors);
            return response;
        }
    }
}