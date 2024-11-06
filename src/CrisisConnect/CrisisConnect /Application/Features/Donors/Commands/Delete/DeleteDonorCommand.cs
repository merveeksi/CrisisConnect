using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.Donors.Commands.Delete;

public class DeleteDonorCommand: IRequest<DeletedDonorResponse>, ICacheRemoverRequest
{
    public string? CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetDonors";

    public Guid Id { get; set; }
    
    public class UpdateDonorCommandHandler : IRequestHandler<DeleteDonorCommand, DeletedDonorResponse>
    {
        private readonly IDonorRepository _donorRepository;
        private readonly IMapper _mapper;

        public UpdateDonorCommandHandler(IDonorRepository donorRepository, IMapper mapper)
        {
            _donorRepository = donorRepository;
            _mapper = mapper;
        }

        public async Task<DeletedDonorResponse> Handle(DeleteDonorCommand request,
            CancellationToken cancellationToken)
        {
            Donor? donor = await _donorRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            
            await _donorRepository.UpdateAsync(donor);
            
            DeletedDonorResponse response = _mapper.Map<DeletedDonorResponse>(donor); 
            return response;
        }
    }
}