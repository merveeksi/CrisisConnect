using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Disasters.Commands.Delete;

public class DeleteDisasterCommand : IRequest<DeletedDisasterResponse>
{
    public Guid Id { get; set; }
    
    public class UpdateDisasterCommandHandler : IRequestHandler<DeleteDisasterCommand, DeletedDisasterResponse>
    {
        private readonly IDisasterRepository _disasterRepository;
        private readonly IMapper _mapper;

        public UpdateDisasterCommandHandler(IDisasterRepository disasterRepository, IMapper mapper)
        {
            _disasterRepository = disasterRepository;
            _mapper = mapper;
        }

        public async Task<DeletedDisasterResponse> Handle(DeleteDisasterCommand request,
            CancellationToken cancellationToken)
        {
            Disaster? disaster = await _disasterRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            
            await _disasterRepository.UpdateAsync(disaster);
            
            DeletedDisasterResponse response = _mapper.Map<DeletedDisasterResponse>(disaster); 
            return response;
        }
    }
}