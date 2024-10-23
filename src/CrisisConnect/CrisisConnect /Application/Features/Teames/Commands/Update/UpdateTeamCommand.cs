using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Teames.Commands.Update;

public class UpdateTeamCommand : IRequest<UpdatedTeamResponse>
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }

    public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommand, UpdatedTeamResponse>
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;

        public UpdateTeamCommandHandler(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedTeamResponse> Handle(UpdateTeamCommand request,
            CancellationToken cancellationToken)
        {
            Team? team = await _teamRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            team = _mapper.Map(request, team);
            await _teamRepository.UpdateAsync(team); //veritabanına kaydetme işlemi
            UpdatedTeamResponse
                response = _mapper
                    .Map<UpdatedTeamResponse>(
                        team); //team nesnesini UpdatedTeamResponse nesnesine dönüştürme işlemi
            return response;
        }
    }
}