using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Centers.Commands.Update;

public class UpdateCenterCommand : IRequest<UpdatedCenterResponse>
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }

    public class UpdateCenterCommandHandler : IRequestHandler<UpdateCenterCommand, UpdatedCenterResponse>
    {
        private readonly ICenterRepository _centerRepository;
        private readonly IMapper _mapper;

        public UpdateCenterCommandHandler(ICenterRepository centerRepository, IMapper mapper)
        {
            _centerRepository = centerRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedCenterResponse> Handle(UpdateCenterCommand request,
            CancellationToken cancellationToken)
        {
            Center? center = await _centerRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            center = _mapper.Map(request, center);
            await _centerRepository.UpdateAsync(center); //veritabanına kaydetme işlemi
            UpdatedCenterResponse
                response = _mapper
                    .Map<UpdatedCenterResponse>(
                        center); //center nesnesini UpdatedCenterResponse nesnesine dönüştürme işlemi
            return response;
        }
    }
}