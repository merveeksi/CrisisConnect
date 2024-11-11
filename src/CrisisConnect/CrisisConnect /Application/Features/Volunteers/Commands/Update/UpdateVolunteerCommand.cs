using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.Features.Volunteers.Commands.Update;

public class UpdateVolunteerCommand : IRequest<UpdatedVolunteerResponse>, ICacheRemoverRequest
{
    public string? CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetVolunteers";
    public VolunteerId Id { get; set; }
    
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