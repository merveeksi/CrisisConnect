using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Teames.Commands.Delete;

public class DeleteTeamCommand: IRequest<DeletedTeamResponse>
{
    public Guid Id { get; set; }
    
    public class UpdateTeamCommandHandler : IRequestHandler<DeleteTeamCommand, DeletedTeamResponse>
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;

        public UpdateTeamCommandHandler(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public async Task<DeletedTeamResponse> Handle(DeleteTeamCommand request,
            CancellationToken cancellationToken)
        {
            Team? team = await _teamRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            
            await _teamRepository.UpdateAsync(team);
            
            DeletedTeamResponse response = _mapper.Map<DeletedTeamResponse>(team); 
            return response;
        }
    }
}