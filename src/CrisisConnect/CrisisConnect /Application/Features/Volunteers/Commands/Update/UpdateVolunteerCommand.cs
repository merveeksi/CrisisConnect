using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Volunteers.Commands.Update;

public class UpdateVolunteerCommand : IRequest<UpdatedVolunteerResponse>
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }

    public class UpdateVolunteerCommandHandler : IRequestHandler<UpdateVolunteerCommand, UpdatedVolunteerResponse>
    {
        private readonly IVolunteerRepository _volunteerRepository;
        private readonly IMapper _mapper;

        public UpdateVolunteerCommandHandler(IVolunteerRepository volunteerRepository, IMapper mapper)
        {
            _volunteerRepository = volunteerRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedVolunteerResponse> Handle(UpdateVolunteerCommand request,
            CancellationToken cancellationToken)
        {
            Volunteer? volunteer = await _volunteerRepository.GetAsync(predicate: v => v.Id == request.Id, cancellationToken: cancellationToken);
            volunteer = _mapper.Map(request, volunteer);
            await _volunteerRepository.UpdateAsync(volunteer); //veritabanına kaydetme işlemi
            UpdatedVolunteerResponse
                response = _mapper
                    .Map<UpdatedVolunteerResponse>(
                        volunteer); //volunteer nesnesini UpdatedVolunteerResponse nesnesine dönüştürme işlemi
            return response;
        }
    }
}