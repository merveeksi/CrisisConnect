using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Teames.Commands.Create;

public class CreateTeamCommand : IRequest<CreatedTeamResponse>
{
    public string Name { get; set; }
    public string Specialty { get; set; }
    
    
    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, CreatedTeamResponse>
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        
        public CreateTeamCommandHandler(IMapper mapper, ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public async Task<CreatedTeamResponse> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            Team team = _mapper.Map<Team>(request);
            team.Id = Guid.NewGuid();
            
            await _teamRepository.AddAsync(team);
            
            CreatedTeamResponse createdTeamResponse = _mapper.Map<CreatedTeamResponse>(team);
            return createdTeamResponse;
        }
    }
}