using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Teames.Queries.GetById;

public class GetByIdTeamQuery : IRequest<GetByIdTeamResponse>
{
    public Guid Id { get; set; }
    
    public class GetByIdTeamQueryHandler : IRequestHandler<GetByIdTeamQuery, GetByIdTeamResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITeamRepository _teamRepository;

        public GetByIdTeamQueryHandler(IMapper mapper, ITeamRepository teamRepository)
        {
            _mapper = mapper;
            _teamRepository = teamRepository;
        }

        public async Task<GetByIdTeamResponse> Handle(GetByIdTeamQuery request, CancellationToken cancellationToken)
        {
            Team? team = await _teamRepository.GetAsync(predicate: t => t.Id == request.Id, withDeleted: true, cancellationToken: cancellationToken);
            GetByIdTeamResponse response = _mapper.Map<GetByIdTeamResponse>(team);
            return response;
        }
    }
}