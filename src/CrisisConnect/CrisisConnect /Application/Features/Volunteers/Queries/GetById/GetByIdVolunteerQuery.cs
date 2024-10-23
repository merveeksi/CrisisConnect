using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Volunteers.Queries.GetById;

public class GetByIdVolunteerQuery : IRequest<GetByIdVolunteerResponse>
{
    public Guid Id { get; set; }
    
    public class GetByIdVolunteerQueryHandler : IRequestHandler<GetByIdVolunteerQuery, GetByIdVolunteerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVolunteerRepository _volunteerRepository;

        public GetByIdVolunteerQueryHandler(IMapper mapper, IVolunteerRepository volunteerRepository)
        {
            _mapper = mapper;
            _volunteerRepository = volunteerRepository;
        }

        public async Task<GetByIdVolunteerResponse> Handle(GetByIdVolunteerQuery request, CancellationToken cancellationToken)
        {
            Volunteer? volunteer = await _volunteerRepository.GetAsync(predicate: v => v.Id == request.Id, withDeleted: true, cancellationToken: cancellationToken);

            GetByIdVolunteerResponse response = _mapper.Map<GetByIdVolunteerResponse>(volunteer);

            return response;
        }
    }
}