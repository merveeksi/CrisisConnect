using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Donors.Queries.GetById;

public class GetByIdDonorQuery:IRequest<GetByIdDonorResponse>
{
    public Guid Id { get; set; }
    
    public class GetByIdDonorQueryHandler : IRequestHandler<GetByIdDonorQuery, GetByIdDonorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDonorRepository _donorRepository;

        public GetByIdDonorQueryHandler(IMapper mapper, IDonorRepository donorRepository)
        {
            _mapper = mapper;
            _donorRepository = donorRepository;
        }

        public async Task<GetByIdDonorResponse> Handle(GetByIdDonorQuery request, CancellationToken cancellationToken)
        {
            Donor? donor = await _donorRepository.GetAsync(predicate: c => c.Id == request.Id, withDeleted: true, cancellationToken: cancellationToken);
            GetByIdDonorResponse response = _mapper.Map<GetByIdDonorResponse>(donor);
            return response;
        }
    }
}