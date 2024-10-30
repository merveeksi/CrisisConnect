using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Donors.Queries;

public class GetListDonorQuery :IRequest<GetListResponse<GetListDonorListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    
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
                //Entity'deki birerbir ilişkierin include edilmesi
                include: d=>d.Include(d=>d.Disaster)
                    .Include(d=>d.Alert)
                    .Include(d=>d.Team),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize
            );

            var response = _mapper.Map<GetListResponse<GetListDonorListItemDto>>(donors);
            return response;
        }
    }
}