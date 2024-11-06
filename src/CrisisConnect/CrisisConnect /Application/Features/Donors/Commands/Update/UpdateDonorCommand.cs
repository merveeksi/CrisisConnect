using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.Donors.Commands.Update;

public class UpdateDonorCommand : IRequest<UpdatedDonorResponse>, ICacheRemoverRequest
{
    public string? CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetDonors";

    public Guid Id { get; set; }
    
    public string Name { get; set; }

    public class UpdateDonorCommandHandler : IRequestHandler<UpdateDonorCommand, UpdatedDonorResponse>
    {
        private readonly IDonorRepository _donorRepository;
        private readonly IMapper _mapper;

        public UpdateDonorCommandHandler(IDonorRepository donorRepository, IMapper mapper)
        {
            _donorRepository = donorRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedDonorResponse> Handle(UpdateDonorCommand request,
            CancellationToken cancellationToken)
        {
            Donor? donor = await _donorRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            donor = _mapper.Map(request, donor);
            await _donorRepository.UpdateAsync(donor); //veritabanına kaydetme işlemi
            UpdatedDonorResponse
                response = _mapper
                    .Map<UpdatedDonorResponse>(
                        donor); //donor nesnesini UpdatedDonorResponse nesnesine dönüştürme işlemi
            return response;
        }
    }
}